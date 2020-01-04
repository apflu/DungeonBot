using Native.Csharp.App.Gameplay.CharacterUtil.Classes.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.CharacterUtil.Classes
{
    /// <summary>
    /// 法师
    /// （强无敌！）
    /// </summary>
    public class ClassWizard : ArcaneCaster
    {
        public ClassWizard()
        {
            HealthPointPerLevel = 6; //法师拥有d6的基础生命骰
            SkillPointPerLevel = 2; //法师拥有2+INT的技能点
        }

        /// <summary>
        /// 在职业升级时会被调用的方法
        /// </summary>
        public override void LevelUp()
        {
            
        }
    }
}
