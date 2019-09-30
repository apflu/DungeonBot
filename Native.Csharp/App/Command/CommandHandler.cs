using Native.Csharp.App.EventArgs;
using Native.Csharp.App.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Command
{
    public class CommandHandler
    {
        public void Execute(CqGroupMessageEventArgs message)
        {
            Player sender = Player.Parse(message.FromQQ);
            sender.SetCurrentGroup(message.FromGroup);

            Values.GetEventHandler().PlayerCommand(sender, SplitArgs(message.Message));
        }

        private String[] SplitArgs(String args)
        {
            return args.Split(' ');
        }
    }
}
