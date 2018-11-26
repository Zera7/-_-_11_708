using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CsWebService
{
    /// <summary>
    /// Предоставляет запросы для безопасного взаимодействия с базой данных
    /// </summary>
    public static class Queries
    {
        private const string tableNameParameter = "@tableName";
        private const string tableFieldsParameter = "@tableFields";

        private static Regex whiteListChars = new Regex(@"[\w,*]+", RegexOptions.Compiled);
        private static Regex whereExpression = new Regex(@"[\w+,not,is,=,<,>]", RegexOptions.Compiled);

        public static Query GetAllTablesQuery() => new Query(@"  
                    SELECT table_name
                    FROM INFORMATION_SCHEMA.TABLES 
                    WHERE TABLE_TYPE='BASE TABLE'");

        public static Query GetAllFieldsOfTable(string tableName)
        {
            var query = $@"
                    SELECT column_name
                    FROM INFORMATION_SCHEMA.COLUMNS
                    WHERE TABLE_NAME = {tableNameParameter}";
            return new Query(
                query,
                new List<LiteSQLParameter> {
                    new LiteSQLParameter(tableNameParameter, tableName) });
        }

        public static Query GetSelectQuery(string tables, string fields, string whereExpression = null, string orderBy = null)
        {
            var fieldsList = GetMatches(fields, whiteListChars);
            var tablesList = GetMatches(tables, whiteListChars);

            var asd = "";
            if (whereExpression != null)
                asd = "asd";


            var query = $@"  
                    SELECT {string.Join(",", fieldsList)}
                    FROM {string.Join(",", tablesList)} "
                    + whereExpression == null ? "WHERE  = @test" : "";
            return new Query(
                query);
        }

        private static List<string> GetMatches(string str, Regex regex)
        {
            List<string> result = new List<string>();

            foreach (Match match in regex.Matches(str))
                result.Add(match.Value);

            return result;
        }

        private static string GetWhereString(string str)
        {
            throw new NotImplementedException();
        }

    }
}