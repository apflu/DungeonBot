using Native.Csharp.App.Gameplay.Items.ItemTypes;
using Native.Csharp.App.Gameplay.Modifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Items.Foods
{
    public class Berry : Food
    {

        public Berry() : base()
        {
            DecayTime = DateTime.Now + new TimeSpan(3, 0, 0, 0);
            InternalName = "catnip";

            DisplayName = Plugin.LocaleManager.GetKey("ITEM_BERRY_NAME");
            Description = Plugin.LocaleManager.GetKey("ITEM_BERRY_DESCRIPTION");
        }

        public override void Decay()
        {

        }

        public override bool Use(Character user)
        {
            if(!IsDecayed)
            {
                user.Modifiers.NextHungerTime = DateTime.Now + new TimeSpan(16, 0, 0);
                user.Modifiers.RemoveModifier(new Fatigued(user));
            } else
            {
                //TODO
            }
            return true;
        }
    }
}
 