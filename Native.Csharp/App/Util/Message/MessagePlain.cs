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
        private MessageType MessageType;
        private string Message;
        private LocaleType Locale;


        public MessagePlain(string message)
        {
            MessageType = MessageType.Type_Text;
            Message = message;
        }

        public MessagePlain(string messagePreset, LocaleType locale)
        {
            MessageType = MessageType.Type_Preset_Message;
            
            
        }

        public override string Tostring()
        {
            if (MessageType == MessageType.Type_Text)
            {
                return Message;
            } else if (MessageType == MessageType.Type_Preset_Message)
            {
                
            }
            return null;
        }
    }
}
