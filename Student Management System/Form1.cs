using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Student_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            dataGridView1.DataSource = clsCourse.GetAllCourses();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {

            //here i test methods, it's not final result.


            var course = clsCourse.Find(104);

            
            if (course.Delete())
            {
                MessageBox.Show($"success\ncourseID : {course.CourseID}\ncourseName: {course.CourseName}\ncode:{course.Code}\nhours:{course.Hours}\ndepID:{course.DepartmentID}\ninsID:{course.InstructorID}");

                dataGridView1.DataSource = clsCourse.GetAllCourses();

            }
            else
                MessageBox.Show("failed", "failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }



    }
}
