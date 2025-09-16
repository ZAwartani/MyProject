using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Manegment_Student_Project.Logic.enrolleStudent;

namespace Manegment_Student_Project.Logic
{
    public class AssignGrade  : DataAccess.Connection_For_AssignGrade
    {
        String Query;
        public void AssignGrade_NonQuery(Enrollment enrollment)
        {
            Query = "UPDATE Enrollments SET Grade = @Grade " +
                    "WHERE StudentId = @StudentId AND CourseID = @CourseID;";
            assignGrade_ExecuteQuery(Query, enrollment);
        }
        public void assignGradeToStudent()
        {
            Console.WriteLine("Can Now Set Grade For Student : ");
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
                AssignGrade_NonQuery(enrollment);
                Console.WriteLine("Do You Want To Assign Grade To Another Student ? (Y / N) ");
                exitOrNot = Char.Parse(Console.ReadLine().ToUpper());
            }
        }
    }
}
