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
    public partial class SelectStudentForm : Form
    {
        //----------------------------------------------------------------------//
        public class DataBackEventArgs : EventArgs
        {
            public int StudentID { get; }

            public DataBackEventArgs(int studentID)
            {
                this.StudentID = studentID;

            }
        }

        public event EventHandler<DataBackEventArgs> DataBack;

        protected virtual void OnDataBack(int studentID)
        {
            DataBack?.Invoke(this, new DataBackEventArgs(studentID));
        }

        //----------------------------------------------------------------------//
        public SelectStudentForm()
        {
            InitializeComponent();

            DGV_Students.DataSource = clsStudent.GetAllStudents().DefaultView.ToTable(false, "Stu_ID", "FullName", "National_No", "AcademicYear", "Department");
            DGV_Students.ColumnHeadersHeight = 50;
            DGV_Students.AllowUserToResizeColumns = false;
            DGV_Students.AllowUserToResizeRows = false;
            DGV_Students.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_Students.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DGV_Students.Columns[0].Width = 80;
            DGV_Students.Columns["AcademicYear"].Width = 125;

        }

        private void button_Select_Click_1(object sender, EventArgs e)
        {
            int selectedStudentID = (int)DGV_Students.CurrentRow.Cells[0].Value;
            OnDataBack(selectedStudentID);

            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
