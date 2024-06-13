using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace FormularioJorge.Models
{
    public class ConeccionBD : IDisposable
    {
        private string connectionString;
        private SqlConnection connection;

        public ConeccionBD(string server, string database, string userId, string password)
        {
            connectionString = $"Server={server};Database={database};User Id={userId};Password={password};TrustServerCertificate=True;";
            connection = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
                Console.WriteLine("Conexión exitosa a la base de datos.");
            }
        }

        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                Console.WriteLine("Conexión cerrada.");
            }
        }

        public SqlDataReader ExecuteQuery(string query)
        {
            SqlCommand command = new SqlCommand(query, connection);
            return command.ExecuteReader();
        }

        public SqlDataReader ExecuteStoredProcedure(string procedureName, params SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(procedureName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }
            return command.ExecuteReader();
        }

        public void Dispose()
        {
            CloseConnection();
            connection.Dispose();
        }

    }
}
