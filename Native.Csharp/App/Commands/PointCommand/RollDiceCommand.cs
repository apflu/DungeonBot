using Native.Csharp.App.Command;
using Native.Csharp.App.Command.Interface;
using Native.Csharp.App.Util;
using Native.Csharp.App.Util.Math;
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
            //string Locale = LocaleManager.GetCurrentLocale(sender);
            if (args == null)
            {
                Send(sender.GetCurrentGroup(), Dice.GetDice("1d20").ToString());
                
            }
            else
            {
                Values.messageSender.SendGroupMessage(sender.GetCurrentGroup(), Dice.GetDice(args[0]).ToString());
            }
        }

        public PlayerCommandHandler Register()
        {
            return new PlayerCommandHandler(Execute);
        }

        private void Send(long group, string message)
        {
            Values.messageSender.SendGroupMessage(group, message);
        }
    }
}
