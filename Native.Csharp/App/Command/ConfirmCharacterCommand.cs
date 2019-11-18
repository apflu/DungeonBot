using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Native.Csharp.App.Gameplay;

namespace Native.Csharp.App.Command
{
    public class ConfirmCharacterCommand : ICommand
    {
        public void Execute(Player sender, params string[] args)
        {
            if (IsInputValid(sender, args))
            {
                if (sender.PendingCharacter == null)
                    new CreateCharacterCommand().Execute(sender, args);
                sender.AddCharacter(new Character(args[1], sender.PendingCharacter));
                sender.PendingCharacter = null;
                sender.Reply("你成功创建了角色" + args[1] + "!");
            }
        }

        private bool IsInputValid(Player sender, string[] args)
        {
            if (Plugin.GetCharacterHandler().GetCharacters(sender).Length == sender.MaxCharAllowed)
            {
                sender.Reply("你已达到最大角色数量上限！");
                return false;
            }
            if (args.Length < 2)
            {
                sender.Reply("你需要为你的角色指定名字！");
                return false;
            }
            if(args.Length > 2)
            {
                sender.Reply("角色名不能包含空格！");
                return false;
            }
            if(Regex.IsMatch(args[1], "多长") || (args[1].Length > 8))
            {
                sender.Reply("角色名过长！");
                return false;
            }
            if(!Regex.IsMatch(args[1], Values.RegexCharacterName))
            {
                sender.Reply("角色名只能包含汉字！");
                return false;
            }
            if(Plugin.GetCharacterHandler().Parse(args[1]) != null)
            {
                sender.Reply("该角色名已被使用！");
                return false;
            }
            return true;
        }
    }
}
