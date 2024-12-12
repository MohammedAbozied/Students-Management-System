using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using Business;
using Guna.UI2.WinForms;

namespace Student_Management_System
{
    public partial class RegisterForm : Form
    {

        // delegate
        public class DataBackEventArgs : EventArgs 
        {
            public int TotalStudents { get; }
            public int TotalMale { get; }
            public int TotalFemale { get; } 

            public DataBackEventArgs(int totalStudents,int totalMale,int totalFemale)
            {
                this.TotalStudents = totalStudents;
                this.TotalMale = totalMale;
                this.TotalFemale = totalFemale;
            }
        }
        public event EventHandler<DataBackEventArgs> DataBack;
        protected virtual void onDataBack(int totalStudents, int totalMale, int totalFemale)
        {
            DataBack?.Invoke(this, new DataBackEventArgs(totalStudents, totalMale, totalFemale));
        }
        //----------------------------------------------------------------------------
        public RegisterForm()
        {
            InitializeComponent();
        }

        private static DataTable dt;
        private DataView dv;

        
        private void RegisterForm1_Load(object sender, EventArgs e)
        {
            dt = clsStudent.GetAllStudents();
            dv = new DataView(dt);

            DGVStudents.DataSource = dv;
            DGVStudents.ColumnHeadersHeight = 50;
            DGVStudents.AllowUserToResizeColumns = false;
            DGVStudents.AllowUserToResizeRows= false;
            DGVStudents.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGVStudents.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            



            if (DGVStudents.RowCount > 0)
            {

                DGVStudents.Columns[0].HeaderText = "Std_ID";
                DGVStudents.Columns[0].Width = 65;

                DGVStudents.Columns[1].HeaderText = "Student name";
                DGVStudents.Columns[1].Width = 150;

                DGVStudents.Columns[2].HeaderText = "National no";
                DGVStudents.Columns[2].Width = 80;

                DGVStudents.Columns[3].HeaderText = "Academic year";
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

                DGVStudents.Columns[10].HeaderText = "courses";
                DGVStudents.Columns[10].Width = 85;
                
                DGVStudents.Columns[11].HeaderText = "Image";


            }

            int TotalStudents = DGVStudents.Rows.Count;
            int TotalMales = clsStudent.CountMales();
            int TotalFemales = TotalStudents - TotalMales;

            onDataBack(TotalStudents, TotalMales, TotalFemales); // call it in main form to update Students count.


            // to fill departments combo box.
            DataTable dtDepartments = clsDepartment.GetDepartmentsName();
            cbDepartments.Items.Clear();

            foreach (DataRow dr in dtDepartments.Rows)
            {
                cbDepartments.Items.Add(dr["Name"].ToString());
            }
            cbDepartments.SelectedIndex = 0; // initial value

        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
           int selectedStudentID = (int)DGVStudents.CurrentRow.Cells[0].Value;

            if (MessageBox.Show($"are you sure you want to delete Student with ID: {selectedStudentID} ?",
                "Delete Student.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            if(clsStudent.DeleteStudent(selectedStudentID))
            {
                MessageBox.Show("Student Deleted Successfully.", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                RegisterForm1_Load(null, null); // to refresh form , and update Students list.
            }
            else
                MessageBox.Show("Field in Deleting Student.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            var student = new clsStudent()
            {
                FirstName = "kareem",
                LastName = "ali",
                AcademicYear = 1,
                Address = "fadsf",
                DateOfBirth = DateTime.Now,
                DepartmentID = 1,
                Email = "fas",
                National_NO = "fsda4"

            };

            if(student.Save())
                MessageBox.Show("done");
            else
                MessageBox.Show("failed");

                RegisterForm1_Load(null, null); // to refresh form , and update Students list.

        }
    }
}
