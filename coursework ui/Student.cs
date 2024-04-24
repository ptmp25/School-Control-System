using System;
using MySql.Data.MySqlClient;

namespace coursework_ui
{
    // Derived class representing a student
    public class Student : Person
    {
        // Private backing fields
        // Fully implemented property with private backing field
        public string CurrentSubject1 { get; private set; }
        public string CurrentSubject2 { get; private set; }
        public string PreviousSubject1 { get; private set; }
        public string PreviousSubject2 { get; private set; }

        // Constructor
        public Student(int id, string name, string telephone, string email, string role, string currentSubject1, string currentSubject2, string previousSubject1, string previousSubject2)
            : base(id, name, telephone, email, "student")
        {
            // Assign values using properties to ensure encapsulation
            CurrentSubject1 = currentSubject1;
            CurrentSubject2 = currentSubject2;
            PreviousSubject1 = previousSubject1;
            PreviousSubject2 = previousSubject2;
        }

        // Override GetDetails method to include student-specific details
        public override string GetDetails()
        {
            return base.GetDetails() + $"\nCurrent Subjects: {CurrentSubject1}, {CurrentSubject2}"
                + $"\n Previous Subjects: {PreviousSubject1}, {PreviousSubject2}";
        }
        // Create the student table in the database if it doesn't exist already
        public static void CreateTableStudent(MySqlConnection connection)
        {
            string tableQuery = @"
            CREATE TABLE `student` (
                `people_id` int(11) NOT NULL,
                `id` INT AUTO_INCREMENT PRIMARY KEY,
                `current_subject1` varchar(100) DEFAULT NULL,
                `current_subject2` varchar(100) DEFAULT NULL,
                `previous_subject1` varchar(100) DEFAULT NULL,
                `previous_subject2` varchar(100) DEFAULT NULL                
            ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
            ALTER TABLE `student`
            ADD CONSTRAINT `student_ibfk_1` FOREIGN KEY (`people_id`) REFERENCES `people` (`people_id`) ON DELETE CASCADE;
            ";
            using (MySqlCommand command = new MySqlCommand(tableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }
        // Read student data from the database and create a student object
        public static void ReadStudent(ref Person person)
        {
            using (MySqlConnection connection = new MySqlConnection(DatabaseManager.connectionString))
            {
                try
                {
                    connection.Open();
                    if (DatabaseManager.TableExists(connection, "student"))
                    {
                        string studentQuery = "SELECT * FROM student WHERE people_id = @id";
                        using (MySqlCommand studentCommand = new MySqlCommand(studentQuery, connection))
                        {
                            studentCommand.Parameters.AddWithValue("@id", person.Id);

                            using (MySqlDataReader studentReader = studentCommand.ExecuteReader())
                            {
                                if (studentReader.Read())
                                {
                                    string currentSubject1 = Convert.ToString(studentReader["Current_Subject1"]);
                                    string currentSubject2 = Convert.ToString(studentReader["Current_Subject2"]);
                                    string previousSubject1 = Convert.ToString(studentReader["Previous_Subject1"]);
                                    string previousSubject2 = Convert.ToString(studentReader["Previous_Subject2"]);
                                    person = new Student(person.Id, person.Name, person.Telephone, person.Email, person.Role, currentSubject1, currentSubject2, previousSubject1, previousSubject2);
                                    return;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading student data: {ex.Message}");
                }
                    person = new Student(person.Id, person.Name, person.Telephone, person.Email, person.Role, "", "", "", "");
            }
        }
        // Insert student data into the database
        private static void InsertStudent(int id, string currentSubject1, string currentSubject2, string previousSubject1, string previousSubject2)
        {
            using (MySqlConnection connection = new MySqlConnection(DatabaseManager.connectionString))
            {
                try
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO student (people_id, current_subject1, current_subject2, previous_subject1, previous_subject2) VALUES (@id, @current_subject1, @current_subject2, @previous_subject1, @previous_subject2)";
                    using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@current_subject1", currentSubject1);
                        command.Parameters.AddWithValue("@current_subject2", currentSubject2);
                        command.Parameters.AddWithValue("@previous_subject1", previousSubject1);
                        command.Parameters.AddWithValue("@previous_subject2", previousSubject2);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting student data: {ex.Message}");
                }
            }
        }
        // Add a student to the database and the people list in the program
        public static void AddStudent(string name, string telephone, string email, string role, string currentSubject1, string currentSubject2, string previousSubject1, string previousSubject2)
        {
            InsertPerson(name, telephone, email, role);
            int id = DatabaseManager.GetLastInsertedId();
            Program.people.Add(new Student(id, name, telephone, email, role, currentSubject1, currentSubject2, previousSubject1, previousSubject2));
            InsertStudent(id, currentSubject1, currentSubject2, previousSubject1, previousSubject2);
        }
        // Update student data in the database when a student's data is edited
        private static void UpdateStudent(int id, string currentSubject1, string currentSubject2, string previousSubject1, string previousSubject2)
        {
            using (MySqlConnection connection = new MySqlConnection(DatabaseManager.connectionString))
            {
                try
                {
                    connection.Open();
                    string updateQuery = "UPDATE student SET current_subject1 = @currentSubject1, current_subject2 = @currentSubject2, previous_subject1 = @previousSubject1, previous_subject2 = @previousSubject2 WHERE people_id = @id";
                    using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@currentSubject1", currentSubject1);
                        command.Parameters.AddWithValue("@currentSubject2", currentSubject2);
                        command.Parameters.AddWithValue("@previousSubject1", previousSubject1);
                        command.Parameters.AddWithValue("@previousSubject2", previousSubject2);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating student data: {ex.Message}");
                }
            }
        }
        // Edit a student's data in the database and the people list in the program
        public static void EditStudent(int id, string name, string telephone, string email, string currentSubject1, string currentSubject2, string previousSubject1, string previousSubject2)
        {
            UpdateStudent(id, currentSubject1, currentSubject2, previousSubject1, previousSubject2);
            UpdatePerson(id, name, telephone, email, "student");
        }
    }
}
