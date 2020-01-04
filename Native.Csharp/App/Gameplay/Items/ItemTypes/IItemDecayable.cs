using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Items.ItemTypes
{
    public interface IItemDecayable : Item
    {
        DateTime DecayTime { get; set; }
        bool IsDecayed { get; set; }

        /// <summary>
        /// 在物品腐烂时调用：标注IsDecayed、转化物品、腐烂事件……
        /// </summary>
        void Decay();
    }
}
