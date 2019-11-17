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

            if (sender.GetCurrentCharacter() != null)
            {
                result += sender.GetCurrentCharacter().Name + "的物品栏中目前有：";
                result += sender.GetCurrentCharacter().Inventory.ToString();

                Plugin.GetMessageSender().Send(sender.LastGroupID, result);
            }
            else
                sender.Reply("你当前没有角色！\r\n" + "使用 *创建角色 来创建一个！");

            
        }
    }
}
