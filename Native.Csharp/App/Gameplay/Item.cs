using Native.Csharp.App.Gameplay.Items.ItemTypes;
using Native.Csharp.App.UserInteract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay
{
    [Obsolete("请使用IItem接口代替。")]
    public class Item : IItem
    {
        public int ItemID { get; }
        public LocaleKey ItemName { get; set; }

        public Item(int id)
        {
            ItemID = id;
        }

        public Item(int id, string name)
        {
            ItemID = id;
            ItemName = Plugin.GetLocaleManager().GetKey(name);
        }

        /// <summary>
        /// 未完成方法
        /// </summary>
        /// <param name="item">需要比较的物品</param>
        /// <returns></returns>
        public bool Equals(IItem item)
        {
            return (item.ItemID == ItemID);
        }
    }
}
