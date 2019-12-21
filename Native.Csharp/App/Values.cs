using Native.Csharp.App.Gameplay;
using Native.Csharp.App.UserInteract;
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
        public List<Dice> dices = new List<Dice>
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

        public const string RegexDice = "^\\d+d\\d+$";
        public const string RegexName = "^[\\u4e00-\\u9fa5]+$";
        public const string RegexLocaleKeyArgument = "\\{[a-z_]+\\}";

        public readonly Flag Flag_ActionHeal = new Flag(Flag.Action_FlagName_ActionType, Flag.Action_FlagContent_TypeHeal); //是一个治疗动作
        public readonly Flag Flag_FromNature = new Flag(Flag.Action_FlagName_Sender, Flag.Action_FlagContent_SourceNature); //来源为自然
        public readonly Flag Flag_FromTime = new Flag(Flag.Action_FlagName_Sender, Flag.Action_FlagContent_SourceTime); //来源为时间流逝
        public readonly Flag Flag_ObjectCharacter = new Flag(Flag.Action_FlagName_Object, Flag.Action_FlagContent_SourceCharacter); //目标为角色

        public readonly Flag Flag_CanBenefitFromRest = new Flag(Flag.Status_FlagName_CanBenefitFromRest, "true");
        public readonly Flag Flag_CanNotBenefitFromRest = new Flag(Flag.Status_FlagName_CanBenefitFromRest, "false");

        public static readonly TimeSpan Day = new TimeSpan(TimeSpan.TicksPerDay);
        public static readonly TimeSpan Hour = new TimeSpan(TimeSpan.TicksPerHour);
        public static readonly TimeSpan Minute = new TimeSpan(TimeSpan.TicksPerMinute);

        public Dice GetDice(string target)
        {
            MatchCollection matches = Regex.Matches(target, RegexDice);

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
