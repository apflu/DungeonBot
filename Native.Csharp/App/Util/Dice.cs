using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Util
{
    public class Dice
    {
        public byte Quantity { get; set; }
        public byte Size { get; protected set; }

        private readonly Random random;
        public Dice(byte quantity, byte size)
        {
            Quantity = quantity;
            Size = size;

            random = new Random();
        }

        public DiceResult GetResult()
        {
            string strResult = Quantity + "d" + Size + "=";
            int intResult = 0;
            int result;
            for(int i = 0; i < Quantity; i++)
            {
                result = random.Next(Size) + 1;
                strResult += result + "+";
                intResult += result;
            }
            return new DiceResult(strResult.TrimEnd('+'), intResult);
        }
    }
}
