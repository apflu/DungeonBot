using Native.Csharp.App.UserInteract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Items.ItemTypes
{
    public interface IItem
    {
        int ItemID { get; }
        LocaleKey ItemName { get; set; }

        /// <summary>
        /// 比较两个物品是否完全相同；主要在ItemStack中使用，
        /// 因为完全相同的物品将会合并为同一ItemStack。
        /// </summary>
        /// <param name="item">需要比较的第二件物品</param>
        /// <returns></returns>
        bool Equals(IItem item);
    }
}
