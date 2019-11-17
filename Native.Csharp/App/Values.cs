using Native.Csharp.App.Gameplay;
using Native.Csharp.App.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Native.Csharp.App
{
    public class Values
    {
        public ArrayList dices;

        public const string RegularDice = "^\\d+d\\d+$";

        public readonly Flag Flag_ActionHeal; //是一个治疗动作
        public readonly Flag Flag_FromNature; //来源为自然
        public readonly Flag Flag_FromTime; //来源为时间流逝
        public readonly Flag Flag_ObjectCharacter; //目标为角色

        public Values()
        {
            dices = new ArrayList
            {
                new Dice(1, 4),
                new Dice(2, 4),
                new Dice(3, 4),
                new Dice(1, 6),
                new Dice(2, 6),
                new Dice(1, 8),
                new Dice(1, 10),
                new Dice(1, 20),
                new Dice(1, 100)
            };

            Flag_ActionHeal = new Flag(Flag.Action_FlagName_ActionType, Flag.Action_FlagContent_TypeHeal);
            Flag_FromNature = new Flag(Flag.Action_FlagName_Sender, Flag.Action_FlagContent_SourceNature);
            Flag_FromTime = new Flag(Flag.Action_FlagName_Sender, Flag.Action_FlagContent_SourceTime);
            Flag_ObjectCharacter = new Flag(Flag.Action_FlagName_Object, Flag.Action_FlagContent_SourceCharacter);
        }

        public Dice GetDice(string target)
        {
            MatchCollection matches = Regex.Matches(target, RegularDice);

            if (matches.Count > 0)
            {
                foreach (Dice dice in dices)
                    if (target == dice.ToString())
                        return dice;
                return ParseDice(matches[0].Value);
            }
            return null;
        }

        private Dice ParseDice(string dice)
        {
            MatchCollection matches = Regex.Matches(dice, "\\d+");
            Dice result = new Dice(byte.Parse(matches[0].Value), byte.Parse(matches[1].Value));

            if (result.IsValid())
                return result;
            return null;
        }
    }
}
