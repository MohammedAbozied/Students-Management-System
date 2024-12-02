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
/*using static System.IO.Directory;*/

namespace Student_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {


            InitializeComponent();
            //dataGridView1.DataSource = clsPerson.GetAllPeople();

            /*string current_path = System.IO.Directory.GetCurrentDirectory(); // the path to .exe
            // path to project directory
            string project_path = GetParent(GetParent(GetParent(current_path).FullName).FullName).FullName;

            MessageBox.Show("project path: " + project_path);*/
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            //clsPerson person = new clsPerson();
            ////person.PersonID = 54;
            //person.FirstName = "test";
            //person.LastName = "add new";
            //person.Email = "test@new.com";
            //person.Phone = "ffdsdsa";
            //person.DateOfBirth = DateTime.Now;
            //person.Address = "fasd";
            //person.National_NO = "Ntest2";
            //person.Image_Path = "";
            //person.Gender = clsPerson.enGender.Male;

            //if (person.Save())
            //{
            //    //MessageBox.Show("success", $"id {person.PersonID}", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    dataGridView1.DataSource = clsPerson.GetAllPeople();
            //}
            //else
            //    MessageBox.Show("failed", "failed", MessageBoxButtons.OK, MessageBoxIcon.Error);  

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //clsPerson person = new clsPerson(31,"","",clsPerson.enGender.Female,"","",DateTime.Now,"","","123551");
            //person.Save();
        }

        private void btnfind_Click(object sender, EventArgs e)
        {
            //int selectedID =  (int)dataGridView1.CurrentRow.Cells[0].Value;
            clsStudent student = clsStudent.FindStudent(2);

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
            if((clsStudent.enGender)student.Gender == clsStudent.enGender.Male)
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
