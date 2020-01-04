using Native.Csharp.App.Gameplay.Items.ItemTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay
{
    public class ItemStack
    {
        //如果要变更物品，简单地创建一个新的即可
        public Item Item { get; private set; }
        public int Quantity { get; set; }

        public ItemStack(Item item)
        {
            Item = item;
        }

        public ItemStack(Item item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }

        public bool Equals(ItemStack stack)
        {
            return ((stack.Item).Equals(Item) && (stack.Quantity == Quantity));
        }
    }
}
