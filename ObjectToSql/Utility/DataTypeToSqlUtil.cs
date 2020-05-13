using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectToSql.Utility
{
    public static class DataTypeToSqlUtil
    {
        private static Dictionary<string, string> _clrToSqlServer = new Dictionary<string, string> 
        {
            { "string", "VARCHAR(255)"},
            { "int32", "INT"},
            { "int64", "BIGINT"},
            { "boolean", "BIT"},
            { "double", "FLOAT"},
            { "int16", "TINYINT"},
            { "decimal", "NUMERIC(10,2)"}

        };


        public static Dictionary<String, string> ClrToSqlServer => _clrToSqlServer;
        private static string getSqlTypeByPropertyType(string propertyType)
        {
            string sqlPropType = "";
            switch (propertyType)
            {
                case "string": sqlPropType = "VARCHAR(255)"; break;
                case "int32": sqlPropType = "INT"; break;
                case "int64": sqlPropType = "BIGINT"; break;
                case "boolean": sqlPropType = "BIT"; break;
                case "byte []": sqlPropType = "VARBINARY"; break;
                default: throw new Exception("Invalid type");
            }
            return sqlPropType;
        }
    }
}
