using System;
using System.Windows.Forms;

namespace coursework_ui
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // Check if the username and password are correct
            if (usernameInput.Text == "admin" && usernameInput.Text == "admin")
            {
                this.Hide();
                Home home = new Home();
                home.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }
    }
}
