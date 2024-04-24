namespace coursework_ui
{
    partial class AddNewPerson
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
            this.nameInput = new System.Windows.Forms.TextBox();
            this.email_Input = new System.Windows.Forms.TextBox();
            this.phoneInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.roleComboBox1 = new System.Windows.Forms.ComboBox();
            this.addButton = new System.Windows.Forms.Button();
            this.salary_label = new System.Windows.Forms.Label();
            this.salaryInput = new System.Windows.Forms.TextBox();
            this.cur_sub1_label = new System.Windows.Forms.Label();
            this.sub1Input = new System.Windows.Forms.TextBox();
            this.sub2Input = new System.Windows.Forms.TextBox();
            this.cur_sub2_label = new System.Windows.Forms.Label();
            this.preSubInput2 = new System.Windows.Forms.TextBox();
            this.pre_sub2_label = new System.Windows.Forms.Label();
            this.preSubInput1 = new System.Windows.Forms.TextBox();
            this.pre_sub1_label = new System.Windows.Forms.Label();
            this.sub2 = new System.Windows.Forms.Label();
            this.sub1 = new System.Windows.Forms.Label();
            this.workTime_label = new System.Windows.Forms.Label();
            this.emp_type_lablel = new System.Windows.Forms.Label();
            this.workTypeInput = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameInput
            // 
            this.nameInput.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameInput.Location = new System.Drawing.Point(213, 48);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(269, 31);
            this.nameInput.TabIndex = 0;
            // 
            // email_Input
            // 
            this.email_Input.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email_Input.Location = new System.Drawing.Point(690, 96);
            this.email_Input.Name = "email_Input";
            this.email_Input.Size = new System.Drawing.Size(269, 31);
            this.email_Input.TabIndex = 3;
            // 
            // phoneInput
            // 
            this.phoneInput.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneInput.Location = new System.Drawing.Point(690, 49);
            this.phoneInput.Name = "phoneInput";
            this.phoneInput.Size = new System.Drawing.Size(269, 31);
            this.phoneInput.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name*:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(488, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Telephone*:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(488, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Email*:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Role*:";
            // 
            // roleComboBox1
            // 
            this.roleComboBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.roleComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roleComboBox1.Font = new System.Drawing.Font("Cambria", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roleComboBox1.FormattingEnabled = true;
            this.roleComboBox1.Items.AddRange(new object[] {
            "Teacher",
            "Student",
            "Admin"});
            this.roleComboBox1.Location = new System.Drawing.Point(213, 99);
            this.roleComboBox1.Name = "roleComboBox1";
            this.roleComboBox1.Size = new System.Drawing.Size(269, 34);
            this.roleComboBox1.TabIndex = 2;
            this.roleComboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(440, 322);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(101, 35);
            this.addButton.TabIndex = 9;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addPerson_Click);
            // 
            // salary_label
            // 
            this.salary_label.AutoSize = true;
            this.salary_label.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salary_label.Location = new System.Drawing.Point(12, 160);
            this.salary_label.Name = "salary_label";
            this.salary_label.Size = new System.Drawing.Size(85, 25);
            this.salary_label.TabIndex = 9;
            this.salary_label.Text = "Salary*:";
            this.salary_label.Visible = false;
            // 
            // salaryInput
            // 
            this.salaryInput.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salaryInput.Location = new System.Drawing.Point(213, 152);
            this.salaryInput.Name = "salaryInput";
            this.salaryInput.Size = new System.Drawing.Size(269, 31);
            this.salaryInput.TabIndex = 4;
            this.salaryInput.Visible = false;
            // 
            // cur_sub1_label
            // 
            this.cur_sub1_label.AutoSize = true;
            this.cur_sub1_label.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cur_sub1_label.Location = new System.Drawing.Point(13, 212);
            this.cur_sub1_label.Name = "cur_sub1_label";
            this.cur_sub1_label.Size = new System.Drawing.Size(173, 25);
            this.cur_sub1_label.TabIndex = 11;
            this.cur_sub1_label.Text = "Current Subject 1:";
            this.cur_sub1_label.Visible = false;
            // 
            // sub1Input
            // 
            this.sub1Input.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sub1Input.Location = new System.Drawing.Point(213, 208);
            this.sub1Input.Name = "sub1Input";
            this.sub1Input.Size = new System.Drawing.Size(269, 31);
            this.sub1Input.TabIndex = 5;
            this.sub1Input.Visible = false;
            // 
            // sub2Input
            // 
            this.sub2Input.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sub2Input.Location = new System.Drawing.Point(690, 214);
            this.sub2Input.Name = "sub2Input";
            this.sub2Input.Size = new System.Drawing.Size(269, 31);
            this.sub2Input.TabIndex = 6;
            this.sub2Input.Visible = false;
            // 
            // cur_sub2_label
            // 
            this.cur_sub2_label.AutoSize = true;
            this.cur_sub2_label.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cur_sub2_label.Location = new System.Drawing.Point(489, 216);
            this.cur_sub2_label.Name = "cur_sub2_label";
            this.cur_sub2_label.Size = new System.Drawing.Size(173, 25);
            this.cur_sub2_label.TabIndex = 13;
            this.cur_sub2_label.Text = "Current Subject 2:";
            this.cur_sub2_label.Visible = false;
            // 
            // preSubInput2
            // 
            this.preSubInput2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.preSubInput2.Location = new System.Drawing.Point(690, 263);
            this.preSubInput2.Name = "preSubInput2";
            this.preSubInput2.Size = new System.Drawing.Size(269, 31);
            this.preSubInput2.TabIndex = 8;
            this.preSubInput2.Visible = false;
            // 
            // pre_sub2_label
            // 
            this.pre_sub2_label.AutoSize = true;
            this.pre_sub2_label.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pre_sub2_label.Location = new System.Drawing.Point(489, 265);
            this.pre_sub2_label.Name = "pre_sub2_label";
            this.pre_sub2_label.Size = new System.Drawing.Size(184, 25);
            this.pre_sub2_label.TabIndex = 17;
            this.pre_sub2_label.Text = "Previous Subject 2:";
            this.pre_sub2_label.Visible = false;
            // 
            // preSubInput1
            // 
            this.preSubInput1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.preSubInput1.Location = new System.Drawing.Point(213, 257);
            this.preSubInput1.Name = "preSubInput1";
            this.preSubInput1.Size = new System.Drawing.Size(269, 31);
            this.preSubInput1.TabIndex = 7;
            this.preSubInput1.Visible = false;
            // 
            // pre_sub1_label
            // 
            this.pre_sub1_label.AutoSize = true;
            this.pre_sub1_label.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pre_sub1_label.Location = new System.Drawing.Point(13, 261);
            this.pre_sub1_label.Name = "pre_sub1_label";
            this.pre_sub1_label.Size = new System.Drawing.Size(184, 25);
            this.pre_sub1_label.TabIndex = 15;
            this.pre_sub1_label.Text = "Previous Subject 1:";
            this.pre_sub1_label.Visible = false;
            // 
            // sub2
            // 
            this.sub2.AutoSize = true;
            this.sub2.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sub2.Location = new System.Drawing.Point(488, 216);
            this.sub2.Name = "sub2";
            this.sub2.Size = new System.Drawing.Size(101, 25);
            this.sub2.TabIndex = 20;
            this.sub2.Text = "Subject 2:";
            this.sub2.Visible = false;
            // 
            // sub1
            // 
            this.sub1.AutoSize = true;
            this.sub1.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sub1.Location = new System.Drawing.Point(12, 212);
            this.sub1.Name = "sub1";
            this.sub1.Size = new System.Drawing.Size(101, 25);
            this.sub1.TabIndex = 19;
            this.sub1.Text = "Subject 1:";
            this.sub1.Visible = false;
            // 
            // workTime_label
            // 
            this.workTime_label.AutoSize = true;
            this.workTime_label.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.workTime_label.Location = new System.Drawing.Point(489, 216);
            this.workTime_label.Name = "workTime_label";
            this.workTime_label.Size = new System.Drawing.Size(167, 25);
            this.workTime_label.TabIndex = 21;
            this.workTime_label.Text = "Working Hours*: ";
            this.workTime_label.Visible = false;
            // 
            // emp_type_lablel
            // 
            this.emp_type_lablel.AutoSize = true;
            this.emp_type_lablel.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emp_type_lablel.Location = new System.Drawing.Point(13, 212);
            this.emp_type_lablel.Name = "emp_type_lablel";
            this.emp_type_lablel.Size = new System.Drawing.Size(178, 25);
            this.emp_type_lablel.TabIndex = 22;
            this.emp_type_lablel.Text = "Employment Type:";
            this.emp_type_lablel.Visible = false;
            // 
            // workTypeInput
            // 
            this.workTypeInput.BackColor = System.Drawing.SystemColors.HighlightText;
            this.workTypeInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.workTypeInput.Font = new System.Drawing.Font("Cambria", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.workTypeInput.FormattingEnabled = true;
            this.workTypeInput.Items.AddRange(new object[] {
            "Full-time",
            "Part-time"});
            this.workTypeInput.Location = new System.Drawing.Point(213, 208);
            this.workTypeInput.Name = "workTypeInput";
            this.workTypeInput.Size = new System.Drawing.Size(269, 34);
            this.workTypeInput.TabIndex = 5;
            this.workTypeInput.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(694, 327);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(265, 26);
            this.label5.TabIndex = 23;
            this.label5.Text = "* indicates a required field.";
            // 
            // AddNewPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 369);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.workTypeInput);
            this.Controls.Add(this.emp_type_lablel);
            this.Controls.Add(this.workTime_label);
            this.Controls.Add(this.sub2);
            this.Controls.Add(this.sub1);
            this.Controls.Add(this.preSubInput2);
            this.Controls.Add(this.pre_sub2_label);
            this.Controls.Add(this.preSubInput1);
            this.Controls.Add(this.pre_sub1_label);
            this.Controls.Add(this.sub2Input);
            this.Controls.Add(this.cur_sub2_label);
            this.Controls.Add(this.sub1Input);
            this.Controls.Add(this.cur_sub1_label);
            this.Controls.Add(this.salaryInput);
            this.Controls.Add(this.salary_label);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.roleComboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.phoneInput);
            this.Controls.Add(this.email_Input);
            this.Controls.Add(this.nameInput);
            this.Name = "AddNewPerson";
            this.Text = "AddNewPerson";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.TextBox email_Input;
        private System.Windows.Forms.TextBox phoneInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox roleComboBox1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label salary_label;
        private System.Windows.Forms.TextBox salaryInput;
        private System.Windows.Forms.Label cur_sub1_label;
        private System.Windows.Forms.TextBox sub1Input;
        private System.Windows.Forms.TextBox sub2Input;
        private System.Windows.Forms.Label cur_sub2_label;
        private System.Windows.Forms.TextBox preSubInput2;
        private System.Windows.Forms.Label pre_sub2_label;
        private System.Windows.Forms.TextBox preSubInput1;
        private System.Windows.Forms.Label pre_sub1_label;
        private System.Windows.Forms.Label sub2;
        private System.Windows.Forms.Label sub1;
        private System.Windows.Forms.Label workTime_label;
        private System.Windows.Forms.Label emp_type_lablel;
        private System.Windows.Forms.ComboBox workTypeInput;
        private System.Windows.Forms.Label label5;
    }
}