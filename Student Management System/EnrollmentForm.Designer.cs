namespace Student_Management_System
{
    partial class EnrollmentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSelectStudent = new System.Windows.Forms.Button();
            this.btnSelectCourse = new System.Windows.Forms.Button();
            this.DGV_Selected_Courses = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.lblChoosentStudentName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNationalNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEnrollmentDate = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCoursesCount = new System.Windows.Forms.Label();
            this.cmsEnrollment = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Selected_Courses)).BeginInit();
            this.cmsEnrollment.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Green;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1109, 51);
            this.panel1.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(465, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(248, 32);
            this.label7.TabIndex = 0;
            this.label7.Text = "Course Enrollment";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSelectStudent
            // 
            this.btnSelectStudent.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnSelectStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectStudent.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectStudent.ForeColor = System.Drawing.Color.White;
            this.btnSelectStudent.Location = new System.Drawing.Point(35, 69);
            this.btnSelectStudent.Name = "btnSelectStudent";
            this.btnSelectStudent.Size = new System.Drawing.Size(217, 52);
            this.btnSelectStudent.TabIndex = 46;
            this.btnSelectStudent.Text = "Select Student";
            this.btnSelectStudent.UseVisualStyleBackColor = false;
            this.btnSelectStudent.Click += new System.EventHandler(this.btnSelectStudent_Click);
            // 
            // btnSelectCourse
            // 
            this.btnSelectCourse.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnSelectCourse.Enabled = false;
            this.btnSelectCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectCourse.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectCourse.ForeColor = System.Drawing.Color.White;
            this.btnSelectCourse.Location = new System.Drawing.Point(35, 467);
            this.btnSelectCourse.Name = "btnSelectCourse";
            this.btnSelectCourse.Size = new System.Drawing.Size(217, 49);
            this.btnSelectCourse.TabIndex = 47;
            this.btnSelectCourse.Text = "Add Course";
            this.btnSelectCourse.UseVisualStyleBackColor = false;
            this.btnSelectCourse.Click += new System.EventHandler(this.btnSelectCourse_Click);
            // 
            // DGV_Selected_Courses
            // 
            this.DGV_Selected_Courses.AllowUserToAddRows = false;
            this.DGV_Selected_Courses.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DGV_Selected_Courses.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_Selected_Courses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV_Selected_Courses.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Selected_Courses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_Selected_Courses.ColumnHeadersHeight = 24;
            this.DGV_Selected_Courses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGV_Selected_Courses.ContextMenuStrip = this.cmsEnrollment;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Selected_Courses.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGV_Selected_Courses.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGV_Selected_Courses.Location = new System.Drawing.Point(421, 69);
            this.DGV_Selected_Courses.Name = "DGV_Selected_Courses";
            this.DGV_Selected_Courses.ReadOnly = true;
            this.DGV_Selected_Courses.RowHeadersVisible = false;
            this.DGV_Selected_Courses.RowHeadersWidth = 51;
            this.DGV_Selected_Courses.RowTemplate.Height = 80;
            this.DGV_Selected_Courses.Size = new System.Drawing.Size(676, 447);
            this.DGV_Selected_Courses.TabIndex = 48;
            this.DGV_Selected_Courses.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DGV_Selected_Courses.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGV_Selected_Courses.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGV_Selected_Courses.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DGV_Selected_Courses.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DGV_Selected_Courses.ThemeStyle.BackColor = System.Drawing.Color.Gainsboro;
            this.DGV_Selected_Courses.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGV_Selected_Courses.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DGV_Selected_Courses.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGV_Selected_Courses.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV_Selected_Courses.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DGV_Selected_Courses.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGV_Selected_Courses.ThemeStyle.HeaderStyle.Height = 24;
            this.DGV_Selected_Courses.ThemeStyle.ReadOnly = true;
            this.DGV_Selected_Courses.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DGV_Selected_Courses.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGV_Selected_Courses.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV_Selected_Courses.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DGV_Selected_Courses.ThemeStyle.RowsStyle.Height = 80;
            this.DGV_Selected_Courses.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGV_Selected_Courses.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 23);
            this.label3.TabIndex = 50;
            this.label3.Text = "Student Name: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblChoosentStudentName
            // 
            this.lblChoosentStudentName.AutoSize = true;
            this.lblChoosentStudentName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChoosentStudentName.ForeColor = System.Drawing.Color.Red;
            this.lblChoosentStudentName.Location = new System.Drawing.Point(67, 236);
            this.lblChoosentStudentName.Name = "lblChoosentStudentName";
            this.lblChoosentStudentName.Size = new System.Drawing.Size(72, 23);
            this.lblChoosentStudentName.TabIndex = 49;
            this.lblChoosentStudentName.Text = "[????]";
            this.lblChoosentStudentName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblChoosentStudentName.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 23);
            this.label1.TabIndex = 52;
            this.label1.Text = "National No:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNationalNo
            // 
            this.lblNationalNo.AutoSize = true;
            this.lblNationalNo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNationalNo.ForeColor = System.Drawing.Color.Red;
            this.lblNationalNo.Location = new System.Drawing.Point(67, 323);
            this.lblNationalNo.Name = "lblNationalNo";
            this.lblNationalNo.Size = new System.Drawing.Size(72, 23);
            this.lblNationalNo.TabIndex = 51;
            this.lblNationalNo.Text = "[????]";
            this.lblNationalNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNationalNo.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 550);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 23);
            this.label2.TabIndex = 54;
            this.label2.Text = "Enrollment Date:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEnrollmentDate
            // 
            this.lblEnrollmentDate.AutoSize = true;
            this.lblEnrollmentDate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnrollmentDate.ForeColor = System.Drawing.Color.Green;
            this.lblEnrollmentDate.Location = new System.Drawing.Point(67, 575);
            this.lblEnrollmentDate.Name = "lblEnrollmentDate";
            this.lblEnrollmentDate.Size = new System.Drawing.Size(72, 23);
            this.lblEnrollmentDate.TabIndex = 53;
            this.lblEnrollmentDate.Text = "[????]";
            this.lblEnrollmentDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEnrollmentDate.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.YellowGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(880, 541);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(217, 57);
            this.btnSave.TabIndex = 55;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 23);
            this.label4.TabIndex = 56;
            this.label4.Text = "Student ID: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentID.ForeColor = System.Drawing.Color.Green;
            this.lblStudentID.Location = new System.Drawing.Point(159, 150);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(72, 23);
            this.lblStudentID.TabIndex = 57;
            this.lblStudentID.Text = "[????]";
            this.lblStudentID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStudentID.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 371);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 23);
            this.label5.TabIndex = 59;
            this.label5.Text = "Department: ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartment.ForeColor = System.Drawing.Color.Red;
            this.lblDepartment.Location = new System.Drawing.Point(67, 413);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(72, 23);
            this.lblDepartment.TabIndex = 58;
            this.lblDepartment.Text = "[????]";
            this.lblDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDepartment.Visible = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(417, 541);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 23);
            this.label6.TabIndex = 61;
            this.label6.Text = "Courses Count: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCoursesCount
            // 
            this.lblCoursesCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCoursesCount.AutoSize = true;
            this.lblCoursesCount.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoursesCount.ForeColor = System.Drawing.Color.Green;
            this.lblCoursesCount.Location = new System.Drawing.Point(607, 541);
            this.lblCoursesCount.Name = "lblCoursesCount";
            this.lblCoursesCount.Size = new System.Drawing.Size(72, 23);
            this.lblCoursesCount.TabIndex = 60;
            this.lblCoursesCount.Text = "[????]";
            this.lblCoursesCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCoursesCount.Visible = false;
            // 
            // cmsEnrollment
            // 
            this.cmsEnrollment.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsEnrollment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.cmsEnrollment.Name = "cmsEnrollment";
            this.cmsEnrollment.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.cmsEnrollment.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmsEnrollment.RenderStyle.ColorTable = null;
            this.cmsEnrollment.RenderStyle.RoundedEdges = true;
            this.cmsEnrollment.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.cmsEnrollment.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmsEnrollment.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.cmsEnrollment.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.cmsEnrollment.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cmsEnrollment.Size = new System.Drawing.Size(215, 60);
            this.cmsEnrollment.Opening += new System.ComponentModel.CancelEventHandler(this.cmsEnrollment_Opening);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.deleteToolStripMenuItem.Image = global::Student_Management_System.Properties.Resources.Delete_32;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(214, 28);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // EnrollmentForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 623);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblCoursesCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.lblStudentID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblEnrollmentDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNationalNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblChoosentStudentName);
            this.Controls.Add(this.DGV_Selected_Courses);
            this.Controls.Add(this.btnSelectCourse);
            this.Controls.Add(this.btnSelectStudent);
            this.Controls.Add(this.panel1);
            this.Name = "EnrollmentForm";
            this.Text = "Enrollment Form";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Selected_Courses)).EndInit();
            this.cmsEnrollment.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSelectStudent;
        private System.Windows.Forms.Button btnSelectCourse;
        private Guna.UI2.WinForms.Guna2DataGridView DGV_Selected_Courses;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblChoosentStudentName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNationalNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEnrollmentDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCoursesCount;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip cmsEnrollment;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}