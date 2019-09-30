using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Util.Message
{
    public class MessageType
    {
        private String type;

        public readonly MessageType Type_Text = new MessageType("text");

        private MessageType(String type)
        {
            this.type = type;
        }
    }
}
