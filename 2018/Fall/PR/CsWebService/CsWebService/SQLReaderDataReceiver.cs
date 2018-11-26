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
    /// Предоставляет методы-обработчики информации с базы данных
    /// </summary>
    public static class SQLReaderDataReceiver
    {
        public static string ReceiveStringRow(SqlDataReader reader)
        {
            var row = new StringBuilder();
            for (int i = 0; i < reader.FieldCount; i++)
                row.Append($"{reader.GetValue(i).ToString()}\t");

            return row.ToString();
        }
    }
}