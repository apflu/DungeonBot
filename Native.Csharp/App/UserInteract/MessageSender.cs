using Native.Csharp.App.Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.UserInteract
{
    public class MessageSender
    {

        public void Send(long groupID, string message)
        {
            Common.CqApi.SendGroupMessage(groupID, message);
        }

        public void Send(Player target, LocaleKey key, Dictionary<string, string> args)
        {
            string preformatMessage = target.CurrentLocale.GetValue(key); //获取玩家语言下的待处理文本

            Common.CqApi.SendGroupMessage(
                target.LastGroupID,
                Plugin.GetLocaleManager().Format(preformatMessage, args) //获取玩家语言下的文本
                );
        }

        public void DebugSend(string message) 
        {
            Common.CqApi.SendGroupMessage(634893702, message);
        }

        public void Whisper(long QQID, string message)
        {
            Common.CqApi.SendPrivateMessage(QQID, message);
        }

        public void Whisper(Player target, LocaleKey key, Dictionary<string, string> args)
        {
            string preformatMessage = target.CurrentLocale.GetValue(key); //获取玩家语言下的待处理文本

            Common.CqApi.SendPrivateMessage(
                target.QQID,
                Plugin.GetLocaleManager().Format(preformatMessage, args) //获取玩家语言下的文本
                );
        }
    }
}
