using Native.Csharp.App.Gameplay.AbstractTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Items
{
    public class EquipmentSlot : ISlot<Equipment>
    {
        public Character Owner;
        public Predicate<Equipment> IsAllowedElement { get; protected internal set; }
        public Equipment ElementInSlot { get; protected set; }

        public EquipmentSlot()
        {

        }

        public bool Fit(Equipment equipment)
        {
            if (IsAllowedElement(equipment))
            {
                if (ElementInSlot != null)
                {
                    if (!Unfit())
                        return false;
                }
                equipment.Equip(Owner);
                ElementInSlot = equipment;
                return true;
            }
            return false;
        }
        public bool Unfit()
        {
            if (ElementInSlot != null)
            {
                ElementInSlot.Unequip(Owner);
                Owner.Inventory.AddItem(ElementInSlot);
                ElementInSlot = null;
            }
            return true;
        }
    }
}
