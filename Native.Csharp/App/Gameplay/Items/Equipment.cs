using Native.Csharp.App.Gameplay.Items.ItemTypes;
using Native.Csharp.App.UserInteract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Items
{
    public abstract class Equipment : IEquipment
    {
        public enum Type
        {
            Weapon
        }
        public abstract string InternalName { get; set; }
        public abstract LocaleKey DisplayName { get; set; }
        public abstract LocaleKey Description { get; set; }

        public abstract bool Equals(Item item);
        public abstract void Equip(Character sender);
        public abstract void Unequip(Character sender);
    }
}
