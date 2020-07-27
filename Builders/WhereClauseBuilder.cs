using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlPaste
{
    public class WhereClauseBuilder : ScriptBuilderBase
    {
        public WhereClauseBuilder(GridData data) : base(data)
        {
        }

        public override string OutputString()
        {
            StringBuilder outputBuilder = new StringBuilder();

            for (int i = 0; i < Data.StringData.Length; i++)
            {
                outputBuilder.Append("( ");

                for (int j = 0; j < Data.Headers.Length; j++)
                {
                    outputBuilder.Append($"{Data.Headers[j]} = {Data.StringData[i][j]} ");

                    if (j != (Data.Headers.Length - 1))
                    {
                        outputBuilder.Append("AND ");
                    }
                }

                outputBuilder.Append(") ");
                if (i != (Data.StringData.Length - 1))
                {
                    outputBuilder.AppendLine("OR ");
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
