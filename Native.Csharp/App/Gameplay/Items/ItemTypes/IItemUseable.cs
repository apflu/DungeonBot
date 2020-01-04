using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Items.ItemTypes
{
    public interface IItemUseable : Item
    {
        bool Use(Character user);
    }
}
