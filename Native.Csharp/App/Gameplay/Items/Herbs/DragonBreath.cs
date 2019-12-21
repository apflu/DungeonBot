using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Items.Herbs
{
    public class DragonBreath : Herb
    {
        public override void Decay()
        {
        }

        public override bool Use(Character user)
        {
            return false;
        }
    }
}
