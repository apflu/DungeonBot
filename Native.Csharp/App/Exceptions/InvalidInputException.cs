using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Exceptions
{
    public class InvalidInputException
    {
        public string Action { get; protected set; }
        public string Type { get; protected set; }
    }
}
