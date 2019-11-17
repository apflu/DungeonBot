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

        public const byte MaxQuantity = 10;
        public const byte MaxSize = 100;

        private readonly Random random;
        public Dice(byte quantity, byte size)
        {
            Quantity = quantity;
            Size = size;

            random = new Random();
        }

        public DiceResult GetResult()
        {
            string strResult = ToString() + "=";
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

        public bool IsValid()
        {
            return (
                (Quantity < MaxQuantity) && 
                (Size < MaxSize) &&
                (Quantity > 0) &&
                (Size > 0)
                );
        }

        public override string ToString()
        {
            return Quantity + "d" + Size;
        }
    }
}
