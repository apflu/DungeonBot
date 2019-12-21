using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.UserInteract
{
    public class LocaleKey
    {
        public string Name { get; private set; }
        public string[] Arguments { get; private set; }
        public LocaleKey(string keyName, params string[] arguments)
        {
            Name = keyName;
            if (arguments != null)
                Arguments = arguments;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
