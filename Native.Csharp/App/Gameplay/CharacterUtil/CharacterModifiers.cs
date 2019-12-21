using Native.Csharp.App.Gameplay.Modifiers;
using Native.Csharp.App.Gameplay.Modifiers.ModifierTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.CharacterUtil
{
    public class CharacterModifiers
    {
        public List<IModifier> Modifiers { get; }
        public DateTime NextHungerTime;
        public Character Owner;

        public CharacterModifiers(Character player)
        {
            Owner = player;
            NextHungerTime = DateTime.Now + Values.Day;
        }

        public bool AddModifier(IModifier modifier)
        {
            foreach (IModifier existedModifier in Modifiers)
            {
                if (existedModifier.GetType().Name == modifier.GetType().Name)
                    //TODO: 可叠加的调整状态
                    if (modifier is IModifierExpirable &&
                        ((IModifierExpirable)modifier).ExpireTime < ((IModifierExpirable)existedModifier).ExpireTime)
                    {
                        RemoveModifier(existedModifier);
                        EnlistModifier(modifier);
                        return true;
                    }
                return false;
            }
            EnlistModifier(modifier);
            return true;
        }

        private void EnlistModifier(IModifier modifier)
        {
            modifier.StartEffect();
            Modifiers.Add(modifier);
        }

        public bool RemoveModifier(IModifier modifier)
        {
            foreach (IModifier existedModifier in Modifiers)
            {
                if (existedModifier.GetType().Name == modifier.GetType().Name)
                {
                    modifier.EndEffect();
                    Modifiers.Remove(existedModifier);
                    return true;
                }
            }
            return false;
        }

        public void DoNextMinute()
        {
            if (NextHungerTime < DateTime.Now)
            {
                Modifiers.Add(new Hungry(Owner));
            }
        }


    }
}
