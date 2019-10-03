using Native.Csharp.App.Command;
using Native.Csharp.App.Locale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Util.Message
{
    public class MessageSender
    {
        public void SendGroupMessage(long group, string message)
        {
            Send(group, new MessagePlain(message));
        }

        public void SendGroupMessage(Player target, string message)
        {
            Send(target.GetCurrentGroup(), new MessagePlain(message));

        }

        public void SendGroupMessage(Player target, string message, Boolean isPresetMessage)
        {
            if (isPresetMessage == false)
            {
                Send(target.GetCurrentGroup(), new MessagePlain(message));
            } else
            {
                Send(target.GetCurrentGroup(), Values.GetLocaleManager().Format(message, target.GetCurrentLocale()));
            }
        }

        private void Send(long group, MessagePlain message)
        {
            Common.CqApi.SendGroupMessage(group, message.ToString());
        }
    }
}
