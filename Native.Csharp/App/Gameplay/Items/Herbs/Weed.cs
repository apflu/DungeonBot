using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Items.Herbs
{
    class Weed : Herb
    {
        public override void Decay()
        {
            
        }

        public override bool Use(Character user)
        {
            return true;
        }
    }
}
