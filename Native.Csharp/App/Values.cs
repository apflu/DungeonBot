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

        public readonly ActionSource SourceSelf;
        public readonly ActionSource SourceEnvironment;
        public readonly ActionSource SourceTime;

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

            SourceSelf = new ActionSource(ActionSource.TypeSelf);
            SourceEnvironment = new ActionSource(ActionSource.TypeEnvironment);
            SourceTime = new ActionSource(ActionSource.TypeTime);
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
