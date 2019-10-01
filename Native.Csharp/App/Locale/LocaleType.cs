using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Locale
{
    public class LocaleType
    {
        private string type;

        public readonly LocaleType Type_None = new LocaleType("none");

        private LocaleType(string type)
        {
            this.type = type;
        }
    }
}
