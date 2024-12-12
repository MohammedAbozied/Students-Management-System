using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using Guna.UI2.WinForms;

namespace Student_Management_System
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            //guna2DataGridView1.DataSource =  clsStudent.GetAllStudents();
        }

        private static DataTable dt = clsStudent.GetAllStudents();
        private DataView dv = new DataView(dt);
        private void RegisterForm1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dv;

            if(dataGridView1.RowCount > 0)
            {

                dataGridView1.Columns[0].HeaderText = "Student ID";
                dataGridView1.Columns[0].Width = 100;

                dataGridView1.Columns[1].HeaderText = "national no";
                dataGridView1.Columns[1].Width = 100;

                dataGridView1.Columns[2].HeaderText = "student name";
                dataGridView1.Columns[2].Width = 100;

                dataGridView1.Columns[3].HeaderText = "academic year";
                dataGridView1.Columns[3].Width = 100;

                dataGridView1.Columns[4].HeaderText = "department";
                dataGridView1.Columns[4].Width = 100;

                dataGridView1.Columns[5].HeaderText = "gender";
                dataGridView1.Columns[5].Width = 100;

                dataGridView1.Columns[6].HeaderText = "phone";
                dataGridView1.Columns[6].Width = 100;


            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
