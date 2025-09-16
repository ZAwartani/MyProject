using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manegment_Student_Project.Logic
{
    public class ViewStudent : DataAccess.Connection_For_ViewStudent
    {
        String Query;
        public void View_Students()
        {
            Console.WriteLine("Enter Student ID : ");
            int studentId = Convert.ToInt32(Console.ReadLine());
            Query = "SELECT * FROM Students WHERE StudentID = @StudentID";
            view_Students_ExecuteQuery(Query, studentId);
        }
    }
}
