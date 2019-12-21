using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Items.ItemTypes
{
    public interface IItemConsumable : IItemUseable
    {
        /// <summary>
        /// 物品的剩余使用次数
        /// </summary>
        int Charges { get; set; }
    }
}
