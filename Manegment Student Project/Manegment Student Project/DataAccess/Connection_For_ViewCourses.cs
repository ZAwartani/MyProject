using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manegment_Student_Project.DataAccess
{
    public abstract class Connection_For_ViewCourses
    
    {
        public string ConnectionString = "Server=AMIGO;DataBase=Student;User Id = sa;Password = sa123456;Encrypt=false;";

        public void view_Courses_ExecuteQuery(string query, int Id)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CourseID", Id);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Console.WriteLine("ID: " + reader["CourseID"]);
                    Console.WriteLine("Course Name: " + reader["CourseName"]);
                    Console.WriteLine("Credits: " + (int)reader["Credits"]);
                    Console.WriteLine("Teacher ID: " + (int)reader["TeacherId"]);
                    Console.WriteLine("Created At " + reader["CreatedAt"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
