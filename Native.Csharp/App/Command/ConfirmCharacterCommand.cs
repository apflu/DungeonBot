using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Csharp.App.Gameplay;

namespace Native.Csharp.App.Command
{
    public class ConfirmCharacterCommand : ICommand
    {
        public void Execute(Player sender, params string[] args)
        {
            if (sender.PendingCharacter == null)
                new CreateCharacterCommand().Execute(sender, args);
            if (IsInputValid(sender, args))
            {
                sender.AddCharacter(new Character(args[1], sender.PendingCharacter));
                sender.Reply("你成功创建了角色" + args[1] + "!");
            }
        }

        private bool IsInputValid(Player sender, string[] args)
        {
            if(args.Length < 2)
            {
                sender.Reply("你需要为你的角色指定名字！");
                return false;
            }
            if(args.Length > 2)
            {
                sender.Reply("角色名不能包含空格！");
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
