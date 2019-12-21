using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Modifiers.ModifierTypes
{
    public interface IModifierExpirable: IModifier
    {
        DateTime ExpireTime { get; set; }
    }
}
