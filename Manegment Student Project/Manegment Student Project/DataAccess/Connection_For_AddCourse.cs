using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Manegment_Student_Project.Logic.AddCourse;

namespace Manegment_Student_Project.DataAccess
{

    public abstract class Connection_For_AddCourse 
    {
        public string ConnectionString = "Server=AMIGO;DataBase=Student;User Id = sa;Password = sa123456;Encrypt=false;";

        public void add_course_ExecuteQuery(string query, Courses course)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CourseName", course.CourseName);
            command.Parameters.AddWithValue("@Credits", course.Credits);
            command.Parameters.AddWithValue("@TeacherId", course.TeacherId);
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery(); 
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
                Console.WriteLine("FAILD ADDED");
            }
        }
    }
}
