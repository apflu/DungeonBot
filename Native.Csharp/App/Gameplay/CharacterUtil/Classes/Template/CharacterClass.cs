using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.CharacterUtil.Classes.Template
{
    public abstract class CharacterClass
    {
        public Character Owner { get; internal set; }
        public List<Type> ClassSkills;

        public byte Level { get; protected set; }
        public List<byte> HPGrowth { get; protected set; }
        public int HealthPointPerLevel { get; protected set; }
        public int SkillPointPerLevel { get; protected set; }

        public abstract void LevelUp();



        public int CalcSPFromClass()
        {
            return Level * (SkillPointPerLevel
                + Values.GetModifier(Owner.Properties.INT)
                );
        }
    }
}
