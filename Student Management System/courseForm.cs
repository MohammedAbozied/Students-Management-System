using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Business.clsDepartment;


namespace Student_Management_System
{
    public partial class CourseForm: Form
    {
        public CourseForm()
        {
            InitializeComponent();
        }
        private DataTable dt;
        private clsCourse NewCourse = new clsCourse();
        private clsInstructor selectedInstructor = new clsInstructor();
        private void CourseForm_Load(object sender, EventArgs e)
        {
            DataGridView_course.DataSource = dt;
            DataGridView_course.ColumnHeadersHeight = 50;
            DataGridView_course.AllowUserToResizeColumns = false;
            DataGridView_course.AllowUserToResizeRows = false;
            DataGridView_course.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridView_course.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dt = clsCourse.GetAllCourses();
            DataGridView_course.DataSource = dt;

            cbDepartments.DataSource = Enum.GetValues(typeof(Department));
            cbHours.SelectedIndex = 2;

        }
        private void button_add_Click(object sender, EventArgs e)
        {
            NewCourse.CourseName = txtName.Text.ToString();
            NewCourse.InstructorID = selectedInstructor.InstructorID;
            NewCourse.Code = txtCode.Text.ToString();
            NewCourse.Hours = (byte)(cbHours.SelectedIndex + 1);
            NewCourse.DepartmentID = cbDepartments.SelectedIndex + 1;

            if(NewCourse.Save())
            {
                MessageBox.Show($"Course Added Successfully\n With ID : {NewCourse.CourseID}", 
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                button_clear.PerformClick(); // execute code in it
                CourseForm_Load(null, null);
                return;
            }

            MessageBox.Show("Failed add new course","failed",MessageBoxButtons.OK,MessageBoxIcon.Error);

        }
        private void button_clear_Click(object sender, EventArgs e)
        {

            txtName.Clear();
            txtCode.Clear();
            cbDepartments.SelectedIndex = 0;
            cbHours.SelectedIndex = 2;
            lblChoosentInstructorName.Visible = false;
            selectedInstructor = new clsInstructor();
            NewCourse = new clsCourse();
        }

        private void btnSelectInstructor_Click(object sender, EventArgs e)
        {
            SelectInstructor frm = new SelectInstructor();

            frm.DataBack += Frm_DataBack;

            frm.ShowDialog();
        }

        private void Frm_DataBack(object sender, SelectInstructor.DataBackEventArgs e)
        {
            selectedInstructor = clsInstructor.FindInstructor(e.InstructorID);
            lblChoosentInstructorName.Text = selectedInstructor.FullName;
            lblChoosentInstructorName.Visible = true;
        } 
    }
}




