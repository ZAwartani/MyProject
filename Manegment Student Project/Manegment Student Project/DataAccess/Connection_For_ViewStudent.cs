using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manegment_Student_Project.DataAccess
{
    public abstract class Connection_For_ViewStudent
    {
        public string ConnectionString = "Server=AMIGO;DataBase=Student;User Id = sa;Password = sa123456;Encrypt=false;";

        public void view_Students_ExecuteQuery(string query, int studentId)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StudentID", studentId);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Console.WriteLine("ID: " + reader["StudentID"]);
                    Console.WriteLine("FirstName: " + reader["FirstName"]);
                    Console.WriteLine("LastName: " + reader["LastName"]);
                    Console.WriteLine("Gender: " + reader["Gender"]);
                    Console.WriteLine("Date Of Birth: " + Convert.ToDateTime(reader["DateOfBirth"]).ToString("yyyy-MM-dd"));
                    Console.WriteLine("Phone number: " + reader["Phone"]);
                    Console.WriteLine("Created At: " + reader["CreatedAt"]);
                }
                else
                {
                    Console.WriteLine("ID Does't Found!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
