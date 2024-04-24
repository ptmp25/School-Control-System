using System;
using MySql.Data.MySqlClient;

namespace coursework_ui
{
    // Derived class for administration staff
    public class Admin : Person
    {
        // Auto-implemented property with private set accessor
        public decimal Salary { get; private set; }
        public string FullTime { get; private set; }
        public int WorkingHours { get; private set; }

        // Constructor
        public Admin(int id, string name, string telephone, string email, string role, decimal salary, string fullTime, int workingHours)
            : base(id, name, telephone, email, "admin")
        {
            // Assign values using properties to ensure encapsulation
            Salary = salary;
            FullTime = fullTime;
            WorkingHours = workingHours;
        }

        // Override GetDetails method to include admin-specific details
        public override string GetDetails()
        {
            return base.GetDetails() + $"\nSalary: {Salary:C}\nFull-time: {FullTime}\nWorking Hours: {WorkingHours}";
        }
        // Create the admin table in the database if it doesn't exist already
        public static void CreateTableAdmin(MySqlConnection connection)
        {
            string tableQuery = @"
            CREATE TABLE `admin` (
                `id` INT AUTO_INCREMENT PRIMARY KEY,
                `people_id` INT NOT NULL,
                `salary` decimal(10,2) DEFAULT NULL,
                `employment_type` varchar(100) DEFAULT NULL,
                `working_hours` int(11) DEFAULT NULL
            ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
            ALTER TABLE `admin`
            ADD CONSTRAINT `admin_ibfk_1` FOREIGN KEY (`people_id`) REFERENCES `people` (`people_id`) ON DELETE CASCADE;";
            using (MySqlCommand command = new MySqlCommand(tableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }
        // Read admin data from the database and create an admin object
        public static void ReadAdmin(ref Person person)
        {
            using (MySqlConnection connection = new MySqlConnection(DatabaseManager.connectionString))
            {
                try
                {
                    connection.Open();
                    if (DatabaseManager.TableExists(connection, "admin"))
                    {
                        string adminQuery = "SELECT * FROM admin WHERE people_id = @id";
                        using (MySqlCommand adminCommand = new MySqlCommand(adminQuery, connection))
                        {
                            adminCommand.Parameters.AddWithValue("@id", person.Id);

                            using (MySqlDataReader adminReader = adminCommand.ExecuteReader())
                            {
                                if (adminReader.Read())
                                {
                                    decimal salary = Convert.ToDecimal(adminReader["Salary"]);
                                    string fullTime = Convert.ToString(adminReader["employment_type"]);
                                    int workingHours = Convert.ToInt32(adminReader["Working_Hours"]);
                                    person = new Admin(person.Id, person.Name, person.Telephone, person.Email, person.Role, salary, fullTime, workingHours);
                                    return;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading admin data: {ex.Message}");
                }
            }
            person = new Admin(person.Id, person.Name, person.Telephone, person.Email, person.Role, 0, "", 0);
        }
        // Insert an admin into the database
        private static void InsertAdmin(int id, decimal salary, string fullTime, int workingHours)
        {
            using (MySqlConnection connection = new MySqlConnection(DatabaseManager.connectionString))
            {
                try
                {
                    connection.Open();
                    string adminQuery = "INSERT INTO admin (people_id, salary, employment_type, working_hours) VALUES (@id, @salary, @fullTime, @workingHours)";
                    using (MySqlCommand adminCommand = new MySqlCommand(adminQuery, connection))
                    {
                        adminCommand.Parameters.AddWithValue("@id", id);
                        adminCommand.Parameters.AddWithValue("@salary", salary);
                        adminCommand.Parameters.AddWithValue("@fullTime", fullTime);
                        adminCommand.Parameters.AddWithValue("@workingHours", workingHours);
                        adminCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting admin: {ex.Message}");
                }
            }
        }

        // Add an admin to the database
        public static void AddAdmin(string name, string phone, string email, string role, decimal salary, string fullTime, int workingHours)
        {
            InsertPerson(name, phone, email, role);
            int id = DatabaseManager.GetLastInsertedId();
            Program.people.Add(new Admin(id, name, phone, email, role, salary, fullTime, workingHours));
            InsertAdmin(id, salary, fullTime, workingHours);
        }
        // Update an admin in the database
        private static void UpdateAdmin(int id, decimal salary, string fullTime, int workingHours)
        {
            using (MySqlConnection connection = new MySqlConnection(DatabaseManager.connectionString))
            {
                try
                {
                    connection.Open();
                    string updateQuery = "UPDATE admin SET salary = @salary, employment_type = @fullTime, working_hours = @workingHours WHERE people_id = @id";
                    using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@id", id);
                        updateCommand.Parameters.AddWithValue("@salary", salary);
                        updateCommand.Parameters.AddWithValue("@fullTime", fullTime);
                        updateCommand.Parameters.AddWithValue("@workingHours", workingHours);
                        updateCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating admin: {ex.Message}");
                }
            }
        }
        // Edit an admin in the database
        public static void EditAdmin(int id, string name, string phone, string email, decimal salary, string fullTime, int workingHours)
        {
            UpdatePerson(id, name, phone, email, "admin");
            UpdateAdmin(id, salary, fullTime, workingHours);
        }
    }
}
