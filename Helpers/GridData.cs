using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlPaste
{
    public class GridData
    {
        private String[][] stringData;
        private String[] headers;
        private bool[] nonNumeric;
        public const String NULL = "NULL";

        public string[][] StringData { get => stringData; set => stringData = value; }
        public string[] Headers { get => headers; set => headers = value; }
        public bool[] NonNumeric { get => nonNumeric; set => nonNumeric = value; }

        public GridData(String clipStr)
        {
            var rows = clipStr.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            StringData = rows.AsParallel().Skip(1)
                                .Select(a => a.Split('\t'))
                                .ToArray();
            Headers = rows[0].Split('\t');
            NonNumeric = new bool[Headers.Length];
        }

        public void DetermineNumericColumns()
        {
            for (int i = 0; i < StringData.Length; i++)
            {
                for (int j = 0; j < StringData[i].Length; j++)
                {
                    if (!NonNumeric[j])
                    {
                        NonNumeric[j] = !Decimal.TryParse(StringData[i][j], out _);
                    }
                }
            }
        }

        public void FormatGrid()
        {
            for (int i = 0; i < StringData.Length; i++)
            {
                for (int j = 0; j < StringData[i].Length; j++)
                {
                    if (NonNumeric[j] && !StringData[i][j].Equals(NULL))
                        StringData[i][j] = $"\'{StringData[i][j].Replace("'", "''")}\'";
                }
            }

            for (int j = 0; j < Headers.Length; j++)
            {
                Headers[j] = $"[{ Headers[j]}]";
            }
        }

    }
}
