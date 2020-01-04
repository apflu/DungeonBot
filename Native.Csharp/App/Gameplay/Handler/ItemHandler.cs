using Native.Csharp.App.Gameplay.Generator;
using Native.Csharp.App.Gameplay.Items.Foods;
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
        public List<Item> ItemList { get; }
        public RandomTable DefaultRandomTable { get; private set; }
        public ItemGenerator DefaultItemGenerator { get; private set; }
        public ItemHandler()
        {
            ItemList = new List<Item>
            {
                //食物
                new Berry(),

                //草药
                new Weed(),
                new SparkledFern(),
                new Catnip(),
                new HoneyBerry(),
                new DragonBreath()
            };

            //debug以及临时用default变量
            DefaultRandomTable = new RandomTable().AddPossibility(
                new Possibility(Parse("weed"), 100),
                new Possibility(Parse("sparkled_fern"), 40),
                new Possibility(Parse("honey_berry"), 20),
                new Possibility(Parse("catnip"), 10),
                new Possibility(Parse("dragonbreath"), 1)
                );
            DefaultItemGenerator = new ItemGenerator(DefaultRandomTable);
        }

        /// <summary>
        /// 将物品组转换成文本
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static string ConvertToString(params Item[] items)
        {
            string result = "";

            foreach(Item item in items)
            {
                result += item.DisplayName + "、";
            }
            return result.TrimEnd('、');
        }

        public bool Register(params Item[] items)
        {
            foreach(Item item in items)
            {
                if(!ItemList.Contains(item))
                {
                    ItemList.Add(item);
                    return true;
                }
            }
            return false;
        }

        public Item GetItem(string anyName)
        {
            foreach (Item item in ItemList)
            {
                if (anyName == item.InternalName)
                    return item;
                if (anyName == item.DisplayName.ToString())
                    return item;

                foreach (Locale locale in Plugin.LocaleManager.GetAllLocales())
                {
                    if (anyName == locale.GetValue(item.DisplayName))
                        return item;
                }
            }
            return null;
        }

        /// <summary>
        /// 使用物品id来索引，如不存在则返回null
        /// </summary>
        /// <param name="internal_name">物品id</param>
        /// <returns></returns>
        public Item Parse(string internal_name)
        {
            foreach (Item item in ItemList)
                if (item.InternalName == internal_name)
                    return item;
            return null;
        }
    }
}
