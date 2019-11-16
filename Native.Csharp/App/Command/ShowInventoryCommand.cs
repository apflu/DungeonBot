using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Csharp.App.Gameplay;

namespace Native.Csharp.App.Command
{
    public class ShowPlayerInventoryCommand : ICommand
    {
        public void Execute(Player sender, params string[] args)
        {
            string result = "";

            result += sender.GetName() + "的物品栏中目前有：";
            result += sender.Inventory.ToString();

            Plugin.GetMessageSender().Send(sender.LastGroupID, result);
        }
    }
}
