using Business;
using System;
using System.Data;
using System.Web.UI.Design;
using System.Windows.Forms;

namespace Transparent_Form
{
    public partial class ManageScoreForm : Form
    {
        private static DataTable dt = clsEnrollment.GetAllEnrollments();
        private DataView dv = new DataView(dt);

        private clsEnrollment GetSelectedEnrollment()
        {
            clsEnrollment enrollment = clsEnrollment.FindEnrollment((int)DataGridView_score.CurrentRow.Cells[0].Value);
            return enrollment;
        }

        public ManageScoreForm()
        {
            InitializeComponent();
        }

        private void ManageScoreForm_Load(object sender, EventArgs e)
        {
            dt = clsEnrollment.GetAllEnrollments();
            dv = new DataView(dt);
            DataGridView_score.DataSource = dv;

            DataGridView_score.ColumnHeadersHeight = 50;
            DataGridView_score.AllowUserToResizeColumns = false;
            DataGridView_score.AllowUserToResizeRows = false;
            DataGridView_score.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridView_score.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridView_course_Click(null, null);

        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            clsEnrollment enrollment = GetSelectedEnrollment();
            try
            {
                enrollment.Grade = byte.Parse(textBox_score.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Invalid input. Please enter a valid student ID.\nError: {ex.Message}");
            }


            if(enrollment.Save())
            {
                MessageBox.Show("update successfully.","success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                ManageScoreForm_Load(null, null); // refresh form

            }
            else
                MessageBox.Show("update failed.","failed",MessageBoxButtons.OK,MessageBoxIcon.Error);

        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure? ", "delete enrollment", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;


            if(GetSelectedEnrollment().Delete())
            {
                MessageBox.Show("Deleted Successfully ", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ManageScoreForm_Load(null, null); // refresh form

            }
            else
                MessageBox.Show("deleted failed.", "failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_score.Clear();
            textBox_search.Clear();
            dv.RowFilter = ""; 
        }

        private void DataGridView_course_Click(object sender, EventArgs e)
        {
            if(DataGridView_score.Rows.Count > 0)
                textBox_score.Text = GetSelectedEnrollment().Grade.ToString();
        }

        private void button_search_Click(object sender, EventArgs e)
        {

            if (DataGridView_score.Rows.Count == 0)
                return;

            try
            {
                int selectedID = int.Parse(textBox_search.Text); 
                dv.RowFilter = $"Stu_ID = {selectedID}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Invalid input. Please enter a valid student ID.\nError: {ex.Message}");
            }

            DataGridView_course_Click(null, null);
        }



    }
}
