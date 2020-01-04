using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Items.Herbs
{
    public class SparkledFern : Herb
    {
        public SparkledFern() : base()
        {
            InternalName = "sparkled_fern";
            DisplayName = Plugin.LocaleManager.GetKey("ITEM_SPARKLED_FERN_NAME");
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
