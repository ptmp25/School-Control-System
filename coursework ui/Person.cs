using System;
using MySql.Data.MySqlClient;

namespace coursework_ui
{
    // Base class representing a person
    public class Person
    {
        // Auto-implemented property with private set accessor
        // Fully implemented property with private backing field
        public int Id { get; private set; } // Id of the person 
        public string Name { get; private set; } // Name of the person
        public string Telephone { get; private set; }  // Telephone number of the person
        public string Email { get; private set; } // Email of the person
        public string Role { get; private set; } // Role of the person(teacher, student, admin)

        // Constructor
        public Person(int id, string name, string telephone, string email, string role)
        {
            // Assign values using properties to ensure encapsulation
            Id = id;
            Name = name;
            Telephone = telephone;
            Email = email;
            Role = role;
        }
        // GetDetails method to include person-specific details
        public virtual string GetDetails()
        {
            return $"Name: {Name}\nTelephone: {Telephone}\nEmail: {Email}\nRole: {Role}";
        }
        // Read people data from the database and add it to the people list 
        public static void ReadPeople(MySqlConnection connection)
        {
            string peopleQuery = "SELECT * FROM people";
            using (MySqlCommand peopleCommand = new MySqlCommand(peopleQuery, connection))
            {
                using (MySqlDataReader peopleReader = peopleCommand.ExecuteReader())
                {
                    while (peopleReader.Read())
                    {
                        int id = Convert.ToInt32(peopleReader["people_ID"]);
                        string name = Convert.ToString(peopleReader["Name"]);
                        string telephone = Convert.ToString(peopleReader["Phone"]);
                        string email = Convert.ToString(peopleReader["Email"]);
                        string role = Convert.ToString(peopleReader["Role"]);

                        Person person = new Person(id, name, telephone, email, role);
                        Program.people.Add(person);
                    }
                }
            }
        }
        // Create the people table in the database if it doesn't exist already 
        public static void CreateTablePeople(MySqlConnection connection)
        {
            string tableQuery = @"
                CREATE TABLE IF NOT EXISTS people (
                people_id INT AUTO_INCREMENT PRIMARY KEY,
                name VARCHAR(255) NOT NULL,
                phone VARCHAR(15),
                email VARCHAR(255),
                role VARCHAR(50));
                ALTER TABLE `people`
                MODIFY people_id int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1;";
            using (MySqlCommand command = new MySqlCommand(tableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }
        // Insert a person into the database 
        internal static void InsertPerson(string name, string phone, string email, string role)
        {
            string insertQuery = "INSERT INTO people (name, phone, email, role) VALUES (@name, @phone, @email, @role)";
            using (MySqlConnection connection = new MySqlConnection(DatabaseManager.connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@name", name);
                        insertCommand.Parameters.AddWithValue("@phone", phone);
                        insertCommand.Parameters.AddWithValue("@email", email);
                        insertCommand.Parameters.AddWithValue("@role", role);
                        insertCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting person: {ex.Message}");
                }
            }
        }
        // Delete a person from the database 
        public static void DeletePerson(int id)
        {
            string deleteQuery = "DELETE FROM people WHERE people_id = @id";
            using (MySqlConnection connection = new MySqlConnection(DatabaseManager.connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@id", id);
                        deleteCommand.ExecuteNonQuery();
                    }
                    Program.people.RemoveAll(p => p.Id == id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting person: {ex.Message}");
                }
            }
        }
        // Update a person in the database 
        internal static void UpdatePerson(int id, string name, string phone, string email, string role)
        {
            string editQuery = "UPDATE people SET name = @name, phone = @phone, email = @email, role = @role WHERE people_id = @id";
            using (MySqlConnection connection = new MySqlConnection(DatabaseManager.connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand editCommand = new MySqlCommand(editQuery, connection))
                    {
                        editCommand.Parameters.AddWithValue("@id", id);
                        editCommand.Parameters.AddWithValue("@name", name);
                        editCommand.Parameters.AddWithValue("@phone", phone);
                        editCommand.Parameters.AddWithValue("@email", email);
                        editCommand.Parameters.AddWithValue("@role", role);
                        editCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error editing person: {ex.Message}");
                }
            }
        }
        // View all people in the 'people' list 
        public static void ViewPeople()
        {
            foreach (Person person in Program.people)
            {
                Console.WriteLine(person.GetDetails() + "\n");
            }
        }

        /// This method is used to view people based on their role.
        public static void ViewPeople(string role)
        {
            foreach (Person person in Program.people)
            {
                if (person.Role.ToLower() == role.ToLower())
                {
                    Console.WriteLine(person.GetDetails() + "\n");
                }
            }
        }
    }
}
