using Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Management_System
{
    public partial class EnrollmentForm : Form
    {
        private clsStudent SelectedStudent = new clsStudent();
        private List<int> SelectedCoursesID = new List<int>();

        static DataTable dt = new DataTable();
        public EnrollmentForm()
        {
            InitializeComponent();
        }

        

        private void btnSelectStudent_Click(object sender, EventArgs e)
        {
            SelectStudentForm frm = new SelectStudentForm();
            frm.DataBack += Frm_DataBack;
            frm.ShowDialog();
        }

        private void Frm_DataBack(object sender, SelectStudentForm.DataBackEventArgs e)
        {
            SelectedStudent = clsStudent.FindStudent(e.StudentID);

            lblStudentID.Text = SelectedStudent.StudentID.ToString();
            lblStudentID.Visible = true;

            lblChoosentStudentName.Text = SelectedStudent.FullName;
            lblChoosentStudentName.Visible = true;

            lblNationalNo.Text = SelectedStudent.National_NO;
            lblNationalNo.Visible = true;

            lblDepartment.Text = SelectedStudent.DepartmentInfo.DepartmentName;
            lblDepartment.Visible = true;

            ShowCourses(); // in data grid view
            btnSelectCourse.Enabled = true;
        }

        private void ShowCourses()
        {
            dt = clsStudent.AllEnrollments(SelectedStudent.StudentID);

            if (dt == null || dt.Rows.Count == 0)
            {
                dt = new DataTable();
                dt.Columns.Add("EnrollmentID", typeof(int));
                dt.Columns.Add("CourseName", typeof(string));
                dt.Columns.Add("Code", typeof(string));
                dt.Columns.Add("EnrollmentDate", typeof(DateTime));

                lblCoursesCount.Text = "0";
            }
            else
            {
                dt = dt.DefaultView.ToTable(false, "EnrollmentID", "CourseName", "Code", "EnrollmentDate");
                lblCoursesCount.Text = dt.Rows.Count.ToString();
            }

            DGV_Selected_Courses.DataSource = dt;
            DGV_Selected_Courses.ColumnHeadersHeight = 50;
            DGV_Selected_Courses.AllowUserToResizeColumns = false;
            DGV_Selected_Courses.AllowUserToResizeRows = false;
            DGV_Selected_Courses.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_Selected_Courses.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            lblCoursesCount.Visible = true;
        }


        private void btnSelectCourse_Click(object sender, EventArgs e)
        {
            SelectCourseForm frm = new SelectCourseForm();
            frm.DataBack += Frm_DataBack1;
            frm.ShowDialog();
        }

        private void Frm_DataBack1(object sender, SelectCourseForm.DataBackEventArgs e)
        {
            clsCourse selectedCourse = clsCourse.Find(e.CourseID);

            foreach (DataGridViewRow row in DGV_Selected_Courses.Rows)
            {
                if (row.Cells["CourseName"].Value != null && selectedCourse.CourseName == row.Cells["CourseName"].Value.ToString())
                {
                    MessageBox.Show("Course Already Enrolled with this student.", "Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            lblEnrollmentDate.Text = DateTime.Now.ToString("f");
            lblEnrollmentDate.Visible = true;

            dt.Rows.Add(-1,selectedCourse.CourseName, selectedCourse.Code,DateTime.Now); // add a new selected course
            SelectedCoursesID.Add(e.CourseID);

            lblCoursesCount.Text = DGV_Selected_Courses.Rows.Count.ToString();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach(int CourseID in SelectedCoursesID)
            {

                clsEnrollment Enrollment = new clsEnrollment()
                {
                    courseID = CourseID,
                    StudentID = SelectedStudent.StudentID,
                    EnrollmentDate = DateTime.Now,
                    Grade = 0
                };

                if(!Enrollment.Save())
                {
                    MessageBox.Show($"Failed in add Course: {clsCourse.Find(CourseID).CourseName}");
                    return;
                }
            }

            MessageBox.Show($"Courses Added Successfully.");
            ShowCourses();
            SelectedCoursesID.Clear();
        }

        //  context menu strip open only if there are selected row in data grid view
        private void cmsEnrollment_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (DGV_Selected_Courses.CurrentRow == null || DGV_Selected_Courses.CurrentRow.Index < 0)
            {
                e.Cancel = true;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedEnrollmentID = (int)DGV_Selected_Courses.CurrentRow.Cells[0].Value;
            // remove selected enrollment from data grid view
            if(selectedEnrollmentID == -1)
            {
                DGV_Selected_Courses.Rows.Remove(DGV_Selected_Courses.CurrentRow);
                lblCoursesCount.Text = DGV_Selected_Courses.Rows.Count.ToString();
                return;
            }

            // delete already existed enrollment 
            if(MessageBox.Show("are you sure ? ","confirm deleting",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            if (clsEnrollment.FindEnrollment(selectedEnrollmentID).Delete())
            {
                MessageBox.Show("Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DGV_Selected_Courses.Rows.Remove(DGV_Selected_Courses.CurrentRow);
                lblCoursesCount.Text = DGV_Selected_Courses.Rows.Count.ToString();

            }
            else
                MessageBox.Show("Error in Deleting Enrollment.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);



            // there is one problem : when delete non saved enrollment , is deleted just from DGV not from selectedCoursesID list.
            // means that will save when pressing save button.


        }






    }
}
