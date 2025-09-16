using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manegment_Student_Project.DataAccess
{
    public abstract class Connection_For_ViewTeachers

    {
        public string ConnectionString = "Server=AMIGO;DataBase=Student;User Id = sa;Password = sa123456;Encrypt=false;";

        public void view_Teacher_ExecuteQuery(string query, int Id)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TeacherID", Id);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Console.WriteLine("ID: " + reader["TeacherID"]);
                    Console.WriteLine("FirstName: " + reader["FirstName"]);
                    Console.WriteLine("LastName: " + reader["LastName"]);
                    Console.WriteLine("Email: " + reader["Email"]);
                    Console.WriteLine("Phone number " + reader["Phone"]);
                    Console.WriteLine("Hire Date " + reader["HireDate"]);
                    Console.WriteLine("Created At " + reader["CreatedAt"]);
                }
                else
                {
                    Console.WriteLine("Id Don't Found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
