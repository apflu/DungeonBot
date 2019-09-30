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
        public void SendGroupMessage(Player target, long group, String message)
        {
            Common.CqApi.SendGroupMessage(group, message);

        }

        public void SendGroupMessage(Player target, long group, String message, Boolean isPresetMessage)
        {
            //LocaleType Locale = Player.GetCurrentLocale(target);
            //Common.CqApi.SendGroupMessage(new MessagePlain(message));

        }
    }
}
