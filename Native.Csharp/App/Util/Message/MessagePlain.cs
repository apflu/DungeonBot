using Native.Csharp.App.Locale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Util.Message
{
    public class MessagePlain
    {
        private readonly MessageType MessageType;
        private readonly string Message;
        private readonly LocaleType Locale;


        public MessagePlain(string message)
        {
            MessageType = MessageType.Type_Text;
            Message = message;
        }

        public MessagePlain(string messagePreset, LocaleType locale)
        {
            MessageType = MessageType.Type_Preset_Message;
            Message = messagePreset;
            Locale = locale;
        }

        public override string ToString()
        {
            if (MessageType == MessageType.Type_Text)
            {
                return Message;
            } else if (MessageType == MessageType.Type_Preset_Message)
            {
                return Values.GetLocaleManager().Format(Message, Locale);
            }
            return null;
        }
    }
}
