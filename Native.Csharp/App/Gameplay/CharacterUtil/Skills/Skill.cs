using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Csharp.App.Gameplay.AbstractTool;
using Native.Csharp.App.UserInteract;

namespace Native.Csharp.App.Gameplay.CharacterUtil.Skills
{
    public abstract class Skill : IElement
    {

        public Character Owner { get; internal set; }
        public int SkillLevel { get; protected internal set; }
        public bool IsClassSkill { get; protected internal set; }
        public string InternalName { get; set; }
        public LocaleKey DisplayName { get; set; }
        public LocaleKey Description { get; set; }

        /// <summary>
        /// 获取升级至下一等级的技能点需求
        /// 如果无法再升级，返回-1
        /// </summary>
        /// <returns>下一等级的技能点需求</returns>
        public int GetNextLevelCost()
        {
            int HD = Owner.Properties.HealthDices;
            int maxSkillLevel = IsClassSkill ? HD : HD + 3;

            if (SkillLevel < maxSkillLevel)
                return (IsClassSkill && (SkillLevel < 3)) ? 0 : 1;
            return -1;
        }

        public bool Check(int DC, bool is20AutoSuccess = false)
        {
            int result = Plugin.Values.GetDice("1d20").GetResult().IntResult;
            if (is20AutoSuccess && (result == 20))
                return true;

            return (result + GetTotalModifier()) >= DC;
        }

        public bool Check10(int DC)
        {
            return (10 + GetTotalModifier()) >= DC;
        }

        public bool Check20(int DC)
        {
            return (20 + GetTotalModifier()) >= DC;
        }

        //先别着急
        public abstract int GetTotalModifier();
    }
}
