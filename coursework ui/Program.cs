using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace coursework_ui
{
    internal static class Program
    {
        // Create a list of people to store all the people in the database
        public static List<Person> people = new List<Person>();
        // Process each person in the list of people to determine their role and read their data
        public static void ProcessPeople()
        {
            for (int i = 0; i < people.Count; i++)
            {
                Person person = people[i];
                switch (person.Role.ToLower())
                {
                    case "teacher":
                        Teacher.ReadTeacher(ref person);
                        break;
                    case "student":
                        Student.ReadStudent(ref person);
                        break;
                    case "admin":
                        Admin.ReadAdmin(ref person);
                        break;
                }
                people[i] = person;
                // Console.WriteLine(person.GetDetails() + "\n");
            }
        }
        /// The main entry point for the application.
        [STAThread]
        static void Main()
        {
            DatabaseManager databaseManager = new DatabaseManager();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
