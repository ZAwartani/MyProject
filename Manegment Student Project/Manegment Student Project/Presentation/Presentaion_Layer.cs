using Manegment_Student_Project.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Manegment_Student_Project.Presentation
{
     public enum DB : Byte
    {
        addStudent = 1,
        addTeacher = 2,
        addCourse = 3,
        enrollStudentInCourse = 4,
        assignGradeToStudent = 5,
        viewStudents = 6,
        viewTeachers = 7,
        viewCourses = 8,
        viewStudentsCourse = 9,
        exit = 10
    }
    public class Presentaion_Layer
    {
        public Presentaion_Layer()
        {
           
        }

        public void ShowMenu()
        {
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Teacher");
            Console.WriteLine("3. Add Course");
            Console.WriteLine("4. Enroll Student in Course");
            Console.WriteLine("5. Assign Grade to Student");
            Console.WriteLine("6. View Students");
            Console.WriteLine("7. View Teachers");
            Console.WriteLine("8. View Courses");
            Console.WriteLine("9. viewStudentsCourse");
            Console.WriteLine("10. Exit");

            Console.Write("Enter your choice: ");
            Byte choice = Convert.ToByte(Console.ReadLine());
            Console.WriteLine();
            DB option = (DB)choice ;
            switch (option)
            {
                case DB.addStudent:
                    new Add_Student().addStudent();
                    break;
                case DB.addTeacher:
                    new Add_Teacher().addTeacher();
                    break;
                case DB.addCourse:
                    new AddCourse().addCourse();
                    break;
                case DB.enrollStudentInCourse:
                    new enrolleStudent().enrollStudentInCourse();
                    break;
                case DB.assignGradeToStudent:
                    new AssignGrade().assignGradeToStudent();
                    break;
                case DB.viewStudents:
                    new ViewStudent().View_Students();
                    break;
                case DB.viewTeachers:
                    new ViewTeachers().View_Teachers();
                    break;
                case DB.viewCourses:
                    new ViewCourse().View_Courses();
                    break;
                case DB.viewStudentsCourse:
                    new ViewStudentWithCourses().View_Students_Course();
                    break;
                case DB.exit:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
