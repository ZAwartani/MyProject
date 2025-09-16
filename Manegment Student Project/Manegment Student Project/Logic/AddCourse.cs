using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manegment_Student_Project.Logic;

namespace Manegment_Student_Project.Logic
{
    public class AddCourse : DataAccess.Connection_For_AddCourse
    {
        public struct Courses
        {
            public string CourseName { get; set; }
            public string Credits { get; set; }
            public int TeacherId { get; set; }
        }
        string Query;
        public void AddCourse_NonQuery(Courses course)
        {
            Query = "INSERT INTO Courses (CourseName, Credits, TeacherId) " +
                    "VALUES (@CourseName , @Credits , @TeacherId)";
            add_course_ExecuteQuery(Query, course);
        }
        public void addCourse()
        {
            Console.WriteLine("Can Now Enter Information About Course : ");
            char exitOrNot = 'Y';
            while (exitOrNot != 'N')
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("NOTE : IF YOU WANT TO EXIT FROM ADD COURSE ENTER 'N' ");
                Console.ResetColor();
                Console.Write("Course Name : ");
                string Course = Console.ReadLine();
                Console.Write("Credits : ");
                int Credits = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Teacher ID : (Must Add Before Added To Course)");
                int TeacherId = Convert.ToInt16(Console.ReadLine());
                Courses newCourse = new Courses
                {
                    CourseName = Course,
                    Credits = Credits.ToString(),
                    TeacherId = TeacherId
                };
                AddCourse_NonQuery(newCourse);
                Console.WriteLine("Do You Want To Add Another Student ? (Y / N) ");
                exitOrNot = Char.Parse(Console.ReadLine().ToUpper());
            }
        }
    }
}
