using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Csharp.App.Gameplay;
using Native.Csharp.App.Gameplay.Generator;
using Native.Csharp.App.UserInteract;

namespace Native.Csharp.App.Command
{
    public class CreateCharacterCommand : ICommand
    {
        public void Execute(Player sender, params string[] args)
        {
            MessageSender messageSender = Plugin.GetMessageSender();
            if(IsValid(sender, args))
            {
                if (Plugin.GetCharacterHandler().GetCharacters(sender).Length < sender.Char_MaxAllowed)
                {
                    
                    //TODO: 种族
                    AbilityScoreGenerator generator = new AbilityScoreGenerator();
                    generator.Generate();

                    sender.Reply(
                        "你寻找到了新的冒险者！属性为：\r\n" +
                        generator.ToString() + "\r\n" +
                        "使用*招募角色 <角色名> 来确认你的选择！"
                        );
                    sender.Char_OnList = new List<AbilityScoreGenerator>
                    {
                        generator
                    };
                }
                else
                    messageSender.Send(sender.LastGroupID, "你已达到最大角色数量上限！");
            }
        }

        private bool IsValid(Player sender, string[] args)
        {
            return true;
        }
    }
}
