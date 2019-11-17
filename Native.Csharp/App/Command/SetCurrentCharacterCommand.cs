using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Csharp.App.Gameplay;

namespace Native.Csharp.App.Command
{
    public class SetCurrentCharacterCommand : ICommand
    {
        Character character;
        public void Execute(Player sender, params string[] args)
        {
            if (IsInputValid(sender, args))
            {
                if (sender.GetCurrentCharacter() != character)
                {
                    sender.SetCurrentCharacter(character);
                    sender.Reply("已指定当前角色为" + character.Name);
                }
                else
                { //搞事情？

                }
            }
        }

        private bool IsInputValid(Player sender, string[] args)
        {
            if (args.Length < 2)
            {
                sender.Reply("你需要输入一个角色名！");
                return false;
            }
            if (args.Length > 2)
            {
                sender.Reply("角色名不能包含空格！");
                return false;
            }

            character = Plugin.GetCharacterHandler().Parse(args[1]);
            if (character == null)
            {
                sender.Reply("该角色不存在！");
                return false;
            }
            if(character.Owner != sender)
            {
                sender.Reply("该角色不属于你！");
                return false;
            }
            return true;
        }
    }
}
