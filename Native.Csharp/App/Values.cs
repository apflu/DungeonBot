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
        public const string RegexLocaleKey = "\\{[A-Z_]+\\}";
        public const string RegexLocaleKeyArgument = "\\{[a-z_]+\\}";

        public static readonly int[] BAB_Half = new int[21]
        {
            0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10
        };

        public static readonly int[] BAB_viertel = new int[21]
        {
            0, 0, 1, 2, 3, 3, 4, 5, 6, 6, 7, 8, 9, 9, 10, 11, 12, 12, 13, 14, 15
        };

        public static readonly int[] BAB_Full = new int[21]
        {
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20
        };

        public static readonly int[] SavingWeak = new int[21]
        {
            0, 0, 0, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 6
        };

        public static readonly int[] SavingStrong = new int[21]
        {
            0, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12
        };

        public static readonly int[,] SpellSlotTableStandard = new int[21,10]
        {
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            {3, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
            {4, 2, 0, 0, 0, 0, 0, 0, 0, 0 },
            {4, 2, 1, 0, 0, 0, 0, 0, 0, 0 },
            {4, 3, 2, 0, 0, 0, 0, 0, 0, 0 },
            {4, 3, 2, 1, 0, 0, 0, 0, 0, 0 },
            {4, 3, 3, 2, 0, 0, 0, 0, 0, 0 },
            {4, 4, 3, 2, 1, 0, 0, 0, 0, 0 },
            {4, 4, 3, 3, 2, 0, 0, 0, 0, 0 },
            {4, 4, 4, 3, 2, 1, 0, 0, 0, 0 },
            {4, 4, 4, 3, 3, 2, 0, 0, 0, 0 },
            {4, 4, 4, 4, 3, 2, 1, 0, 0, 0 },
            {4, 4, 4, 4, 3, 3, 2, 0, 0, 0 },
            {4, 4, 4, 4, 4, 3, 2, 1, 0, 0 },
            {4, 4, 4, 4, 4, 3, 3, 2, 0, 0 },
            {4, 4, 4, 4, 4, 4, 3, 2, 1, 0 },
            {4, 4, 4, 4, 4, 4, 3, 3, 2, 0 },
            {4, 4, 4, 4, 4, 4, 4, 3, 2, 1 },
            {4, 4, 4, 4, 4, 4, 4, 3, 3, 2 },
            {4, 4, 4, 4, 4, 4, 4, 4, 3, 3 },
            {4, 4, 4, 4, 4, 4, 4, 4, 4, 4 }
        };

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

        public static int GetModifier(int Property)
        {
            return (Property / 2 - 5);
        }

        private Dice ParseDice(string dice)
        {
            MatchCollection matches = Regex.Matches(dice, "\\d+");
            Dice result = new Dice(byte.Parse(matches[0].Value), byte.Parse(matches[1].Value));

            if (result.IsValid())
                return result;
            return null;
        }

        public static string TimeToString(TimeSpan time)
        {
            string result = "";
            if (time.Days != 0)
                result += time.Days + "天";
            if (time.Hours != 0)
                result += time.Hours + "小时";
            if (time.Minutes != 0)
                result += time.Minutes + "分钟";
            if (time.Seconds != 0)
                result += time.Seconds + "秒";
            return result;
        }
    }
}
 