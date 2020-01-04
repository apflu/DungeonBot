using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Csharp.App.Gameplay;

namespace Native.Csharp.App.Command
{
    public class ShowInventoryCommand : ICommand
    {
        public void Execute(Player sender, params string[] args)
        {

            if (sender.GetCurrentCharacter() != null)
            {
                string content = sender.GetCurrentCharacter().Inventory.ToString();

                if (string.IsNullOrEmpty(content))
                {
                    sender.Reply("INVENTORY_CONTENT_EMPTY", new Dictionary<string, string>
                    {
                        { "character_name", sender.GetCurrentCharacter().Name }
                    });
                }
                else
                {
                    sender.Reply("INVENTORY_CONTENT", new Dictionary<string, string>
                    {
                        { "character_name", sender.GetCurrentCharacter().Name },
                        { "content", sender.GetCurrentCharacter().Inventory.ToString() }
                    });
                }
            }
            else
                sender.Reply("你当前没有角色！\r\n" + "使用 *创建角色 来创建一个！");

            
        }
    }
}
