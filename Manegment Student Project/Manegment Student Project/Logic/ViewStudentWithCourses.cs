using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manegment_Student_Project.Logic
{
    public class ViewStudentWithCourses : DataAccess.Connection_For_ViewStudentWithCourses
        {
        string Query;
        public void View_Students_Course()
        {
            Query = "SELECT s.StudentID, s.FirstName, s.LastName, c.CourseID, c.CourseName, e.Grade " +
                    "FROM Students s " +
                    "JOIN Enrollments e ON s.StudentID = e.StudentId " +
                    "JOIN Courses c ON e.CourseID = c.CourseID";
            view_Students_Course_ExecuteQuery(Query);
        }
    }
}
