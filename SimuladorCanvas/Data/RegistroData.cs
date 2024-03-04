using SimuladorCanvas.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SimuladorCanvas.Data
{
    public class RegistroData
    {
        public List<Registro> GetRegistros()
        {
            List<Registro> registros = new List<Registro>();

            using (SqlConnection connection = new SqlConnection(Conexion.dbConexion))
            {
                string query = "SELECT student_id, course_id, course_name, student_name, student_email FROM REGISTRO";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Registro registro = new Registro
                            {
                                student_id = reader.GetInt32(0),
                                course_id = reader.GetInt32(1),
                                course_name = reader.GetString(2),
                                student_name = reader.GetString(3),
                                student_email = reader.GetString(4)
                            };

                            registros.Add(registro); // Agregar el registro a la lista
                        }
                    }
                }

                return registros;
            }
        }

    }
}
