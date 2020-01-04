using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Csharp.App.Gameplay;
using Native.Csharp.App.Gameplay.Items.ItemTypes;
using Native.Csharp.App.UserInteract;

namespace Native.Csharp.App.Command
{
    public class AbandonItemCommand : ICommand
    {
        public void Execute(Player sender, params string[] args)
        {
            Item item = Plugin.GetItemHandler().Parse(args[1]);
            Character character = sender.GetCurrentCharacter();
            if(character != null)
            {
                if (character.Inventory.AbandonItems(item))
                    sender.Reply("丢弃完成。");
                else
                    sender.Reply("物品名无效或物品不存在！");
            }
            else
                sender.Reply("你当前没有角色！\r\n" + "使用 *创建角色 来创建一个！");

        }
    }
}
