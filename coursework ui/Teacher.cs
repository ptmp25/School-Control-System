using System;
using MySql.Data.MySqlClient;

namespace coursework_ui
{
    // Derived class for teaching staff
    public class Teacher : Person
    {
        // Auto-implemented property with private set accessor
        public decimal Salary { get; private set; }

        // Fully implemented property with private backing field
        public string Subject1 { get; private set; }
        // Fully implemented property with private backing field
        public string Subject2 { get; private set; }
        // Constructor
        public Teacher(int id, string name, string telephone, string email, string role, decimal salary, string subject1, string subject2)
            : base(id, name, telephone, email, "teacher")
        {
            // Assign values using properties to ensure encapsulation
            Salary = salary;
            Subject1 = subject1;
            Subject2 = subject2;
        }
        // Override GetDetails method to include teacher-specific details
        public override string GetDetails()
        {
            return base.GetDetails() + $"\nSalary: {Salary:C}\nSubjects: {Subject1}, {Subject2}";
        }
        // Create teacher table in the database with foreign key constraint to people table and cascade delete
        public static void CreateTableTeacher(MySqlConnection connection)
        {
            string tableQuery = @"
            CREATE TABLE `teacher` (
                `people_id` int(11) NOT NULL,
                `id` INT AUTO_INCREMENT PRIMARY KEY,
                `salary` decimal(10,2) DEFAULT NULL,
                `subject1` varchar(100) DEFAULT NULL,
                `subject2` varchar(100) DEFAULT NULL
            ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
            
            ALTER TABLE `teacher`
            ADD CONSTRAINT `teacher_ibfk_1` FOREIGN KEY (`people_id`) REFERENCES `people` (`people_id`) ON DELETE CASCADE;
            ";
            using (MySqlCommand command = new MySqlCommand(tableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }
        // Read teacher data from the database and assign it to the person object passed by reference
        public static void ReadTeacher(ref Person person)
        {
            using (MySqlConnection connection = new MySqlConnection(DatabaseManager.connectionString))
            {
                try
                {
                    connection.Open();
                    if (DatabaseManager.TableExists(connection, "teacher"))
                    {
                        string teacherQuery = "SELECT * FROM teacher WHERE people_id = @id";
                        using (MySqlCommand teacherCommand = new MySqlCommand(teacherQuery, connection))
                        {
                            teacherCommand.Parameters.AddWithValue("@id", person.Id);

                            using (MySqlDataReader teacherReader = teacherCommand.ExecuteReader())
                            {
                                if (teacherReader.Read())
                                {
                                    decimal salary = Convert.ToDecimal(teacherReader["Salary"]);
                                    string subject1 = Convert.ToString(teacherReader["Subject1"]);
                                    string subject2 = Convert.ToString(teacherReader["Subject2"]);
                                    person = new Teacher(person.Id, person.Name, person.Telephone, person.Email, person.Role, salary, subject1, subject2);
                                    return;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading teacher data: {ex.Message}");
                }
            }
            person = new Teacher(person.Id, person.Name, person.Telephone, person.Email, person.Role, 0, "", "");
        }
        // Insert teacher data into the database using the person id as a foreign key constraint to the people table
        private static void InsertTeacher(int id, decimal salary, string subject1, string subject2)
        {
            using (MySqlConnection connection = new MySqlConnection(DatabaseManager.connectionString))
            {
                try
                {
                    connection.Open();
                    string teacherQuery = "INSERT INTO teacher (people_id, salary, subject1, subject2) VALUES (@id, @salary, @subject1, @subject2)";
                    using (MySqlCommand teacherCommand = new MySqlCommand(teacherQuery, connection))
                    {
                        teacherCommand.Parameters.AddWithValue("@id", id);
                        teacherCommand.Parameters.AddWithValue("@salary", salary);
                        teacherCommand.Parameters.AddWithValue("@subject1", subject1);
                        teacherCommand.Parameters.AddWithValue("@subject2", subject2);
                        teacherCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting teacher data: {ex.Message}");
                }
            }
        }
        // Update teacher data in the database using the person id as a foreign key constraint to the people table 
        private static void UpdateTeacher(int id, decimal salary, string subject1, string subject2)
        {
            using (MySqlConnection connection = new MySqlConnection(DatabaseManager.connectionString))
            {
                try
                {
                    connection.Open();
                    string teacherQuery = "UPDATE teacher SET salary = @salary, subject1 = @subject1, subject2 = @subject2 WHERE people_id = @id";
                    using (MySqlCommand teacherCommand = new MySqlCommand(teacherQuery, connection))
                    {
                        teacherCommand.Parameters.AddWithValue("@id", id);
                        teacherCommand.Parameters.AddWithValue("@salary", salary);
                        teacherCommand.Parameters.AddWithValue("@subject1", subject1);
                        teacherCommand.Parameters.AddWithValue("@subject2", subject2);
                        teacherCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating teacher data: {ex.Message}");
                }
            }
        }
        // Insert teacher data from the database using the person id as a foreign key constraint to the people table
        public static void AddTeacher(string name, string phone, string email, string role, decimal salary, string subject1, string subject2)
        {
            InsertPerson(name, phone, email, role);
            int id = DatabaseManager.GetLastInsertedId();
            Program.people.Add(new Teacher(id, name, phone, email, "teacher", salary, subject1, subject2));
            InsertTeacher(id, salary, subject1, subject2);
        }
        // Edit teacher data in the database using the person id as a foreign key constraint to the people table
        public static void EditTeacher(int id, string name, string phone, string email, decimal salary, string subject1, string subject2)
        {
            UpdateTeacher(id, salary, subject1, subject2);
            UpdatePerson(id, name, phone, email, "teacher");
        }
    }
}
