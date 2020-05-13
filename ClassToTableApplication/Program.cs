using ObjectModel;
using ObjectToSql;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;

namespace ClassToTableApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            CreateTableScriptGenerator scriptGenerator = new SqlServerCreateTableScriptGenerator();


            string generatedScripts = scriptGenerator.GenerateCreateTableScript();

            Console.WriteLine(generatedScripts);
            Console.WriteLine("Everything ran sucessfully. Press any key to continue");
        }

        private static string getSqlTypeByPropertyType(string propertyType)
        {
            string sqlPropType = "";
            switch (propertyType)
            {
                case "string": sqlPropType = "VARCHAR(255)"; break;
                case "int32": sqlPropType = "INT";break;
                case "int64": sqlPropType = "BIGINT"; break;
                case "boolean": sqlPropType = "BIT"; break;
                case "byte []": sqlPropType = "VARBINARY";break;
                default:throw new Exception("Invalid type");
            }
            return sqlPropType;
        }

    }
}
