using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manegment_Student_Project.Logic
{
    public class ViewCourse : DataAccess.Connection_For_ViewCourses
    {
        string Query;
        public void View_Courses()
        {
            Console.WriteLine("Enter Course ID : ");
            int CourseId = Convert.ToInt32(Console.ReadLine());
            Query = "SELECT * FROM Courses WHERE CourseID = @CourseID";
            view_Courses_ExecuteQuery(Query, CourseId);
        }
    }
}
