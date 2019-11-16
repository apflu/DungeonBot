using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.UserInteract
{
    public class MessageSender
    {
        public object Inventory { get; internal set; }

        public void Send(long groupID, string message)
        {
            Common.CqApi.SendGroupMessage(groupID, message);
        }

        public void DebugSend(string message)
        {
            Common.CqApi.SendGroupMessage(634893702, message);
        }
    }
}
