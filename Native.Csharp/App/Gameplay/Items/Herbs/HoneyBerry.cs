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
        public override void Decay()
        {
            throw new NotImplementedException();
        }

        public override bool Use(Character user)
        {
            (new Berry()).Use(user);
            user.Heal(Plugin.Values.GetDice("1d4").GetResult().IntResult, Plugin.Values.Flag_FromNature);

            return true;
        }
    }
}
