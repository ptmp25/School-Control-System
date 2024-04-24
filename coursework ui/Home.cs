using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace coursework_ui
{
    // Home form to display all users and allow CRUD operations
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            viewAllUser();
        }
        // Load all users from the database and display them in the DataGridView
        private void viewAllUser()
        {
            DatabaseManager.LoadData();
            Program.ProcessPeople();
            dataGridView1.DataSource = Program.people;
            dataGridView1.Refresh();
            roleComboBox1.SelectedIndex = 0;
        }

        // Load data from the database
        private void loadData_Click(object sender, EventArgs e)
        {
            viewAllUser();
        }
        // Open the AddNewPerson form to add a new person to the database
        private void addPerson_Click(object sender, EventArgs e)
        {
            AddNewPerson form = new AddNewPerson();
            form.ShowDialog(); 
            viewAllUser();
        }
        // Delete the selected user(s) from the database
        private void deleteUser(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Ask for confirmation
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected row(s)?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Get the list of rows is chosen from the DataGridView
                    List<DataGridViewRow> rows = new List<DataGridViewRow>();
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        int id = (int)row.Cells["ID"].Value;
                        // Delete the person from the database
                        Person.DeletePerson(id);
                    }
                    dataGridView1.DataSource = null;
                    // Refresh the DataGridView to show the updated list of people
                    dataGridView1.DataSource = Program.people;
                    MessageBox.Show("Delete Successful.");
                }
            }
            else
            {
                // If no row is selected, show a message
                MessageBox.Show("No rows were selected. Please select a row to delete.\nBy choosing first cell of row");
            }
        }
        // Open the ViewGroup form to view all users in a specific role group 
        private void viewGroup(object sender, EventArgs e)
        {
            if (roleComboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please choose the role");
                return;
            }
            // Get the selected role from the ComboBox
            string role = roleComboBox1.SelectedItem.ToString();
            searchBox.Text = "";
            switch (role)
            {
                case "Teacher":
                    // Get all teachers from the list of people and display them in the DataGridView
                    List<Teacher> teachers = new List<Teacher>();
                    for (int i = 0; i < Program.people.Count; i++)
                    {
                        if (Program.people[i] is Teacher)
                        {
                            Teacher teacher = (Teacher)Program.people[i];
                            teachers.Add(teacher);
                        }
                    }
                    dataGridView1.DataSource = teachers;
                    dataGridView1.Refresh();
                    break;
                case "Admin":
                    // Get all admins from the list of people and display them in the DataGridView
                    List<Admin> admins = new List<Admin>();
                    for (int i = 0; i < Program.people.Count; i++)
                    {
                        if (Program.people[i] is Admin)
                        {
                            Admin admin = (Admin)Program.people[i];
                            admins.Add(admin);
                        }
                    }
                    dataGridView1.DataSource = admins;
                    dataGridView1.Refresh();
                    break;
                case "Student":
                    // Get all students from the list of people and display them in the DataGridView
                    List<Student> students = new List<Student>();
                    for (int i = 0; i < Program.people.Count; i++)
                    {
                        if (Program.people[i] is Student)
                        {
                            Student student = (Student)Program.people[i];
                            students.Add(student);
                        }
                    }
                    dataGridView1.DataSource = students;
                    dataGridView1.Refresh();
                    break;
                case "All":
                    // Display all users in the DataGridView if "All" is selected
                    dataGridView1.DataSource = Program.people;
                    dataGridView1.Refresh();
                    break;
            }
        
        }
        // Open the EditUser form to edit the selected user from the DataGridView
        private void EditUser(object sender, EventArgs e)
        {
            // Check if only one row is selected to edit
            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Select only row only!");
            } else if (dataGridView1.SelectedRows.Count == 1)
            {
                // Get the selected person from the DataGridView
                var person = (Person)dataGridView1.SelectedRows[0].DataBoundItem;
                EditUser form = new EditUser(person);
                // Open the EditUser form with the selected person
                form.ShowDialog(); 
                viewAllUser();
            }
            else
            {
                // If no row is selected, show a message
                MessageBox.Show("No row were selected. Please select a row to edit.\nBy choosing first cell of row");
            }
        }

        // Search for the person with the name that contains the text in the search box
        private List<T> search<T>() where T : Person
        {
            List<T> people = new List<T>();
            for (int i = 0; i < Program.people.Count; i++)
            {
                // Check if the person is of the type T and the name contains the text in the search box
                if (Program.people[i] is T && Program.people[i].Name.ToLower().Contains(searchBox.Text.ToLower()))
                {
                    people.Add((T)Program.people[i]);
                }
            }
            // Return the list of people that match the search criteria
            return people;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            // If the search box is empty, display all users
            if (searchBox.Text == "")
            {
                viewGroup(sender, e);
            }
            else
            {
                // Get the selected role from the ComboBox
                if (roleComboBox1.Text == "All")
                {
                    dataGridView1.DataSource = search<Person>();
                }
                else if (roleComboBox1.Text == "Teacher")
                {
                    dataGridView1.DataSource = search<Teacher>();
                }
                else if (roleComboBox1.Text == "Admin")
                {
                    dataGridView1.DataSource = search<Admin>();
                }
                else if (roleComboBox1.Text == "Student")
                {
                    dataGridView1.DataSource = search<Student>();
                }
                dataGridView1.Refresh();
            }
        }
        // Search for the person when the Enter key is pressed in the search box
        private void searchBox_keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchButton_Click(sender, e);
            }
        }
    }
}
