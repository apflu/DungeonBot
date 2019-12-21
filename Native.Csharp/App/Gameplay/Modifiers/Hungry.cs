using Native.Csharp.App.Gameplay.Modifiers.ModifierTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Modifiers
{
    public class Hungry: IDebuff
    {
        private Character owner;
        public Hungry(Character character)
        {
            owner = character;
        }

        public void StartEffect()
        {
            owner.SetFlag(Plugin.Values.Flag_CanNotBenefitFromRest);
            owner.Modifiers.AddModifier(new Fatigued(owner));
        }

        public void EndEffect()
        {
            owner.SetFlag(Plugin.Values.Flag_CanBenefitFromRest);
            owner.Modifiers.RemoveModifier(new Fatigued(owner));
        }
    }
}
