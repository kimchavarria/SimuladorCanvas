using SimuladorCanvas.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SimuladorCanvas.Data
{
    public class StudentData
    {
        public static string dbConexion = "Data Source=KIMBERLYSLAPTOP\\SQLEXPRESS01;Initial Catalog=DB_SC;Integrated Security=True;";
        public List<Student> GetStudentDetails()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection connection = new SqlConnection(dbConexion))
            {
                string query = "SELECT student_id, firstName, lastName, email FROM STUDENT";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Student student = new Student
                            {
                                student_id = reader.GetInt32(0),
                                firstName = reader.GetString(1),
                                lastName = reader.GetString(2),
                                email = reader.GetString(3)
                            };
                            students.Add(student);
                        }
                    }
                }
            }

            return students;
        }
    }
}