using Native.Csharp.App.Gameplay.CharacterUtil.Classes.Template;
using Native.Csharp.App.Gameplay.CharacterUtil.Skills;
using Native.Csharp.App.Gameplay.Generator;
using Native.Csharp.App.Gameplay.Modifiers;
using Native.Csharp.App.Gameplay.Modifiers.ModifierTypes;
using Native.Csharp.App.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.CharacterUtil
{
    public class CharacterProperties
    {

        public Character Owner { get; internal set; }

        public byte STR { get; internal set; }
        public byte DEX { get; internal set; }
        public byte CON { get; internal set; }
        public byte INT { get; internal set; }
        public byte WIS { get; internal set; }
        public byte CHA { get; internal set; }

        public byte HPCurrent { get; internal set; }
        public byte HPMax { get; internal set; }
        public int HPTemp { get; internal set; }

        public int XPCurrent { get; protected internal set; }
        public int XPLevelUp { get; }
        public int HealthDices { get; internal set; }
        public int ExtraHealthPointsPerLevel;
        public List<CharacterClass> Classes { get; }
        public bool HasPendingLevel;

        public int TotalSkillPoints;
        public int ExtraSkillPointsPerLevel;

        public CharacterSkills Skills { get; }

        public delegate void Upgrade(CharacterClass @class);
        public event Upgrade LevelUpEvent;

        private CharacterProperties()
        {
            Skills = new CharacterSkills();
            Classes = new List<CharacterClass>();
        }


        /// <summary>
        /// 某些情况下（例如不死生物和构造体）不存在某项属性，
        /// 那么就将其设置为255
        /// </summary>
        /// <param name="STR">力量</param>
        /// <param name="DEX">敏捷</param>
        /// <param name="CON">体质</param>
        /// <param name="INT">智力</param>
        /// <param name="WIS">感知</param>
        /// <param name="CHA">魅力</param>
        public CharacterProperties(byte STR, byte DEX, byte CON, byte INT, byte WIS, byte CHA)
            : this()
        {
            this.STR = STR;
            this.DEX = DEX;
            this.CON = CON;
            this.INT = INT;
            this.WIS = WIS;
            this.CHA = CHA;
        }

        public CharacterProperties(byte[] AbilityScores)
            : this(AbilityScores[0], AbilityScores[1], AbilityScores[2], AbilityScores[3], AbilityScores[4], AbilityScores[5]) { }
        public CharacterProperties(AbilityScoreGenerator generator)
            : this(generator.Results)
        {
        }

        public static string GetTributeName(int i)
        {
            switch (i)
            {
                case 0:
                    return "力量";
                case 1:
                    return "敏捷";
                case 2:
                    return "体质";
                case 3:
                    return "智力";
                case 4:
                    return "感知";
                case 5:
                    return "魅力";
            }
            return null;
        }

        public void AddXP(int amount)
        {
            XPCurrent += amount;
            if (XPCurrent > XPLevelUp)
                HasPendingLevel = true;
        }

        public void LevelUp(CharacterClass @class)
        {
            @class.LevelUp();
            CalcSP(@class);
            CalcHP(@class);
            LevelUpEvent(@class);

            HasPendingLevel = false;
        }

        private void CalcSP(CharacterClass @class)
        {
            int result = 0;

            result += @class.SkillPointPerLevel + Values.GetModifier(INT);
            result += ExtraSkillPointsPerLevel;

            TotalSkillPoints += result;
        }

        private void CalcHP(CharacterClass @class)
        {
            int result = 0;

            Dice HealthDice = Plugin.Values.GetDice("1d" + @class.HealthPointPerLevel);
            result += HealthDice.GetResult().IntResult;

            @class.HPGrowth.Add((byte)result);

            result += ExtraHealthPointsPerLevel;

            HPMax += (byte)result;
        }

        public void JoinClass(CharacterClass @class)
        {
            Classes.Add(@class);
            @class.LevelUp();
        }

        

        /// <summary>
        /// 检查角色是否已经能够被使用（以及能够行动）
        /// </summary>
        /// <returns>是否自寻死路</returns>
        public bool IsPrepared()
        {
            return
                STR > 0 &&
                DEX > 0 &&
                CON > 0 &&
                INT > 0 &&
                WIS > 0 &&
                CHA > 0 &&

                HPMax > 0 &&
                HPCurrent > 0
                ;
        }
    }
}
