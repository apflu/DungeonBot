using Native.Csharp.App.Gameplay.Items.ItemTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Items
{
    public abstract class Herb : Food, IHerb
    {
        protected Herb()
        {
            DisplayName = Plugin.GetLocaleManager().GetKey("ITEM_UNKNOWN_HERB_NAME");
            Description = Plugin.GetLocaleManager().GetKey("ITEM_UNKNWON_HERB_DESCRIPTION");
        }
    }
}
