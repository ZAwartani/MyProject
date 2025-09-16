using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Manegment_Student_Project.Logic.Add_Teacher;

namespace Manegment_Student_Project.DataAccess
{
    public abstract class Connection_For_AddTeacher
    {
        public string ConnectionString = "Server=AMIGO;DataBase=Student;User Id = sa;Password = sa123456;Encrypt=false;";

        public void add_teacher_ExecuteQuery(string query, Teacher teacher)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", teacher.FirstName);
            command.Parameters.AddWithValue("@LastName", teacher.LastName);
            command.Parameters.AddWithValue("@Email", teacher.Email);
            command.Parameters.AddWithValue("@Phone", teacher.Phone);
            command.Parameters.AddWithValue("@HireDate", teacher.HireDate);
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
