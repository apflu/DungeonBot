using Native.Csharp.App.Gameplay.CharacterUtil.Classes.Template;
using Native.Csharp.App.Gameplay.CharacterUtil.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.CharacterUtil.Classes
{
    /// <summary>
    /// 战士职业
    /// </summary>
    public class ClassFighter : CharacterClass
    {

        private ClassFighter()
        {
            HealthPointPerLevel = 10;
            SkillPointPerLevel = 2;

            ClassSkills = new List<Type>
            {
                typeof(Profession), typeof(Survival)
            };
        }

        public ClassFighter(Character owner)
        {
            Owner = owner;
            CharacterSkills skills = owner.Properties.Skills;
        }


        public override void LevelUp()
        {
            throw new NotImplementedException();
        }
    }
}
