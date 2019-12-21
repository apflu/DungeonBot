using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Exceptions
{
    public class InvalidFlagException : InvalidInputException
    {
        public const string ActionCreate = "Create";

        public const string FlagName = "FlagName";
        public const string FlagContent = "FlagContent";

        
        public InvalidFlagException(string type)
        {
            Action = ActionCreate;
            Type = type;
        }

        public InvalidFlagException(string type, string action)
            : this(type)
        {
            Action = action;
        }
    }
}
