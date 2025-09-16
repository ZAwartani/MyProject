using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manegment_Student_Project.Logic
{
    public class ViewTeachers : DataAccess.Connection_For_ViewTeachers
    {
        String Query;
        public void View_Teachers()
        {
            Console.WriteLine("Enter Teacher ID : ");
            int TeacherId = Convert.ToInt32(Console.ReadLine());
            Query = "SELECT * FROM Teachers WHERE TeacherID = @TeacherID";
            view_Teacher_ExecuteQuery(Query, TeacherId);
        }
    }
}
