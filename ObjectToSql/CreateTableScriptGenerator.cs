using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectToSql
{
    public abstract class CreateTableScriptGenerator
    {
        protected abstract string TableSchemaName { get; }
        protected abstract string NameDelimiterCharacter { get;  }

        public abstract string GenerateCreateTableScript();

    }
}
