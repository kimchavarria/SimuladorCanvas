using System;
using System.Data.SqlClient;

namespace SimuladorCanvas.Data
{
    public class FacultyData
    {
        public void RegistrarEstudianteACurso(int studentId, int courseId)
        {
            // Obtiene la cadena de conexión desde la clase de conexión
            string connectionString = Conexion.dbConexion;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("RegistrarEstudianteACurso", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@student_id", studentId);
                command.Parameters.AddWithValue("@course_id", courseId);

                try
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("El estudiante ha sido registrado en el curso.");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al registrar al estudiante: " + ex.Message);
                }
            }
        }
    }
}
