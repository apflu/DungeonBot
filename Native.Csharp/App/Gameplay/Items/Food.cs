using Native.Csharp.App.Gameplay.Items.ItemTypes;
using Native.Csharp.App.UserInteract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Items
{
    public abstract class Food : IFood
    {
        public string InternalName { get; set; }
        public LocaleKey DisplayName { get; set; }
        public LocaleKey Description { get; set; }
        public int Charges { get; set; }
        public DateTime DecayTime { get; set; }
        public bool IsDecayed { get; set; }

        protected Food()
        {
            DisplayName = Plugin.LocaleManager.GetKey("ITEM_UNKNOWN_FOOD_NAME");
            Description = Plugin.LocaleManager.GetKey("ITEM_UNKNOWN_FOOD_DESCRIPTION");
        }

        public abstract void Decay();

        public abstract bool Use(Character user);

        public bool Equals(Item item)
        {
            return item.InternalName == InternalName && ((IFood)item).DecayTime == DecayTime;
        }
    }
}
