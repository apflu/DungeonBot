using Native.Csharp.App.UserInteract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.AbstractTool
{
    /// <summary>
    /// 游戏元素代表一个拥有内部名、显示名与描述的基本结构。
    /// </summary>
    public interface IElement
    {
        string InternalName { get; set; }
        LocaleKey DisplayName { get; set; }
        LocaleKey Description { get; set; }
    }
}
