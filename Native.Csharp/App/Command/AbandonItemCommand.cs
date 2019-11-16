using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Csharp.App.Gameplay;
using Native.Csharp.App.UserInteract;

namespace Native.Csharp.App.Command
{
    public class AbandonItemCommand : ICommand
    {
        public void Execute(Player sender, params string[] args)
        {
            MessageSender mSender = Plugin.GetMessageSender();
            Item item = Plugin.GetItemHandler().Parse(args[1]);
            if (sender.Inventory.AbandonItems(item))
                mSender.Send(sender.LastGroupID, "丢弃完成。");
            else
                mSender.Send(sender.LastGroupID, "物品名无效或物品不存在！");
        }
    }
}
