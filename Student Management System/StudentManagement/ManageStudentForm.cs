using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static Business.clsDepartment;


namespace Student_Management_System
{
    public partial class ManageStudentForm : Form
    {
        public ManageStudentForm()
        {
            InitializeComponent();
        }

        

        public class DataBackEventArgs : EventArgs
        {
            public int TotalStudents { get; }
            public int TotalMale { get; }
            public int TotalFemale { get; }

            public DataBackEventArgs(int totalStudents, int totalMale, int totalFemale)
            {
                this.TotalStudents = totalStudents;
                this.TotalMale = totalMale;
                this.TotalFemale = totalFemale;
            }
        }

        public event EventHandler<DataBackEventArgs> DataBack;

        protected virtual void OnDataBack(int totalStudents, int totalMale, int totalFemale)
        {
            DataBack?.Invoke(this, new DataBackEventArgs(totalStudents, totalMale, totalFemale));
        }

        private DataTable getAllStudents()
        {
            return clsStudent.GetAllStudents().DefaultView.ToTable(false, "Stu_ID", "FullName", "National_No",
                                                "AcademicYear", "Department", "Gender", "Phone", "Email",
                                                "Address", "DateOfBirth", "CoursesCount");
        }

        private static DataTable dt;
        private void ManageStudentForm_Load(object sender, EventArgs e)
        {
            try
            {
                dt = getAllStudents();

                DGVManageStudent.DataSource = dt;
                DGVManageStudent.ColumnHeadersHeight = 50;
                DGVManageStudent.AllowUserToResizeColumns = false;
                DGVManageStudent.AllowUserToResizeRows = false;
                DGVManageStudent.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGVManageStudent.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                // Setting column headers and widths
                if (DGVManageStudent.RowCount > 0)
                {
                    DGVManageStudent.Columns[0].HeaderText = "Std_ID";
                    DGVManageStudent.Columns[0].Width = 65;

                    DGVManageStudent.Columns[1].HeaderText = "Student Name";
                    DGVManageStudent.Columns[1].Width = 150;

                    DGVManageStudent.Columns[2].HeaderText = "National No";
                    DGVManageStudent.Columns[2].Width = 80;

                    DGVManageStudent.Columns[3].HeaderText = "Academic Year";
                    DGVManageStudent.Columns[3].Width = 95;

                    DGVManageStudent.Columns[4].HeaderText = "Department";
                    DGVManageStudent.Columns[4].Width = 190;

                    DGVManageStudent.Columns[5].HeaderText = "Gender";
                    DGVManageStudent.Columns[5].Width = 80;

                    DGVManageStudent.Columns[6].HeaderText = "Phone";
                    DGVManageStudent.Columns[6].Width = 100;

                    DGVManageStudent.Columns[7].HeaderText = "Email";
                    DGVManageStudent.Columns[7].Width = 150;

                    DGVManageStudent.Columns[8].HeaderText = "Address";
                    DGVManageStudent.Columns[8].Width = 150;

                    DGVManageStudent.Columns[9].HeaderText = "Date of Birth";
                    DGVManageStudent.Columns[9].Width = 100;

                    DGVManageStudent.Columns[10].HeaderText = "Courses";
                    DGVManageStudent.Columns[10].Width = 85;
                }

                // Counting students
                int totalStudents = DGVManageStudent.Rows.Count;
                int totalMales = clsStudent.CountMales();
                int totalFemales = totalStudents - totalMales;

                OnDataBack(totalStudents, totalMales, totalFemales);

                cbDepartments.DataSource = Enum.GetValues(typeof(Department));
                DTP_DateOfBirth.Value = DateTime.Now.AddYears(-18);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DGVManageStudent_Click(null, null); // to select first row 

        }

        private void button_clean_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtNationalNo.Clear();
            DTP_DateOfBirth.Value = DateTime.Now.AddYears(-18);
            rbMale.Checked = false;
            rbFemale.Checked = false;
        }

        private void DGVManageStudent_Click(object sender, EventArgs e)
        {
            
            string[] fullName = DGVManageStudent.CurrentRow.Cells["FullName"].Value.ToString().Split(' ');
            txtFirstName.Text = fullName[0];
            txtLastName.Text = fullName[1];


            txtNationalNo.Text= DGVManageStudent.CurrentRow.Cells["National_NO"].Value.ToString();
            cbDepartments.Text = DGVManageStudent.CurrentRow.Cells["Department"].Value.ToString();

            if (DGVManageStudent.CurrentRow.Cells["Gender"].Value.ToString() == "Male")
            {
                rbMale.Checked = true;
            }
            else
            {
                rbFemale.Checked = true;
            }

            txtPhone.Text= DGVManageStudent.CurrentRow.Cells["Phone"].Value.ToString();
            txtEmail.Text = DGVManageStudent.CurrentRow.Cells["Email"].Value.ToString();
            txtAddress.Text = DGVManageStudent.CurrentRow.Cells["Address"].Value.ToString();
            DTP_DateOfBirth.Value = (DateTime)DGVManageStudent.CurrentRow.Cells["DateOfBirth"].Value;
            cbDepartments.SelectedIndex = (int)(clsStudent.FindStudent((int)DGVManageStudent.CurrentRow.Cells[0].Value).DepartmentID - 1);

            
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = DGVManageStudent.SelectedCells[0].RowIndex;
            var selectedRow = DGVManageStudent.Rows[selectedRowIndex];
            int studentId = Convert.ToInt32(selectedRow.Cells["Stu_Id"].Value);

            var student = clsStudent.FindStudent(studentId);

            if (student != null)
            {
                student.FirstName = txtFirstName.Text;
                student.LastName = txtLastName.Text;
                student.Phone = txtPhone.Text;
                student.DepartmentID = (clsDepartment.Department)(cbDepartments.SelectedIndex + 1);

                DateTime dateOfBirth;
                if (DateTime.TryParse(DTP_DateOfBirth.Text, out dateOfBirth))
                {
                    student.DateOfBirth = dateOfBirth;
                }
                else
                {
                    MessageBox.Show("Please enter a valid date of birth.");
                    return;
                }

                student.Email = txtEmail.Text;
                student.Address = txtAddress.Text;
                student.National_NO = txtNationalNo.Text;

                if (rbMale.Checked)
                {
                    student.Gender = clsStudent.enGender.Male; 
                }
                else if (rbFemale.Checked)
                {
                    student.Gender = clsStudent.enGender.Female; 
                }

                if (student.Save())
                    MessageBox.Show("updated successfully", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("update failed", "failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                MessageBox.Show("The student does not exist");
            }
        }

        private void button_search_Click_1(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            DataTable allStudents = getAllStudents();

            if (!string.IsNullOrEmpty(searchText))
            {
                DataView dataView = new DataView(allStudents);

                string filter = $"[FullName] LIKE '%{searchText}%'";
                if (int.TryParse(searchText, out int stuId))
                {
                    filter += $" OR Stu_ID = {stuId}"; 
                }

                dataView.RowFilter = filter;

                if (dataView.ToTable().Rows.Count == 0)
                {
                    MessageBox.Show("Student Not Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DGVManageStudent.DataSource = dataView.ToTable();
                DGVManageStudent_Click(null, null);

            }


        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGVManageStudent.CurrentRow == null || DGVManageStudent.CurrentRow.Cells[0].Value == null)
                {
                    MessageBox.Show("Please select a valid student record to delete.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedStudentID = Convert.ToInt32(DGVManageStudent.CurrentRow.Cells[0].Value);

                if (MessageBox.Show($"Are you sure you want to delete the student with ID: {selectedStudentID}?",
                    "Delete Student", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }

                if (clsStudent.DeleteStudent(selectedStudentID))
                {
                    MessageBox.Show("Student deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ManageStudentForm_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Failed to delete student. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
