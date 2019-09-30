using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Locale
{
    public class LocaleType
    {
        private String type;

        public readonly LocaleType Type_None = new LocaleType("none");

        private LocaleType(String type)
        {
            this.type = type;
        }
    }
}
