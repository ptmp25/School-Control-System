using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace coursework_ui
{
    public class DatabaseManager
    {
        // Connection string to connect to the database
        public const string connectionString = "server=localhost;user id=root;password=;database=school_system";
        // Constructor to test the database connection
        public DatabaseManager() {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Database connection test successful");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        // Check if a table exists in the database
        public static bool TableExists(MySqlConnection connection, string tableName)
        {
            using (MySqlCommand command = new MySqlCommand($"SHOW TABLES LIKE '{tableName}'", connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }
        // Load data from the database
        public static void LoadData()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                // Check if the people table exists in the database
                if (TableExists(connection, "people"))
                {
                    Program.people = new List<Person>();
                    Person.ReadPeople(connection);
                }
                else
                    Person.CreateTablePeople(connection);
                // Check if the teacher table exists in the database and create it if it doesn't
                if (!TableExists(connection, "teacher"))
                {
                    Teacher.CreateTableTeacher(connection);
                }
                // Check if the student table exists in the database and create it if it doesn't
                if (!TableExists(connection, "student"))
                {
                    Student.CreateTableStudent(connection);
                }
                // Check if the admin table exists in the database and create it if it doesn't
                if (!TableExists(connection, "admin"))
                {
                    Admin.CreateTableAdmin(connection);
                }
                connection.Close();
            }
        }
        // Get the last inserted id from the database
        public static int GetLastInsertedId()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand("SELECT max(people_id) from People;", connection))
                {
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }
    }
}
