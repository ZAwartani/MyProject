using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Manegment_Student_Project.Logic.enrolleStudent;

namespace Manegment_Student_Project.DataAccess
{
    public abstract class Connection_For_AssignGrade
    {
        public string ConnectionString = "Server=AMIGO;DataBase=Student;User Id = sa;Password = sa123456;Encrypt=false;";

        public void assignGrade_ExecuteQuery(string query, Enrollment enroll)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StudentId", enroll.StudentId);
            command.Parameters.AddWithValue("@CourseID", enroll.CourseID);
            command.Parameters.AddWithValue("@Grade", enroll.Grade);
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Update successful.");
                }
                else
                {
                    Console.WriteLine("Update failed.");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
