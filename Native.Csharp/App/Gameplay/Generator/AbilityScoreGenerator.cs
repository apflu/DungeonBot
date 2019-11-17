using Native.Csharp.App.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Generator
{
    class AbilityScoreGenerator
    {
        internal byte[] Modifiers;

        public AbilityScoreGenerator()
        {
            Modifiers = new byte[6]
            {
                0, 0, 0, 0, 0, 0
            };
        }

        public byte[] Generate()
        {
            byte[] result = new byte[6];
            Dice d6 = Plugin.Values.GetDice("1d6");
            for(int i = 0; i < 6; i++)
            {
                byte[] results = new byte[4];
                for (int j = 0; j < 4; j++)
                {
                    results[j] = (byte)d6.GetResult().IntResult;
                    result[i] += results[j];
                }
                result[i] += (byte)(Modifiers[i] - results.Min());
            }
            return result;
        }
    }
}
