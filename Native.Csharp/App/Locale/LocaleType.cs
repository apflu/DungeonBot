using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Locale
{
    public class LocaleType
    {
        protected readonly string type;

        public const string Locale_Command = "";
        public const string Locale_Description = "";
        public const string Locale_Usage = "";

        public const string Locale_RollDiceCommand = "";
        public const string Locale_RollDiceCommand_Description = "";
        public const string Locale_RollDiceCommand_Usage = "";
        public const string Locale_RollDiceCommand_Result = "";

        protected LocaleType(string type)
        {
            this.type = type;
        }

        public override string ToString()
        {
            return type;
        }

        public string GetLocale(string localeString)
        {
            return GetType().GetField(localeString).GetValue(null).ToString();
        }
    }
}
