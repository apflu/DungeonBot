using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.AbstractTool
{
    public interface ISlot<T>
    {
        Predicate<T> IsAllowedElement { get; }
        T ElementInSlot { get; }
        bool Fit(T element);
        bool Unfit();
    }
}
