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
        private const int Max_NameLength = 8;
        private string CharacterName;
        public void Execute(Player sender, params string[] args)
        {
            if (IsInputValid(sender, args))
            {
                //如果没有已生成的属性，那么就生成一个。
                if (sender.Char_OnList == null)
                    new CreateCharacterCommand().Execute(sender, args);

                sender.AddCharacter(new Character(CharacterName, sender.Char_OnList[0]));
                sender.Char_OnList = null; //避免重复使用

                sender.Reply("你成功创建了角色" + args[1] + "！");
            }
        }

        private bool IsInputValid(Player sender, string[] args)
        {
            if (Plugin.GetCharacterHandler().GetCharacters(sender).Length == sender.Char_MaxAllowed) //如果角色过多
            {
                sender.Reply("{ERROR_LIMIT_REACHED}", new Dictionary<string, string>
                {
                    { "object", "{CHARACTER}" },
                    { "limit", sender.Char_MaxAllowed + "" }
                });
                return false;
            }

            /* 
             * ================
             * =   输入检测   =
             * ================
             */

            if (args.Length < 2) //如果参数过少
            {
                sender.Reply("{ERROR_PARAM_REQUIRED}", new Dictionary<string, string>
                {
                    { "key", "{CHARACTER}" },
                    { "value", "{NAME}" }
                });
                return false;
            }
            if(args.Length > 2) //如果参数过多（也就是名字带空格）
            {
                sender.Reply("ERROR_CANNOT_CONTAIN", new Dictionary<string, string>
                {
                    { "key", "{NAME}" },
                    { "value", "{CHAR_NAME_SPACE}" }
                });
                return false;
            }

            /* 
             * ================
             * =   名称检测   =
             * ================
             */

            CharacterName = args[1]; //确定了输入长度有效

            if (Regex.IsMatch(CharacterName, "多长") || (CharacterName.Length > Max_NameLength)) //不准起名“起名能起多长”
            {
                sender.Reply("{ERROR_PARAM_TOO_LONG}", new Dictionary<string, string>
                {
                    { "key", "{NAME}" },
                    { "limit", Max_NameLength + "" }
                });
                return false;
            }
            if(!Regex.IsMatch(CharacterName, Values.RegexName)) //如果名字带有非汉字
            {
                sender.Reply("{ERROR_CAN_ONLY_CONTAIN}", new Dictionary<string, string>
                {
                    { "key", "{NAME}" },
                    { "value", "{CHAR_NAME_CHAR}" }
                });
                return false;
            }
            if(Plugin.GetCharacterHandler().Parse(CharacterName) != null) //如果名字已被占用
            {
                sender.Reply("{ERROR_ALREADY}", new Dictionary<string, string>
                {
                    { "key", "{NAME}" },
                    { "status", "{EXIST}" }
                });
                return false;
            }

            return true; //恭喜！成功了！
        }
    }
}
