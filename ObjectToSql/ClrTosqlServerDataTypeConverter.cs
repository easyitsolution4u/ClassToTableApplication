using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectToSql
{
    public class ClrTosqlServerDataTypeConverter : ClrToSqlDataTypeConverter
    {
        protected override Dictionary<string, string> ClrToSqlDatDictionary => new Dictionary<string, string>
        {
            { "string", "VARCHAR(255)"},
            { "int32", "INT"},
            { "int64", "BIGINT"},
            { "boolean", "BIT"},
            { "double", "FLOAT"},
            { "int16", "TINYINT"},
            { "decimal", "NUMERIC(10,2)"}
        };
    }
}
