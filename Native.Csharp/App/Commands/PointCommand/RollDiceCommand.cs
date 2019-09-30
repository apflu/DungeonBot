﻿using Native.Csharp.App.Command;
using Native.Csharp.App.Command.Interface;
using Native.Csharp.App.Util;
using Native.Csharp.App.Util.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Commands.PointCommand
{
    //.rd
    public class RollDiceCommand : ICommand
    {
        public void Execute(Player sender, string[] args)
        {
            //String Locale = LocaleManager.GetCurrentLocale(sender);
            if (args == null)
            {
                Values.messageSender.SendGroupMessage(sender, sender.GetCurrentGroup(), Dice.GetDice("1d20").ToString());
            }
            else
            {

            }
        }

        public void Register()
        {
            Values.GetEventHandler().PlayerCommandEvent += new Event.EventHandler.PlayerCommandHandler(Execute);
        }
    }
}
