using Native.Csharp.App.Gameplay.Generator;
using Native.Csharp.App.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Handler
{
    public class ItemHandler
    {
        public ArrayList ItemList { get; private set; }
        public RandomTable DefaultRandomTable { get; private set; }
        public ItemGenerator DefaultItemGenerator { get; private set; }
        public ItemHandler()
        {
            ItemList = new ArrayList
            {
                new Item(1, "杂草"),
                new Item(2, "闪光蕨"),
                new Item(3, "猫薄荷"),
                new Item(4, "蜜汁浆果"),
                new Item(5, "龙息草")
            };

            //debug以及临时用default变量
            DefaultRandomTable = new RandomTable().AddPossibility(
                new Possibility(Parse(1), 100),
                new Possibility(Parse(2), 40),
                new Possibility(Parse(3), 20),
                new Possibility(Parse(4), 10),
                new Possibility(Parse(5), 1)
                );
            DefaultItemGenerator = new ItemGenerator(DefaultRandomTable);
        }

        /// <summary>
        /// 将数组转换成文本
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static string ConvertToString(params Item[] items)
        {
            string result = "";

            foreach(Item item in items)
            {
                result += item.ItemName + "、";
            }
            return result.TrimEnd('、');
        }

        /// <summary>
        /// 使用物品id来索引，如不存在则返回null
        /// </summary>
        /// <param name="itemID">物品id</param>
        /// <returns></returns>
        public Item Parse(int itemID)
        {
            foreach (Item item in ItemList)
                if (item.ItemID == itemID)
                    return item;
            return null;
        }

        /// <summary>
        /// 使用物品名来索引，如不存在则返回null
        /// </summary>
        /// <param name="itemName">物品名称</param>
        /// <returns></returns>
        public Item Parse(string itemName)
        {
            foreach (Item item in ItemList)
                if (item.ItemName == itemName)
                    return item;
            return null;
        }
    }
}
