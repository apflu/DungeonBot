using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Items.ItemTypes
{
    public interface IEquipment : Item
    {
        void Equip(Character sender);
        void Unequip(Character sender);
    }
}
