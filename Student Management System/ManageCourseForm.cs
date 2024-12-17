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
using static Business.clsDepartment;

namespace Student_Management_System
{
    public partial class ManageCourseForm : Form
    {

        private clsCourse UpdateCourse = new clsCourse();
        private clsInstructor selectedInstructor = new clsInstructor();

        private clsCourse getSelectedCourse()
        {
            return clsCourse.Find((int)DataGridView_course.CurrentRow.Cells[0].Value);
        }

        private static DataTable dt;
        private DataView dv;

        public ManageCourseForm()
        {
            InitializeComponent();
        }

        private void ManageCourseForm_Load(object sender, EventArgs e)
        {
            dt = clsCourse.GetAllCourses();
            dv = new DataView(dt);

            
            DataGridView_course.DataSource = dv;

            DataGridView_course.DataSource = dt;
            DataGridView_course.ColumnHeadersHeight = 50;
            DataGridView_course.AllowUserToResizeColumns = false;
            DataGridView_course.AllowUserToResizeRows = false;
            DataGridView_course.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridView_course.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            cbDepartments.DataSource = Enum.GetValues(typeof(Department));
            cbHours.SelectedIndex = 2;

            DataGridView_course_Click(null, null);


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

        private void button_Update_Click(object sender, EventArgs e)
        {
            if(txtName.Text.Trim() == string.Empty || txtCode.Text.Trim() == string.Empty)
            {
                MessageBox.Show("fields shouldn't be empty.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(selectedInstructor == null)
            {
                MessageBox.Show("you shouldSelect instructor.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UpdateCourse = getSelectedCourse();

            UpdateCourse.CourseName = txtName.Text.Trim();
            UpdateCourse.Code = txtCode.Text.Trim();
            UpdateCourse.DepartmentID = cbDepartments.SelectedIndex+1;
            UpdateCourse.Hours = (byte)(cbHours.SelectedIndex + 1);
            UpdateCourse.InstructorID = selectedInstructor.InstructorID;

            if(UpdateCourse.Save())
            {
                MessageBox.Show("Course updated Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ManageCourseForm_Load(null, null);
                return;
            }
            else
                MessageBox.Show("failed update course.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void DataGridView_course_Click(object sender, EventArgs e)
        {
            UpdateCourse = getSelectedCourse();
            selectedInstructor = clsInstructor.FindInstructor(UpdateCourse.InstructorID);

            txtName.Text = UpdateCourse.CourseName;
            txtCode.Text = UpdateCourse.Code;
            cbDepartments.SelectedIndex = UpdateCourse.DepartmentID - 1;
            cbHours.SelectedIndex = UpdateCourse.Hours - 1;
            lblChoosentInstructorName.Text = selectedInstructor.FullName;
            lblChoosentInstructorName.Visible = true;
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtCode.Clear();
            cbDepartments.SelectedIndex = 0;
            cbHours.SelectedIndex = 2;
            lblChoosentInstructorName.Visible = false;
            selectedInstructor = new clsInstructor();
            UpdateCourse = new clsCourse();
        }



    }
}
