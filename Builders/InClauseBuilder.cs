using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlPaste
{
    public class InClauseBuilder : ScriptBuilderBase
    {
        public InClauseBuilder(GridData data) : base(data)
        {
        }

        public override string OutputString()
        {
            StringBuilder outputBuilder = new StringBuilder();

            for (int j = 0; j < Data.Headers.Length; j++)
            {
                outputBuilder.Append($"{Data.Headers[j]} IN ( ");

                for (int i = 0; i < Data.StringData.Length; i++)
                {
                    outputBuilder.Append($"{Data.StringData[i][j]}");
                    if (i != (Data.StringData.Length - 1))
                    {
                        outputBuilder.Append(", ");
                    }
                }

                outputBuilder.Append(" )");
                if (j != (Data.Headers.Length - 1))
                {
                    outputBuilder.AppendLine(" AND ");
                }
                else
                {
                    outputBuilder.AppendLine();
                }
            }

            return outputBuilder.ToString();
        }
    }
}
