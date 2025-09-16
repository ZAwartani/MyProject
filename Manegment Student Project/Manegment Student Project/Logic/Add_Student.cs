using Manegment_Student_Project.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manegment_Student_Project.Logic
{
    public class Add_Student : DataAccess.Connection_For_AddStudent
    {
        public struct student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public char Gender { get; set; } // M , F
            public string DateOfBirth { get; set; }
            public string phone { get; set; }
        }

        public string Query;

        public void AddStudent_NonQuery(student student)
        {
            Query = "INSERT INTO Students (FirstName, LastName, Gender, DateOfBirth, Phone) " +
                    "VALUES (@FirstName , @LastName , @Gender , @DateOfBirth , @Phone)";
            Add_Student_ExecuteQuery(Query, student);
        }
        public void addStudent()
        {
            Console.WriteLine("Can Now Enter Information About Student : ");
            char exitOrNot = 'Y';
            while (exitOrNot != 'N')
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("NOTE : IF YOU WANT TO EXIT FROM ADD STUDENT ENTER 'N' ");
                Console.ResetColor();
                Console.Write("First Name : ");
                string firstName = Console.ReadLine();
                Console.Write("Last Name : ");
                string lastName = Console.ReadLine();
                Console.WriteLine("Gender : (M , F)");
                char gender = Convert.ToChar(Console.ReadLine());
                Console.WriteLine("Enter Birth Day : (YYYY-MM-DD) ");
                string dateOfBirth = Console.ReadLine();
                Console.WriteLine("Enter Phone Number : (Less Than 12) ");
                string Phone = Console.ReadLine();
                student student1 = new student
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Gender = gender,
                    DateOfBirth = dateOfBirth,
                    phone = Phone
                };
                AddStudent_NonQuery(student1);
                Console.WriteLine("Do You Want To Add Another Student ? (Y / N) ");
                exitOrNot = Char.Parse(Console.ReadLine().ToUpper());
            }
        }
    }
}
