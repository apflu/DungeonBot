using Native.Csharp.App.Gameplay.Generator;
using Native.Csharp.App.Gameplay.Items.Herbs;
using Native.Csharp.App.Gameplay.Items.ItemTypes;
using Native.Csharp.App.UserInteract;
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
        public List<IItem> ItemList { get; }
        public RandomTable DefaultRandomTable { get; private set; }
        public ItemGenerator DefaultItemGenerator { get; private set; }
        public ItemHandler()
        {
            ItemList = new List<IItem>
            {
                //食物


                //草药
                new Weed(),
                new SparkledFern(),
                new Catnip(),
                new HoneyBerry(),
                new DragonBreath()
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
        /// 将物品组转换成文本
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static string ConvertToString(params IItem[] items)
        {
            string result = "";

            foreach(IItem item in items)
            {
                result += item.ItemName + "、";
            }
            return result.TrimEnd('、');
        }

        public bool Register(params IItem[] items)
        {
            foreach(IItem item in items)
            {
                if(!ItemList.Contains(item))
                {
                    ItemList.Add(item);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 使用物品id来索引，如不存在则返回null
        /// </summary>
        /// <param name="itemID">物品id</param>
        /// <returns></returns>
        public IItem Parse(int itemID)
        {
            foreach (IItem item in ItemList)
                if (item.ItemID == itemID)
                    return item;
            return null;
        }

        /// <summary>
        /// 使用物品名来索引，如不存在则返回null
        /// </summary>
        /// <param name="itemName">任意语言下的物品名称</param>
        /// <returns></returns>
        public IItem Parse(string itemName)
        {
            foreach (IItem item in ItemList)
                foreach (Locale locale in Plugin.GetLocaleManager().GetAllLocales())
                {
                    if (locale.GetValue(item.ItemName) == itemName)
                        return item;
                }
            return null;
        }
    }
}
