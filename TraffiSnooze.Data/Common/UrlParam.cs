using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraffiSnooze.Data.Common
{
    public class UrlParam
    {
        public string ParamName { get; set; }
        public string ParamValue { get; set; }

        public UrlParam(string paramName, string paramValue)
        {
            this.ParamName = paramName;
            this.ParamValue = paramValue;
        }

        public override string ToString()
        {
            return $"&{ParamName}={Uri.EscapeDataString(ParamValue)}";
        }
    }
}
