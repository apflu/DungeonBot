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
        }

        public Dice GetDice(string target)
        {
            MatchCollection matches = Regex.Matches(target, RegularDice);

            if(matches.Count > 0)
            foreach (Dice dice in dices)
                if (target == dice.ToString())
                    return dice;
        }

        private Dice ParseDice(string dice)
        {

        }
    }
}
