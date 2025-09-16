using Manegment_Student_Project.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manegment_Student_Project.Logic
{
    public class Add_Teacher : Connection_For_AddTeacher
    {
        public struct Teacher 
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string HireDate { get; set; }
        }

        String Query;

        public void AddTeacher_NonQuery(Teacher teacher)
        {
            Query = "INSERT INTO Teachers (FirstName, LastName, Email, Phone, HireDate) " +
                    "VALUES (@FirstName , @LastName , @Email , @Phone, @HireDate)";
            add_teacher_ExecuteQuery(Query, teacher);
        }
        public void addTeacher()
        {
            Console.WriteLine("Can Now Enter Information About Teacher: ");
            char exitOrNot = 'Y';
            while (exitOrNot != 'N')
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("NOTE : IF YOU WANT TO EXIT FROM ADD TEACHER ENTER 'N' ");
                Console.ResetColor();
                Console.Write("First Name : ");
                string firstName = Console.ReadLine();
                Console.Write("Last Name : ");
                string lastName = Console.ReadLine();
                Console.WriteLine("Email : ");
                String email = Console.ReadLine();
                Console.WriteLine("Enter Phone Number : (Less Than 12) ");
                string Phone = Console.ReadLine();
                Console.WriteLine("Enter Hire Date : (YYYY-MM-DD) ");
                string dateOfBirth = Console.ReadLine();
                Teacher teacher = new Teacher
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    HireDate = dateOfBirth,
                    Phone = Phone
                };
                AddTeacher_NonQuery(teacher);
                Console.WriteLine("Do You Want To Add Another Teacher ? (Y / N) ");
                exitOrNot = Char.Parse(Console.ReadLine().ToUpper());
            }
        }
    }
}
