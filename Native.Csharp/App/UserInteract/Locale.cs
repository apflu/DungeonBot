using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.UserInteract
{
    public abstract class Locale
    {
        public abstract Dictionary<LocaleKey, string> Locales { get; protected set; }
        public string GetValue(LocaleKey key)
        {
            try
            {
                return Locales[key];
            } catch (KeyNotFoundException)
            {
                return Plugin.GetLocaleManager().GetLocale("LocaleDefault").GetValue(key);
            }
        }
    }
}
