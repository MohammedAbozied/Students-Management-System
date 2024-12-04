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


namespace Student_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            dataGridView1.DataSource = clsStudent.GetAllStudents();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {

            //here i test methods, it's not final result.

            clsStudent student = clsStudent.FindStudent(2);
            //student.StudentID = 17;
            //student.FirstName = "test";
            //student.LastName = "add new";
            //student.Email = "test@new.com";
            //student.Phone = "ffdsdsa";
            //student.DateOfBirth = DateTime.Now;
            //student.Address = "fasd";
            //student.National_NO = "N0t510k01402";
            //student.Image_Path = "";
            //student.Gender = clsPerson.enGender.Male;
            //student.AcademicYear = 1;
            //student.DepartmentID = 1;
            student.FirstName = "Heba";
            student.LastName = "Said";
            student.DepartmentID = 1;
            student.AcademicYear = 1;
            if (MessageBox.Show("full name " + student.FullName, "", MessageBoxButtons.OK) == DialogResult.OK)
            {

            }

            if (student.Save())
            {
                MessageBox.Show("success updated", $"dep id {student.DepartmentID}\n", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = clsStudent.GetAllStudents();
            }
            else
                MessageBox.Show("failed", "failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //clsPerson person = new clsPerson(31,"","",clsPerson.enGender.Female,"","",DateTime.Now,"","","123551");
            //person.Save();
        }

        private void btnfind_Click(object sender, EventArgs e)
        {
            //int selectedID =  (int)dataGridView1.CurrentRow.Cells[0].Value;
            clsStudent student = clsStudent.FindStudent(1);

            if (student == null)
            {
                MessageBox.Show($"not existed id = {2}", "not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtFirstName.Text = student.FirstName;
            txtlastname.Text = student.LastName;
            txtaddress.Text = student.Address;
            txtemail.Text = student.Email;
            txtimagepath.Text = student.Image_Path;
            txtnationalno.Text = student.National_NO;
            txtphone.Text = student.Phone;
            dtpDateOfBirth.Value = student.DateOfBirth;
            if ((clsStudent.enGender)student.Gender == clsStudent.enGender.Male)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            txtstudentid.Text = student.StudentID.ToString();
            txtdepartmentid.Text = student.DepartmentID.ToString();
            txtacademicyear.Text = student.AcademicYear.ToString();
            MessageBox.Show($"the id = {2}");


        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            //int selectedID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            //clsPerson selectedPerson = clsPerson.FindPerson(selectedID);

            //if (selectedPerson == null)
            //{
            //    MessageBox.Show($"not existed id = {selectedID}", "not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //if(selectedPerson.Delete())
            //{ 
            //    MessageBox.Show($"deleted successfully"); 
            //    dataGridView1.DataSource = clsPerson.GetAllPeople();
            //}
            //else
            //{

            //    MessageBox.Show("failed");  
            //}


        }
    }
}
