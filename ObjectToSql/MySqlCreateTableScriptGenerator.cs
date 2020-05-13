using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectToSql
{
    public class MySqlCreateTableScriptGenerator : CreateTableScriptGenerator
    {
        protected override string TableSchemaName => "";

        protected override string NameDelimiterCharacter => "`";

        public override string GenerateCreateTableScript()
        {
            throw new NotImplementedException();
        }
    }
}
