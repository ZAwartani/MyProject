using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Manegment_Student_Project.Logic.enrolleStudent;

namespace Manegment_Student_Project.DataAccess
{
     public abstract class Connection_For_EnrolleStudent
    {
        public string ConnectionString = "Server=AMIGO;DataBase=Student;User Id = sa;Password = sa123456;Encrypt=false;";

        public void enrollStudent_ExecuteQuery(string query, Enrollment enroll)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StudentId", enroll.StudentId);
            command.Parameters.AddWithValue("@CourseID", enroll.CourseID);
            command.Parameters.AddWithValue("@Grade", enroll.Grade);
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery(); // انا هون ما بعمل استعلام بس بضيف بيانات
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Insertion successful.");
                }
                else
                {
                    Console.WriteLine("Insertion failed.");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("1- Possible Student ID Error");
                Console.WriteLine("2- Student Enter This Course");
                Console.WriteLine("3- Course Does't Exits");
            }
        }
    }
}
