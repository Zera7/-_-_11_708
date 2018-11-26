using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Text;

namespace CsWebService
{
    /// <summary>
    /// Сводное описание для CsCService
    /// </summary>
    [WebService(Namespace = "http://localhost/qwe")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class CsCService : System.Web.Services.WebService
    {
        private static SQLServerManager manager = new SQLServerManager(
                serverName: "localhost",
                login: "Zera",
                password: "1",
                dbName: "MyAdventureWorks");

        [WebMethod]
        public List<string> GetAllTables()
        {
            return manager.ExecuteADOSqlQuery(
                Queries.GetAllTablesQuery(), 
                SQLReaderDataReceiver.ReceiveStringRow);
        }

        [WebMethod]
        public List<string> GetAllFieldsOfTable(string table)
        {
            return manager.ExecuteADOSqlQuery(
                Queries.GetAllFieldsOfTable(table),
                SQLReaderDataReceiver.ReceiveStringRow);
        }

        [WebMethod]
        public List<string> Query(string tables, string fields, string whereExpression)
        {
            return manager.ExecuteADOSqlQuery(
                Queries.GetSelectQuery(fields, tables),
                SQLReaderDataReceiver.ReceiveStringRow);
        }
    }
}