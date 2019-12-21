using Native.Csharp.App.Gameplay.Items.ItemTypes;
using Native.Csharp.App.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Generator
{
    public class ItemGenerator
    {
        private readonly RandomTable table;

        public ItemGenerator(RandomTable randomTable)
        {
            table = randomTable;
        }

        public IItem[] Generate(int quantity)
        {
            IItem[] result = new IItem[quantity];
            for (int i = 0; i < quantity; i++)
            {
                table.DoRandomize();
                result[i] = (IItem) table.GetResult().Content;
            }
            return result;
        }
    }
}
