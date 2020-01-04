using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Items.Herbs
{
    class Weed : Herb
    {
        public Weed() : base()
        {
            InternalName = "weed";
            DisplayName = Plugin.LocaleManager.GetKey("ITEM_WEED_NAME");
        }
        public override void Decay()
        {
            
        }

        public override bool Use(Character user)
        {
            return true;
        }
    }
}
