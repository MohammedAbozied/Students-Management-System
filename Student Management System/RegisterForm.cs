using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Business;
using Guna.UI2.WinForms;
using static Business.clsDepartment;

namespace Student_Management_System
{
    public partial class RegisterForm : Form
    {
        // Delegate for data back
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

        public RegisterForm()
        {
            InitializeComponent();
        }

        private static DataTable dt;

        private void RegisterForm1_Load(object sender, EventArgs e)
        {
            try
            {
                dt = clsStudent.GetAllStudents();
                dt = new DataView(dt).ToTable(false, "Stu_ID", "FullName", "National_No", 
                                                "AcademicYear", "Department", "Gender", "Phone", "Email", 
                                                "Address", "DateOfBirth", "CoursesCount");

                DGVStudents.DataSource = dt;
                DGVStudents.ColumnHeadersHeight = 50;
                DGVStudents.AllowUserToResizeColumns = false;
                DGVStudents.AllowUserToResizeRows = false;
                DGVStudents.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGVStudents.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                // Setting column headers and widths
                if (DGVStudents.RowCount > 0)
                {
                    DGVStudents.Columns[0].HeaderText = "Std_ID";
                    DGVStudents.Columns[0].Width = 65;

                    DGVStudents.Columns[1].HeaderText = "Student Name";
                    DGVStudents.Columns[1].Width = 150;

                    DGVStudents.Columns[2].HeaderText = "National No";
                    DGVStudents.Columns[2].Width = 80;

                    DGVStudents.Columns[3].HeaderText = "Academic Year";
                    DGVStudents.Columns[3].Width = 95;

                    DGVStudents.Columns[4].HeaderText = "Department";
                    DGVStudents.Columns[4].Width = 190;

                    DGVStudents.Columns[5].HeaderText = "Gender";
                    DGVStudents.Columns[5].Width = 80;

                    DGVStudents.Columns[6].HeaderText = "Phone";
                    DGVStudents.Columns[6].Width = 100;

                    DGVStudents.Columns[7].HeaderText = "Email";
                    DGVStudents.Columns[7].Width = 150;

                    DGVStudents.Columns[8].HeaderText = "Address";
                    DGVStudents.Columns[8].Width = 150;

                    DGVStudents.Columns[9].HeaderText = "Date of Birth";
                    DGVStudents.Columns[9].Width = 100;

                    DGVStudents.Columns[10].HeaderText = "Courses";
                    DGVStudents.Columns[10].Width = 85;
                }

                // Counting students
                int totalStudents = DGVStudents.Rows.Count;
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

        }


        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGVStudents.CurrentRow == null || DGVStudents.CurrentRow.Cells[0].Value == null)
                {
                    MessageBox.Show("Please select a valid student record to delete.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedStudentID = Convert.ToInt32(DGVStudents.CurrentRow.Cells[0].Value);

                if (MessageBox.Show($"Are you sure you want to delete the student with ID: {selectedStudentID}?",
                    "Delete Student", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }

                if (clsStudent.DeleteStudent(selectedStudentID))
                {
                    MessageBox.Show("Student deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RegisterForm1_Load(null, null); 
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
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            try
            {
                int bornYear = DTP_DateOfBirth.Value.Year;
                int age = DateTime.Now.Year - bornYear;
                if (DTP_DateOfBirth.Value > DateTime.Now.AddYears(-age)) age--;

                if (age < 10 || age > 100)
                {
                    MessageBox.Show("Age must be between 10 and 100 years.", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var student = new clsStudent()
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    AcademicYear = 1,
                    Address = txtAddress.Text,
                    DateOfBirth = DTP_DateOfBirth.Value,
                    DepartmentID = (clsDepartment.Department)(cbDepartments.SelectedIndex+1),
                    Email = txtEmail.Text,
                    National_NO = txtNationalNo.Text,
                    Phone = txtPhone.Text,
                    Gender = rbFemale.Checked ? clsStudent.enGender.Female : clsStudent.enGender.Male,
                };

                if (student.Save())
                {
                    MessageBox.Show("Student added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RegisterForm1_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Failed to add student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding student: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
