using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace CsWebService
{
    /// <summary>
    /// Предоставляет методы для работы с SQL Server
    /// </summary>
    public class SQLServerManager
    {
        public SQLServerManager(string serverName, string login, string password, string dbName)
        {
            this.ServerName = serverName;
            this.Login = login;
            this.Password = password;
            this.DatabaseName = dbName;
        }

        public string ServerName { get; }
        public string DatabaseName { get; }
        public string Login { get; }
        public string Password { get; }

        public List<T> ExecuteADOSqlQuery<T>(
            Query query,
            Func<SqlDataReader, T> dataReceiver,
            List<string> SQLParameters = null)
        {
            var result = new List<T>();

            using (var connection = CreateADOConnection())
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = query.Text;

                if (query.Parameters != null)
                    foreach (var parameter in query.Parameters)
                        command.Parameters.AddWithValue(parameter.Name, parameter.Value);

                var reader = command.ExecuteReader();

                while (reader.Read())
                    result.Add(dataReceiver(reader));
            }
            return result;
        }

        private SqlConnection CreateADOConnection()
        {
            var connection = new SqlConnection(
                $"Server=tcp:{ServerName},1433;" +
                $"Database={DatabaseName};User ID={Login};" +
                $"Password={Password};" +
                "Connection Timeout=30;");
            connection.Open();
            Console.WriteLine("Соединение открыто ...");
            return connection;
        }
    }
}