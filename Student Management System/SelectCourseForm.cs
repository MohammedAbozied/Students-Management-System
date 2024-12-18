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

namespace Student_Management_System
{
    public partial class SelectCourseForm : Form
    {
        //----------------------------------------------------------------------//
        public class DataBackEventArgs : EventArgs
        {
            public int CourseID { get; }

            public DataBackEventArgs(int courseID)
            {
                this.CourseID = courseID;

            }
        }

        public event EventHandler<DataBackEventArgs> DataBack;

        protected virtual void OnDataBack(int courseID)
        {
            DataBack?.Invoke(this, new DataBackEventArgs(courseID));
        }

        //----------------------------------------------------------------------//
        public SelectCourseForm()
        {
            InitializeComponent();
            DGV_Courses.DataSource = clsCourse.GetAllCourses().DefaultView.ToTable(false, "CourseID", "CourseName", "Hours", "Instructor_name");
            DGV_Courses.ColumnHeadersHeight = 50;
            DGV_Courses.AllowUserToResizeColumns = false;
            DGV_Courses.AllowUserToResizeRows = false;
            DGV_Courses.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_Courses.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void button_Select_Click(object sender, EventArgs e)
        {
            int selectedCourseID = (int)DGV_Courses.CurrentRow.Cells[0].Value;
            OnDataBack(selectedCourseID);

            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}
