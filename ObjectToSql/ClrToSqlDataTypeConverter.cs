using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectToSql
{
    public abstract class ClrToSqlDataTypeConverter
    {
        protected abstract  Dictionary<string, string> ClrToSqlDatDictionary { get; }
    }
}
