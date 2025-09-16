using Manegment_Student_Project.Logic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Manegment_Student_Project.Logic.Add_Student;

namespace Manegment_Student_Project.DataAccess
{
    public abstract class Connection_For_AddStudent
    {
        public string ConnectionString = "Server=AMIGO;DataBase=Student;User Id = sa;Password = sa123456;Encrypt=false;";

        public void Add_Student_ExecuteQuery(string query, student Student)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", Student.FirstName);
            command.Parameters.AddWithValue("@LastName", Student.LastName);
            command.Parameters.AddWithValue("@Gender", Student.Gender);
            command.Parameters.AddWithValue("@DateOfBirth", Student.DateOfBirth);
            command.Parameters.AddWithValue("@Phone", Student.phone);
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
                Console.WriteLine(ex.Message);
            }
        }
    }
}
