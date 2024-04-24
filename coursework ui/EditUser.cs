using System;
using System.Windows.Forms;

namespace coursework_ui
{
    // Form for editing user details 
    public partial class EditUser : Form
    {
        private string role;
        private int id;
        // Form for editing user details 
        public EditUser(Person person)
        {
            InitializeComponent();
            // Get the details of the person to be edited and display them in the form
            id = person.Id;
            string name = person.Name;
            nameInput.Text = name;

            string email = person.Email;
            email_Input.Text = email;

            string phone = person.Telephone;
            phoneInput.Text = phone;

            role = person.Role;
            // Switch statement to check the role of the person and display the relevant fields
            switch (role)
            {
                case "teacher":
                    Teacher teacher = (Teacher)person;
                    salary_label.Visible = true;
                    salaryInput.Visible = true;
                    salaryInput.Text = teacher.Salary.ToString();

                    sub1.Visible = true;
                    cur_sub1_label.Visible = false;
                    sub1Input.Visible = true;
                    sub1Input.Text = teacher.Subject1;

                    sub2.Visible = true;
                    cur_sub2_label.Visible = false;
                    sub2Input.Visible = true;
                    sub2Input.Text = teacher.Subject2;

                    pre_sub1_label.Visible = false;
                    pre_sub2_label.Visible = false;
                    preSubInput1.Visible = false;
                    preSubInput2.Visible = false;

                    emp_type_lablel.Visible = false;
                    workTime_label.Visible = false;
                    workTypeInput.Visible = false;
                    break;
                case "student":
                    Student student = (Student)person;
                    salary_label.Visible = false;
                    salaryInput.Visible = false;

                    sub1.Visible = false;
                    cur_sub1_label.Visible = true;
                    sub1Input.Visible = true;
                    sub1Input.Text = student.CurrentSubject1;

                    sub2.Visible = false;
                    cur_sub2_label.Visible = true;
                    sub2Input.Visible = true;
                    sub2Input.Text = student.CurrentSubject2;

                    pre_sub1_label.Visible = true;
                    pre_sub2_label.Visible = true;
                    preSubInput1.Visible = true;
                    preSubInput1.Text = student.PreviousSubject1;
                    preSubInput2.Visible = true;
                    preSubInput2.Text = student.PreviousSubject2;

                    emp_type_lablel.Visible = false;
                    workTime_label.Visible = false;
                    workTypeInput.Visible = false;
                    break;
                case "admin":
                    Admin admin = (Admin)person;
                    salary_label.Visible = true;
                    salaryInput.Visible = true;
                    salaryInput.Text = admin.Salary.ToString();

                    sub1.Visible = false;
                    cur_sub1_label.Visible = false;
                    sub1Input.Visible = false;

                    sub2.Visible = false;
                    cur_sub2_label.Visible = false;
                    workTime_label.Visible = true;
                    sub2Input.Visible = true;
                    sub2Input.Text = admin.WorkingHours.ToString();

                    pre_sub1_label.Visible = false;
                    pre_sub2_label.Visible = false;
                    preSubInput1.Visible = false;
                    preSubInput2.Visible = false;

                    emp_type_lablel.Visible = true;
                    workTypeInput.Visible = true;
                    workTypeInput.Text = admin.FullTime;
                    break;
            }
        }
        // Save the edited details
        private void saveButton_Click(object sender, EventArgs e)
        {
            // Check if all the fields are filled
            if (nameInput.Text == "" || email_Input.Text == "" || phoneInput.Text == "")
            {
                MessageBox.Show("Please fill in all the required fields");
                return;
            }
            string name = nameInput.Text;
            string email = email_Input.Text;
            string phone = phoneInput.Text;
            if (role == "teacher")
            {
                // Check if the salary is a valid number
                if (!decimal.TryParse(salaryInput.Text, out decimal salary) || salary < 0)
                {
                    MessageBox.Show("Please input your salary amount (positive value only).");
                    return;
                }
                Teacher.EditTeacher(id, name, phone, email, Convert.ToDecimal(salaryInput.Text), sub1Input.Text, sub2Input.Text);
            }
            else if (role == "student")
            {
                Student.EditStudent(id, name, phone, email, sub1Input.Text, sub2Input.Text, preSubInput1.Text, preSubInput2.Text);
            }
            else if (role == "admin")
            {
                // Check if the salary and working hours are valid numbers
                if (!decimal.TryParse(salaryInput.Text, out decimal salary) || salary < 0)
                {
                    MessageBox.Show("Please input your salary amount (positive value only).");
                    return;
                }
                if (!int.TryParse(sub2Input.Text, out int workTime) || workTime < 0)
                {
                    MessageBox.Show("Please input the number of working each day (positive whole numbers only).");
                    return;
                }
                Admin.EditAdmin(id, name, phone, email, Convert.ToDecimal(salaryInput.Text), workTypeInput.Text, Convert.ToInt32(sub2Input.Text));
            }
            MessageBox.Show("Edit Successful.");
            this.Close();
        }
    }
}
