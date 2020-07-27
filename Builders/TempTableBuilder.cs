using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlPaste
{
    public class TempTableBuilder : ScriptBuilderBase
    {
        public TempTableBuilder(GridData data) : base(data)
        {
        }

        public override string OutputString()
        {
            StringBuilder outputBuilder = new StringBuilder();
            StringBuilder insertBuilder = new StringBuilder();

            outputBuilder.AppendLine("CREATE TABLE #TEMP_TABLE ");
            outputBuilder.AppendLine("( ");

            insertBuilder.Append("INSERT INTO #TEMP_TABLE ( ");

            for (int j = 0; j < Data.Headers.Length; j++)
            {
                outputBuilder.Append($"\t {Data.Headers[j]} VARCHAR(MAX) NULL");
                insertBuilder.Append($"{Data.Headers[j]}");

                if (j != (Data.Headers.Length - 1))
                {
                    outputBuilder.AppendLine(", ");
                    insertBuilder.Append(", ");
                }
                else
                {
                    outputBuilder.AppendLine();
                }
            }

            outputBuilder.AppendLine(") ");
            outputBuilder.AppendLine();

            insertBuilder.Append(" ) ");

            var insertStatement = insertBuilder.ToString();

            for (int i = 0; i < Data.StringData.Length; i++)
            {
                outputBuilder.AppendLine(insertStatement);
                outputBuilder.Append("\tVALUES( ");

                for (int j = 0; j < Data.Headers.Length; j++)
                {
                    outputBuilder.Append($"{Data.StringData[i][j]}");

                    if (j != (Data.Headers.Length - 1))
                    {
                        outputBuilder.Append(", ");
                    }
                }

                outputBuilder.AppendLine(" ); ");
            }

            return outputBuilder.ToString();
        }
    }
}
