using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Native.Csharp.App.EventArgs;
using Native.Csharp.App.Interface;
using Native.Csharp.App.Util;

namespace Native.Csharp.App.Event
{
    public class Event_GroupMessage : IReceiveGroupMessage
    {
        public void ReceiveGroupMessage(object sender, CqGroupMessageEventArgs message)
        {
            if (IsCommand(message.Message))
                Values.GetCommandHandler().Execute(message);
        }

        private Boolean IsCommand(string message)
        {
            return Regex.IsMatch(message, Values.PatternCommand);
        }
    }
}
