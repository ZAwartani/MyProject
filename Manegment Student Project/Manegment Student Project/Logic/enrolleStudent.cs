using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manegment_Student_Project.Logic
{
    public class enrolleStudent : DataAccess.Connection_For_EnrolleStudent
    {
        public struct Enrollment
        {
            public int StudentId { get; set; }
            public int CourseID { get; set; }
            public decimal Grade { get; set; } // (1 - 100)
        }
        String Query;
        public void AddCourse_NonQuery(Enrollment enrollment)
        {
            Query = "INSERT INTO Enrollments (StudentId, CourseID ,Grade) " +
                    "VALUES (@StudentId , @CourseID ,@Grade)";
           enrollStudent_ExecuteQuery(Query, enrollment);
        }
        public void enrollStudentInCourse()
        {
            Console.WriteLine("Can Now Enter Student To Course : ");
            char exitOrNot = 'Y';
            while (exitOrNot != 'N')
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("NOTE : IF YOU WANT TO EXIT FROM ADD COURSE ENTER 'N' ");
                Console.ResetColor();
                Console.Write("Student ID : ");
                int StudentId = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Course ID : ");
                int CourseID = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Enter Grade : ");
                decimal grade = Convert.ToDecimal(Console.ReadLine());
                Enrollment enrollment = new Enrollment
                {
                    StudentId = StudentId,
                    CourseID = CourseID,
                    Grade = grade
                };
                AddCourse_NonQuery(enrollment);
                Console.WriteLine("Do You Want To Add Another Student ? (Y / N) ");
                exitOrNot = Char.Parse(Console.ReadLine().ToUpper());
            }
        }
    }
}
