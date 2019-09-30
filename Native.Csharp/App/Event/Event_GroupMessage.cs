using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Csharp.App.EventArgs;
using Native.Csharp.App.Interface;

namespace Native.Csharp.App.Event
{
    public class Event_GroupMessage : IReceiveGroupMessage
    {
        public void ReceiveGroupMessage(object sender, CqGroupMessageEventArgs message)
        {
            if(IsCommand(message.Message))
            Common.CqApi.SendGroupMessage(message.FromGroup, ("突然笑死"));
        }

        private Boolean IsCommand(String message)
        {
            return (true);
        }
    }
}
