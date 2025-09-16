using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manegment_Student_Project.DataAccess
{
    public abstract class Connection_For_ViewStudentWithCourses
    {
        public string ConnectionString = "Server=AMIGO;DataBase=Student;User Id = sa;Password = sa123456;Encrypt=false;";
        public void view_Students_Course_ExecuteQuery(string query)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("Student ID: " + (int)reader["StudentId"]);
                    Console.WriteLine("FirstName: " + reader["FirstName"]);
                    Console.WriteLine("LastName: " + reader["LastName"]);
                    Console.WriteLine("Course ID: " + (int)reader["CourseID"]);
                    Console.WriteLine("Course Name: " + reader["CourseName"]);
                    Console.WriteLine("Grade: " + (decimal)reader["Grade"]);
                    Console.WriteLine("----------------------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
