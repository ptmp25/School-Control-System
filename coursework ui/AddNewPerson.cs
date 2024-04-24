using System;
using System.Windows.Forms;

namespace coursework_ui
{
    // Form for adding new person to the system
    public partial class AddNewPerson : Form
    {
        public AddNewPerson()
        {
            InitializeComponent();
        }
        // Method for adding new person to the system
        private void addPerson_Click(object sender, EventArgs e)
        {
            if (roleComboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please choose the role");
                return;
            }
            if (nameInput.Text == "" || email_Input.Text == "" || phoneInput.Text == "")
            {
                MessageBox.Show("Please fill in all the required fields");
                return;
            }
            string role = roleComboBox1.SelectedItem.ToString().ToLower();
            // Switch statement to check the role of the person and add them to the system
            switch (role)
            {
                case "":
                    MessageBox.Show("Please select a role");
                    break;
                case "teacher":
                    // Check if the salary is a valid number
                    if (!decimal.TryParse(salaryInput.Text, out decimal salary) || salary < 0)
                    {
                        MessageBox.Show("Please input your salary amount (positive value only).");
                        return;
                    }
                    string name = nameInput.Text;
                    string email = email_Input.Text;
                    string phone = phoneInput.Text;
                    salary = Convert.ToDecimal(salaryInput.Text);
                    string sub1 = sub1Input.Text;
                    string sub2 = sub2Input.Text;
                    Teacher.AddTeacher(name, email, phone, role, salary, sub1, sub2);
                    MessageBox.Show("Added new teacher");
                    this.Close();
                    break;
                case "student":
                    name = nameInput.Text;
                    email = email_Input.Text;
                    phone = phoneInput.Text;
                    string preSub1 = preSubInput1.Text;
                    string preSub2 = preSubInput2.Text;
                    sub1 = sub1Input.Text;
                    sub2 = sub2Input.Text;
                    Student.AddStudent(name, email, phone, role, sub1, sub2, preSub1, preSub2);
                    MessageBox.Show("Added new student");
                    this.Close();
                    break;
                case "admin":
                    if (!decimal.TryParse(salaryInput.Text, out decimal salary2) || salary2 < 0)
                    {
                        MessageBox.Show("Please input your salary amount (positive value only).");
                        return;
                    }
                    if (!int.TryParse(sub2Input.Text, out int workTime) || workTime < 0)
                    {
                        MessageBox.Show("Please input the number of working each day (positive whole numbers only).");
                        return;
                    }
                    name = nameInput.Text;
                    email = email_Input.Text;
                    phone = phoneInput.Text;
                    salary2 = Convert.ToDecimal(salaryInput.Text);
                    string workType = workTypeInput.Text;
                    Admin.AddAdmin(name, email, phone, role, salary2, workType, workTime);
                    MessageBox.Show("Add new admin");
                    this.Close();
                    break;
            }
        }
        // Show the relevant fields based on the role selected in the comboBox
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (roleComboBox1.SelectedItem.ToString())
            {
                case "Teacher":
                    salary_label.Visible = true;
                    salaryInput.Visible = true;

                    sub1.Visible = true;
                    cur_sub1_label.Visible = false;
                    sub1Input.Visible = true;

                    sub2.Visible = true;
                    cur_sub2_label.Visible = false;
                    sub2Input.Visible = true;

                    pre_sub1_label.Visible = false;
                    pre_sub2_label.Visible = false;
                    preSubInput1.Visible = false;
                    preSubInput2.Visible = false;

                    emp_type_lablel.Visible = false;
                    workTime_label.Visible = false;
                    workTypeInput.Visible = false;
                    break;
                case "Student":
                    salary_label.Visible = false;
                    salaryInput.Visible = false;

                    sub1.Visible = false;
                    cur_sub1_label.Visible = true;
                    sub1Input.Visible = true;

                    sub2.Visible = false;
                    cur_sub2_label.Visible = true;
                    sub2Input.Visible = true;

                    pre_sub1_label.Visible = true;
                    pre_sub2_label.Visible = true;
                    preSubInput1.Visible = true;
                    preSubInput2.Visible = true;

                    emp_type_lablel.Visible = false;
                    workTime_label.Visible = false;
                    workTypeInput.Visible = false;
                    break;
                case "Admin":
                    salary_label.Visible = true;
                    salaryInput.Visible = true;

                    sub1.Visible = false;
                    cur_sub1_label.Visible = false;
                    sub1Input.Visible = false;

                    sub2.Visible = false;
                    cur_sub2_label.Visible = false;
                    workTime_label.Visible = true;
                    sub2Input.Visible = true;

                    pre_sub1_label.Visible = false;
                    pre_sub2_label.Visible = false;
                    preSubInput1.Visible = false;
                    preSubInput2.Visible = false;

                    emp_type_lablel.Visible = true;
                    workTypeInput.Visible = true;
                    break;
            }
        }
    }
}
