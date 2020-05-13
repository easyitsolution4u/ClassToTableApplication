using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ObjectToSql
{
    public class SqlServerCreateTableScriptGenerator : CreateTableScriptGenerator
    {
        protected override string TableSchemaName { get => ""; }
        protected override string NameDelimiterCharacter { get => ""; }

        public override string GenerateCreateTableScript()
        {
            string projectToload = "ObjectModel";
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            List<String> propertyQueryHolders = new List<string>();
            StringBuilder sqlScrptBuilder = new StringBuilder();
            List<String> creteTablScripts = new List<string>();


            try
            {
                Type[] types = Assembly.Load(projectToload).GetTypes();

                if (types != null && types.Length > 0)
                {
                    foreach (Type type in types)
                    {
                        string className = type.Name.ToUpper();
                        propertyQueryHolders.Add("CREATE TABLE " + className + " (\n");
                        sqlScrptBuilder.Append("CREATE TABLE " + className + " (\n");
                        PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                        if (propertyInfos != null && propertyInfos.Length > 0)
                        {
                            int counter = 0;
                            int length = propertyInfos.Length;
                            foreach (PropertyInfo propertyInfo in propertyInfos)
                            {
                                string propertyName = propertyInfo.Name;


                                string propertyType = propertyInfo.PropertyType?.Name?.ToLower();

                                var sqlType = ObjectToSql.Utility.DataTypeToSqlUtil.ClrToSqlServer[propertyType];


                                string pattern = propertyName.ToUpper() + " " + sqlType + " NULL";
                                sqlScrptBuilder.Append(pattern);

                                propertyQueryHolders.Add(pattern);

                                if (counter < length - 1)
                                {
                                    sqlScrptBuilder.Append(",\n");
                                }

                                counter++;


                            }

                            sqlScrptBuilder.Append(" ) ");
                            string createScript = sqlScrptBuilder.ToString();
                            creteTablScripts.Add(createScript);
                            sqlScrptBuilder.Length = 0;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            Console.WriteLine("Everything ran sucessfully. Press any key to continue");

            return creteTablScripts.Count > 0 ? string.Join("\n\n", creteTablScripts) : "";
        }
    }
}
