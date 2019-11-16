using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Util
{
    public class Possibility
    {
        public object Content { get; private set; }
        public int Chance { get; private set; }

        public Possibility(object content, int chance)
        {
            Content = content;
            Chance = chance;
        }
    }
}
