using Native.Csharp.App.Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Native.Csharp.App.UserInteract
{
    public class MessageSender
    {

        public void Send(long groupID, string message)
        {
            Common.CqApi.SendGroupMessage(groupID, message);
        }
        public void Send(Player target, string message)
        {
            Send(target.LastGroupID, ParseLocaleMessage(target, message));
        }
        public void Send(Player target, string message, Dictionary<string, string> args)
        {
            Send(
                target,
                ParseArgs(
                    target,
                    ParseLocaleMessage(target, message),
                    args));
        }

        public void Whisper(long QQID, string message)
        {
            Common.CqApi.SendPrivateMessage(QQID, message);
        }
        public void Whisper(Player target, string message)
        {
            Whisper(target.QQID, ParseLocaleMessage(target, message));
        }
        public void Whisper(Player target, string message, Dictionary<string, string> args)
        {
            Whisper(target, ParseArgs(target, message, args));
        }
        
        /// <summary>
        /// 外部调用请用这个。
        /// </summary>
        /// <param name="target"></param>
        /// <param name="preMessage"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public string Parse(Player target, string preMessage, Dictionary<string, string> args)
        {
            return ParseLocaleMessage(target, ParseArgs(target, preMessage, args));
        }
        public string ParseArgs(Player target, string preMessage, Dictionary<string, string> args)
        {
            string result = (string)preMessage.Clone();

            for (; ; )
            {
                if ((args == null) || (args.Count == 0))
                    break;

                Match argument = Regex.Match(result, Values.RegexLocaleKeyArgument);
                if (!argument.Success)
                    break;

                result = Regex.Replace(
                    preMessage,
                    Values.RegexLocaleKeyArgument,
                    new MatchEvaluator(
                        (match) => //替换{key}为args中的指定输入
                        {
                            string arg = match.Value.Substring(1, match.Value.Length - 2); //去掉头尾大括号
                            foreach (KeyValuePair<string, string> givenArg in args) //从args中寻找匹配项进行替换
                            {
                                if (arg == givenArg.Key)
                                    return ParseLocaleMessage(target, givenArg.Value);
                            }
                            return arg;
                        })
                    );
            }
            return result;
        }
        public string ParseLocaleMessage(Player target, string message)
        {
            string preformatMessage = (string)message.Clone();
            for (; ; )
            {
                Match matcher = Regex.Match(preformatMessage, Values.RegexLocaleKey);
                if (!matcher.Success)
                    break;

                preformatMessage = Regex.Replace(
                    preformatMessage,
                    Values.RegexLocaleKey,
                    new MatchEvaluator(
                        (match) => //替换{LOCALE_KEY}为语言文件中的对应文本
                        {
                            string key = match.Value.Substring(1, match.Value.Length - 2); //掐头去尾
                            LocaleKey localeKey = Plugin.LocaleManager.GetKey(key); //获得对象
                            return target.CurrentLocale.GetValue(localeKey); //获得文本
                        })
                    );
            }
            return preformatMessage;
        }
        public void DebugSend(string message)
        {
            Common.CqApi.SendGroupMessage(634893702, message);
        }
    }
}
