﻿using System;
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
            if (Plugin.GetCharacterHandler().GetCharacters(sender).Length < sender.MaxCharAllowed)
            {
                //TODO: 种族
                AbilityScoreGenerator generator = new AbilityScoreGenerator();
                generator.Generate();

                sender.Reply(
                    "你找到了新的冒险者！属性为：\r\n" +
                    generator.ToString() +"\r\n" +
                    "使用*招募角色 <角色名> 来确认你的选择！"
                    );

                sender.PendingCharacter = scores;
            }
            else
                messageSender.Send(sender.LastGroupID, "你已达到最大角色数量上限！");
        }
    }
}
