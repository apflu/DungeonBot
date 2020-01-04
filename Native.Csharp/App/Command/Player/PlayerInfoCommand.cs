using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Csharp.App.Gameplay;

namespace Native.Csharp.App.Command
{
    public class PlayerInfoCommand : ICommand
    {
        public void Execute(Player sender, params string[] args)
        {
            string result = sender.GetName() + "的个人信息\r\n角色列表：";
            foreach(Character character in Plugin.GetCharacterHandler().GetCharacters(sender))
            {
                result += character.Name + "";
                if (character.IsCurrentBusy())
                    result += "（忙碌）";
                result += " ";
            }
            sender.Reply(result);
        }
    }
}
