using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Util.Math
{
    public static class Dice
    {
        public static int GetResult(int intSize)
        {
            Random random = new Random();
            return random.Next(1, intSize); //from 1 to size
        }

        public static int GetDice(String strDice)
        {
            int Result = 0;

            String[] strDiceSet = new String[2]; //0 Quantity 1 Size
            if (strDice[0].Equals('d'))
            {
                strDiceSet[0] = "1";
                strDiceSet[1] = strDice.Remove(0, 1);
            }
            else strDiceSet = strDice.Split('d');

            //casting String to Integer
            int[] intDiceSet = new int[2]; //0 Quantity 1 Size
            intDiceSet[0] = int.Parse(strDiceSet[0]);
            intDiceSet[1] = int.Parse(strDiceSet[1]);

            //limit maximum dice to d100
            if (intDiceSet[1] > 100) intDiceSet[1] = 100;

            //randomize and get result
            for (int i = 0; i < intDiceSet[0]; i++)
            {
                Result += GetResult(intDiceSet[1]);
            }

            return Result;
        }
    }
}
