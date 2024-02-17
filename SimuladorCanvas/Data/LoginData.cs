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
        public bool Login(string username, string password, string userType)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.dbConexion))
            {
                using (SqlCommand command = new SqlCommand("UserLogin", oConexion))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros de entrada
                    command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                    command.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
                    command.Parameters.Add("@user_type", SqlDbType.VarChar).Value = userType;

                    // Parámetro de salida
                    command.Parameters.Add("@success", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    oConexion.Open();
                    command.ExecuteNonQuery();

                    // Verificar el valor de salida
                    return (bool)command.Parameters["@success"].Value;
                }
            }
        }
    }
}
    