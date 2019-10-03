using Native.Csharp.App.Command;
using Native.Csharp.App.Command.Interface;
using Native.Csharp.App.Util;
using Native.Csharp.App.Util.Math;
using Native.Csharp.App.Util.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Native.Csharp.App.Event.EventHandler;

namespace Native.Csharp.App.Commands.PointCommand
{
    //.rd
    public class RollDiceCommand : ICommand
    {
        public void Execute(Player sender, string[] args)
        {
            if (args == null)
            {
                Send(sender.GetCurrentGroup(), Dice.GetDice("1d20").ToString());
            }
            else
            {
                Send(sender.GetCurrentGroup(), Dice.GetDice(args[0]).ToString());
            }
        }

        public PlayerCommandHandler Register()
        {
            return new PlayerCommandHandler(Execute);
        }

        private void Send(long group, string message)
        {
            Values.GetMessageSender().SendGroupMessage(group, message);
        }
    }
}
