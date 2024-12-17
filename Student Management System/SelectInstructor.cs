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
    public partial class SelectInstructor : Form
    {


        //----------------------------------------------------------------------//
        public class DataBackEventArgs : EventArgs                       
        {                                                                
            public int InstructorID { get;  }                            
                                                                         
            public DataBackEventArgs(int instructorID)                   
            {                                                            
                this.InstructorID = instructorID;                        
                                                                         
            }                                                            
        }                                                                
                                                                         
        public event EventHandler<DataBackEventArgs> DataBack;           
                                                                         
        protected virtual void OnDataBack(int instructorID)              
        {                                                                
            DataBack?.Invoke(this, new DataBackEventArgs(instructorID)); 
        }

        //----------------------------------------------------------------------//

        public SelectInstructor()
        {
            InitializeComponent();
            DGV_Instructors.DataSource = clsInstructor.GetAllInstructors().DefaultView.ToTable(false,"InstructorID","instructor_Name","department_Name","Salary","Address");
            DGV_Instructors.ColumnHeadersHeight = 50;
            DGV_Instructors.AllowUserToResizeColumns = false;
            DGV_Instructors.AllowUserToResizeRows = false;
            DGV_Instructors.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DGV_Instructors.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void button_Select_Click(object sender, EventArgs e)
        {
            int selectedInstructorID = (int)DGV_Instructors.CurrentRow.Cells[0].Value;
            OnDataBack(selectedInstructorID); 

            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
