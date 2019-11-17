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
            if (Plugin.GetCharacterHandler().GetCharacters(sender).Length < sender.MaxCharactersAllowed)
            {
                //TODO: 种族
                byte[] scores = new AbilityScoreGenerator().Generate();

                sender.Reply(
                    "你找到了一名新的冒险者！\r\n" +
                    "属性为 力量" + scores[0] + " 敏捷" + scores[1] + " 体质" + scores[2] +
                    " 智力" + scores[3] + " 感知" + scores[4] + " 魅力" + scores[5]
                    );

                sender.PendingCharacter = scores;
            }
            else
                messageSender.Send(sender.LastGroupID, "你已达到最大角色数量上限！");
        }
    }
}
