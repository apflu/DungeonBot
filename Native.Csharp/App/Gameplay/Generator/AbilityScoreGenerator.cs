using Native.Csharp.App.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Generator
{
    public class AbilityScoreGenerator
    {
        internal byte[] RaceModifiers;

        private byte[] scores;
        public byte[] Modifiers;
        public byte[] Results;

        public AbilityScoreGenerator()
        {
            RaceModifiers = new byte[6]
            {
                0, 0, 0, 0, 0, 0
            };
        }

        public string GetTribute(int i)
        {
            switch(i)
            {
                case 0:
                    return "力量 " + TributeToString(0);
                case 1:
                    return "敏捷 " + TributeToString(1);
                case 2:
                    return "体质 " + TributeToString(2);
                case 3:
                    return "智力 " + TributeToString(3);
                case 4:
                    return "感知 " + TributeToString(4);
                case 5:
                    return "魅力 " + TributeToString(5);
            }
            return null;
        }

        /// <summary>
        /// 私有方法，因为未检验输入有效性
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private string TributeToString(int i)
        {
            string result = scores[i] + "+" + RaceModifiers[i] + "（";
            if (Modifiers[i] > 0)
                result += "+";
            result += Modifiers[i] + "）";

            return result;
        }

        public void Generate()
        {
            byte[] result = new byte[6];

            Dice d6 = Plugin.Values.GetDice("1d6");
            for (int i = 0; i < 6; i++)
            {
                byte[] results = new byte[4];
                for (int j = 0; j < 4; j++)
                {
                    results[j] = (byte)d6.GetResult().IntResult;
                    result[i] += results[j];
                }
                result[i] += (byte)(RaceModifiers[i] - results.Min());
            }
            scores = result;

            for (int i = 0; i < 6; i++)
            {
                result[i] = (byte)(scores[i] + RaceModifiers[i]);
                Modifiers[i] = (byte)((result[i] - 10) / 2);
            }
                
            Results = result;
        }

        public override string ToString()
        {
            if (Results == null)
                Generate(); //防（月）呆设计
            string result = "";
            for(int i = 0; i < 6; i++)
            {
                result += GetTribute(i);
            }
            return result;
        }
    }
}
