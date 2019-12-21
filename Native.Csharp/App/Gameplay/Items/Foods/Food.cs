using Native.Csharp.App.Gameplay.Items.ItemTypes;
using Native.Csharp.App.UserInteract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Items.Foods
{
    public abstract class Food: IFood
    {
        public int ItemID { get; }
        public LocaleKey ItemName { get; set; }
        public int Charges { get; set; }
        public DateTime DecayTime { get; set; }
        public bool IsDecayed { get; set; }

        public abstract void Decay();

        public abstract bool Use(Character user);

        public bool Equals(IItem item)
        {
            return (item.ItemID == ItemID) && (((IFood)item).DecayTime == DecayTime);
        }
    }
}
