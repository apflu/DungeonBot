using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Items.Herbs
{
    public class Catnip : Herb
    {
        public Catnip() : base()
        {
            InternalName = "catnip";
            DisplayName = Plugin.LocaleManager.GetKey("ITEM_CATNIP_NAME");
        }
        public override void Decay()
        {
            
        }

        public override bool Use(Character user)
        {
            return false;
        }
    }
}
