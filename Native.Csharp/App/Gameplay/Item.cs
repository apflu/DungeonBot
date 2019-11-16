using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay
{
    public class Item
    {
        public int ItemID { get; private set; }
        public string ItemName { get; private set; }

        public Item(int id)
        {
            ItemID = id;
        }

        public Item(int id, string name)
        {
            ItemID = id;
            ItemName = name;
        }

        /// <summary>
        /// 未完成方法
        /// </summary>
        /// <param name="item">需要比较的物品</param>
        /// <returns></returns>
        public bool Equals(Item item)
        {
            return (item.ItemID == ItemID);
        }
    }
}
