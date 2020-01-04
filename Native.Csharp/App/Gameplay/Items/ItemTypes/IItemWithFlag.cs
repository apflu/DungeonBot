using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Items.ItemTypes
{
    public interface IItemWithFlag
    {
        Dictionary<string, string> Flags { get; }
    }
}
