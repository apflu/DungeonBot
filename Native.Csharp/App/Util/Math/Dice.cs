using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Util.Math
{
    public class Dice
    {
        private readonly int Quantity;
        private readonly int Size;

        private const int Quantity_Max = 100;
        private const int Size_Max = 100;

        public Dice(int intQuantity, int intSize)
        {
            Quantity = (intQuantity > Quantity_Max) ? Quantity_Max : intQuantity;
            Size = (intSize > Size_Max) ? Size_Max : intSize;
        }

        public Dice(string strDice)
        {
            string[] strDiceSet = new string[2]; //0 Quantity 1 Size
            if (strDice[0].Equals('d'))
            {
                strDiceSet[0] = "1";
                strDiceSet[1] = strDice.Remove(0, 1);
            }
            else strDiceSet = strDice.Split('d');

            Quantity = int.Parse(strDiceSet[0]);
            Size = int.Parse(strDiceSet[1]);
        }

        private int GetDice(int intSize)
        {
            Random random = new Random();
            return random.Next(1, intSize); //from 1 to size
        }

        /// <summary>
        /// 0 = final result
        /// </summary>
        /// <returns></returns>
        public int[] GetResult()
        {
            int[] Result = new int[Quantity + 1];

            int dice;

            //randomize and get result
            for (int i = 1; i < Size; i++)
            {
                dice = GetDice(Size);

                Result[0] += dice;
                Result[i] = dice;
            }

            return Result;
        }

        public int GetQuantity()
        {
            return Quantity;
        }

        public int GetSize()
        {
            return Size;
        }

        public override string ToString()
        {
            return Quantity + "d" + Size;
        }
    }
}
