using Native.Csharp.App.Command;
using Native.Csharp.App.Util.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Locale
{
    public class LocaleManager
    {
        private List<LocaleType> Locales;

        public LocaleManager()
        {
            RegisterLocale(new LocaleZHCN());
        }

        public string Format(string message, LocaleType locale)
        {
            return locale.GetLocale(message);
        }

        /// <summary>
        /// 从字符串获取语言文件，没有则返回null
        /// </summary>
        /// <param name="type">语言名</param>
        /// <returns>LocaleType</returns>
        public LocaleType Parse(string type)
        {
            LocaleType result = null;
            Locales.ForEach(locale =>
            {
                if(locale.ToString().Equals(type))
                {
                    result = locale;
                }
            });
            return result;
        }

        public void RegisterLocale(LocaleType locale)
        {
            if (!Locales.Contains(locale))
            {
                Locales.Add(locale);
            }
        }
    }
}
