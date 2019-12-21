using Native.Csharp.App.Gameplay.Modifiers.ModifierTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Modifiers
{
    public class Fatigued : IDebuff
    {
        private Character owner;
        public Fatigued(Character character)
        {
            owner = character;
        }

        /*
         * TODO: 更改降低属性的方式！
         * 当前方式在程序更复杂后可能导致不可预料的问题
         */
        public void EndEffect()
        {
            owner.Properties.STR += 2;
            owner.Properties.DEX += 2;
        }

        public void StartEffect()
        {
            owner.Properties.STR -= 2;
            owner.Properties.DEX -= 2;
        }
    }
}
