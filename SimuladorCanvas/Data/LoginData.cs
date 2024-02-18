using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace SimuladorCanvas.Data
{
    public class LoginData
    {
        // Método para el inicio de sesión
        public bool Login(string username, string password, string userType)
        {
            // establece una conexión a la base de datos usando la cadena de conexión definida en la clase Conexion
            using (SqlConnection oConexion = new SqlConnection(Conexion.dbConexion)) 
            {
                //Creación de comando SQL para llamar a un procedimiento en la bd llamado "UserLogin"
                using (SqlCommand command = new SqlCommand("UserLogin", oConexion))
                {
                    //especifica el tipo de comando como un procedimiento almacenado
                    command.CommandType = CommandType.StoredProcedure; 

                    // Parámetros de entrada del procedimiento almacenado
                    command.Parameters.Add("@username", SqlDbType.VarChar).Value = username; // Parámetro para el nombre de usuario
                    command.Parameters.Add("@password", SqlDbType.VarChar).Value = password; // Parámetro para la contraseña
                    command.Parameters.Add("@user_type", SqlDbType.VarChar).Value = userType; // Parámetro para el tipo de usuario

                    // Parámetro de salida del procedimiento para indicar si el login fue exitoso
                    command.Parameters.Add("@success", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    oConexion.Open(); // abre la conexión a la base de datos
                    command.ExecuteNonQuery(); // llamada al procedimiento

                    // Verificación del valor de salida del procedimiento para determinar si el login fue exitoso
                    return (bool)command.Parameters["@success"].Value; // Devuelve el valor de salida convertido a booleano
                }
            }
        }
    }
}