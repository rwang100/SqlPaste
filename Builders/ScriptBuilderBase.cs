using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlPaste
{
    public abstract class ScriptBuilderBase
    {
        public ScriptBuilderBase(GridData data)
        {
            this.Data = data;
        }
        public abstract String OutputString();
        public GridData Data { get; set; }
    }
}
