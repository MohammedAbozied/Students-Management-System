using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transparent_Form;

namespace Student_Management_System
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
            
        }

        
        private void customizeDesign()
        {
            panel_stdsubmenu.Visible = false;
            panel_courseSubmenu.Visible = false;
            panel_scoreSubmenu.Visible = false;
        }
        private void hideSubmenu()
        {
            if (panel_stdsubmenu.Visible == true)
                panel_stdsubmenu.Visible = false;
            if (panel_courseSubmenu.Visible == true)
                panel_courseSubmenu.Visible = false;
            if (panel_scoreSubmenu.Visible == true)
                panel_scoreSubmenu.Visible = false;
        }

        private void showSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubmenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }

        private void button_registration_Click_1(object sender, EventArgs e)
        {

            main_panel.Controls.Clear();

            RegisterForm frm = new RegisterForm();

            frm.DataBack +=
                (object s, RegisterForm.DataBackEventArgs d) =>
                {
                    lblTotalStudents.Text = d.TotalStudents.ToString();
                    lblTotalMale.Text = d.TotalMale.ToString();
                    lblTotalFemale.Text = d.TotalFemale.ToString();
                };


            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            main_panel.Controls.Add(frm);
            main_panel.Tag = frm;

            frm.BringToFront();
            frm.Show();
        }


        private void button_std_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_stdsubmenu);
        }

        private void button_registration_Click(object sender, EventArgs e)
        {
            //...
            //...Your code = create a new object of your form then show dialoge
            //...
            hideSubmenu();
        }

        private void button_manageStd_Click(object sender, EventArgs e)
        {
            //...
            //...Your code
            //...
            hideSubmenu();
        }

        private void button_status_Click(object sender, EventArgs e)
        {
            //...
            //...Your code
            //...
            hideSubmenu();
        }

        private void button_stdPrint_Click(object sender, EventArgs e)
        {
            //...
            //...Your code
            //...
            hideSubmenu();
        }

        private void button_course_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_courseSubmenu);
        }

        private void button_newCourse_Click(object sender, EventArgs e)
        {
            main_panel.Controls.Clear();

            CourseForm frm = new CourseForm();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            main_panel.Controls.Add(frm);
            main_panel.Tag = frm;

            frm.BringToFront();
            frm.Show();

        }

        private void button_manageCourse_Click(object sender, EventArgs e)
        {
            main_panel.Controls.Clear();

            ManageCourseForm frm = new ManageCourseForm();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            main_panel.Controls.Add(frm);
            main_panel.Tag = frm;

            frm.BringToFront();
            frm.Show();
        }

        private void btnEnrollment_Click(object sender, EventArgs e)
        {
            main_panel.Controls.Clear();

            EnrollmentForm frm = new EnrollmentForm();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            main_panel.Controls.Add(frm);
            main_panel.Tag = frm;

            frm.BringToFront();
            frm.Show();
        }

        private void button_coursePrint_Click(object sender, EventArgs e)
        {
            //...
            //...Your code
            //...
            hideSubmenu();
        }

        private void button_score_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_scoreSubmenu); ;
        }

       

        private void button_manageScore_Click(object sender, EventArgs e)
        {
            main_panel.Controls.Clear();

            ManageScoreForm frm = new ManageScoreForm();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            main_panel.Controls.Add(frm);
            main_panel.Tag = frm;

            frm.BringToFront();
            frm.Show();

        }

        private void button_scorePrint_Click(object sender, EventArgs e)
        {
            //...
            //...Your code
            //...
            hideSubmenu();
        }
        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void button_manageStd_Click_1(object sender, EventArgs e)
        {

            main_panel.Controls.Clear();

            ManageStudentForm frm = new ManageStudentForm();

            frm.DataBack +=
                (object s, ManageStudentForm.DataBackEventArgs d) =>
                {
                    lblTotalStudents.Text = d.TotalStudents.ToString();
                    lblTotalMale.Text = d.TotalMale.ToString();
                    lblTotalFemale.Text = d.TotalFemale.ToString();
                };

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            main_panel.Controls.Add(frm);
            main_panel.Tag = frm;

            frm.BringToFront();
            frm.Show();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_slide_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       
        private void Main_Form_Load(object sender, EventArgs e)
        {

        }

        
    }
}
