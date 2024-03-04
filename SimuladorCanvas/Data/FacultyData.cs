using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace SimuladorCanvas.Data
{
    public class FacultyData
    {
        public bool RegisterStudentToCourse(int studentId, int courseId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Conexion.dbConexion))
                {
                    using (SqlCommand command = new SqlCommand("RegistrarEstudianteACurso", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@student_id", SqlDbType.Int).Value = studentId;
                        command.Parameters.Add("@course_id", SqlDbType.Int).Value = courseId;

                        connection.Open();
                        command.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception)
            {
                // Handle exception appropriately
                return false;
            }
        }
    }
}