using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Native.Csharp.App.UserInteract
{
    public class LocaleManager
    {
        /// <summary>
        /// 包含此LocaleManager中所有注册的文本键
        /// </summary>
        public readonly Dictionary<string, LocaleKey> Keys = new Dictionary<string, LocaleKey>
        {
            { "DEBUG", new LocaleKey("DEBUG") },
            //基础
            { "CHARACTER", new LocaleKey("CHARACTER") },
            { "PLAYER", new LocaleKey("PLAYER") },
            { "NAME", new LocaleKey("NAME") },

            //基础状态
            { "EXIST", new LocaleKey("EXIST") },

            //字符
            { "CHAR_NAME_SPACE", new LocaleKey("CHAR_NAME_SPACE") },
            { "CHAR_NAME_CHAR", new LocaleKey("CHAR_NAME_CHAR") },

            //角色状态
            { "CHARACTER_STATUS_BUSY", new LocaleKey("CHARACTER_STATUS_BUSY") },
            { "CHARACTER_STATUS_HELPLESS", new LocaleKey("CHARACTER_STATUS_HELPLESS") },

            //角色信息
            { "CHARACTER_NAME", new LocaleKey("CHARACTER_NAME") },
            { "CHARACTER_LIST", new LocaleKey("CHARACTER_LIST", "player") },
            { "CHARACTER_LIST_FORMAT", new LocaleKey("CHARACTER_LIST_FORMAT",
                "character_name", "status_list", "level", "class")},
            
            //角色创建
            { "CHARACTER_CREATED", new LocaleKey("CHARACTER_CREATED", "character_name") },

            { "ERROR_CHARACTER_NOT_EXIST", new LocaleKey("ERROR_CHARACTER_NOT_EXIST", "character_name") },
            { "ERROR_CHARACTER_NONE_IN_LIST", new LocaleKey("ERROR_CHARACTER_NONE_IN_LIST") },

            //通用错误
            { "ERROR_IS_NOT_VALID", new LocaleKey("ERROR_IS_NOT_VALID", "key", "value") },
            { "ERROR_COMMAND_FAIL", new LocaleKey("ERROR_COMMAND_FAIL", "command") },
            { "ERROR_LIMIT_REACHED", new LocaleKey("ERROR_LIMIT_REACHED", "object", "limit") },
            { "ERROR_PARAM_REQUIRED", new LocaleKey("ERROR_PARAM_REQUIRED", "key", "value") },
            { "ERROR_CANNOT_CONTAIN", new LocaleKey("ERROR_CANNOT_CONTAIN", "key", "value") },
            { "ERROR_CAN_ONLY_CONTAIN", new LocaleKey("ERROR_CAN_ONLY_CONTAIN", "key", "value") },
            { "ERROR_PARAM_TOO_LONG", new LocaleKey("ERROR_PARAM_TOO_LONG", "key", "limit") },
            { "ERROR_ALREADY", new LocaleKey("ERROR_ALREADY", "key", "status") },

            //抱怨
            { "JOB_AMOUNT_TOO_BIG", new LocaleKey("GATHER_HERB_AMOUNT_TOO_BIG",
                "player_name", "job_name_short", "job_name") },
            { "JOB_AMOUNT_OVERFLOW", new LocaleKey("GATHER_HERB_AMOUNT_OVERFLOW",
                "player_name", "job_name", "job_name_short") },
            { "JOB_AMOUNT_TOO_SMALL", new LocaleKey("GATHER_HERB_AMOUNT_TOO_SMALL",
                "player_name", "job_name", "job_name_short") },

            //工作
            { "JOB_START_NEW", new LocaleKey("JOB_START_NEW", "job", "quantity", "quantifier", "job_target") },
            { "JOB_RESULT_LAST", new LocaleKey("JOB_RESULT_LAST",
                "result", "job", "outcome", "quantity", "quantifier") },
            { "JOB_GATHER", new LocaleKey("JOB_GATHER") },
            { "JOB_GATHER_SHORT", new LocaleKey("JOB_GATHER_SHORT") },

            //物品类型
            { "ITEM_TYPE_FOOD", new LocaleKey("ITEM_TYPE_FOOD") },
            { "ITEM_TYPE_HERB", new LocaleKey("ITEM_TYPE_HERB") },

            //物品名称和描述
            { "ITEM_UNDEFINED_NAME", new LocaleKey("ITEM_UNDEFINED_NAME") },
            { "ITEM_UNDEFINED_DESCRIPTION", new LocaleKey("ITEM_UNDEFINED_DESCRIPTION") },
            { "ITEM_BERRY_NAME", new LocaleKey("ITEM_BERRY_NAME") },
            { "ITEM_BERRY_DESCRIPTION", new LocaleKey("ITEM_BERRY_DESCRIPTION") },

            //物品互动
            { "ITEM_NO_EFFECT", new LocaleKey("ITEM_NO_EFFECT") },

            //物品栏
            { "INVENTORY_CONTENT", new LocaleKey("INVENTORY_CONTENT", "character_name") },
            { "INVENTORY_CONTENT_EMPTY", new LocaleKey("INVENTORY_CONTENT_EMPTY", "character_name") },
            { "INVENTORY_FORMAT", new LocaleKey("INVENTORY_ITEM", "item_name", "quantity", "item_type") },
            { "INVENTORY_FORMAT_SEPARATOR", new LocaleKey("INVENTORY_FORMAT_SEPARATOR")},
        };

        private readonly List<Locale> Locales = new List<Locale>();

        /// <summary>
        /// 使用键的名称来获取一个LocaleKey。
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public LocaleKey GetKey(string keyName)
        {
            try
            {
                return Keys[keyName];
            } catch (KeyNotFoundException)
            {
                return null;
            }
        }

        /// <summary>
        /// 使用参数来处理一段预设文本
        /// </summary>
        /// <param name="preformatMessage">玩家语言下的待处理文本</param>
        /// <param name="args">用于处理文本的参数</param>
        /// <returns></returns>
        public string Format(string preformatMessage, Dictionary<string, string> args)
        {
            string result = (string) preformatMessage.Clone();
            for(; ; )
            {
                if ((args == null) || (args.Count == 0))
                    return result;

                Match argument = Regex.Match(result, Values.RegexLocaleKeyArgument);
                if (!argument.Success)
                    return result;

                result = Regex.Replace(
                    preformatMessage,
                    Values.RegexLocaleKeyArgument,
                    new MatchEvaluator(
                        (match) => //替换{key}为args中的指定输入
                        {
                            string arg = match.Value.Substring(1, match.Value.Length - 2); //去掉头尾大括号
                            foreach(KeyValuePair<string, string> givenArg in args) //从args中寻找匹配项进行替换
                            {
                                if(arg == givenArg.Key)
                                    return givenArg.Value;
                            }
                            return arg;
                        })
                    );
            }
        }

        /// <summary>
        /// 使用参数来处理一段预设文本
        /// </summary>
        /// <param name="preformatMessage">玩家预言下的待处理文本</param>
        /// <param name="args">用于处理文本的参数</param>
        /// <returns></returns>
        public string Format(string preformatMessage, params KeyValuePair<string, string>[] args)
        {
            return Format(preformatMessage, args.ToDictionary(arg => arg.Key, arg => arg.Value));
        }

        public bool RegisterLocale(Locale locale)
        {
            foreach(Locale existedLocale in Locales)
            {
                if (existedLocale.GetType() == locale.GetType())
                    return false;
            }
            Locales.Add(locale);
            return true;
        }

        public Locale GetLocale(string localeName)
        {
            foreach (Locale locale in Locales)
            {
                if (locale.GetType().Name.Equals(localeName))
                    return locale;
            }
            return null;
        }

        public Locale[] GetAllLocales()
        {
            return Locales.ToArray();
        }
    }
}
