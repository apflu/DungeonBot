using Native.Csharp.App.Gameplay.Items.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Items.Herbs
{
    class HoneyBerry : Herb
    {
        public HoneyBerry() : base()
        {
            InternalName = "honey_berry";
            DisplayName = Plugin.LocaleManager.Keys["ITEM_HONEY_BERRY_NAME"];
            Description = Plugin.LocaleManager.Keys["ITEM_HONEY_BERRY_DESCRIPTION"];
        }
        public override void Decay()
        {
            throw new NotImplementedException();
        }

        public override bool Use(Character user)
        {
            (new Berry()).Use(user);
            user.Heal(1);

            return true;
        }
    }
}
