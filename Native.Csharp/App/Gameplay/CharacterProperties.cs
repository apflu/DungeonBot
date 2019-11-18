using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay
{
    public class CharacterProperties
    {
        public byte STR { get; internal set; }
        public byte DEX { get; internal set; }
        public byte CON { get; internal set; }
        public byte INT { get; internal set; }
        public byte WIS { get; internal set; }
        public byte CHA { get; internal set; }

        public byte HPCurrent { get; internal set; }
        public byte HPMax { get; internal set; }
        public int HPTemp { get; internal set; }

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
        {
            this.STR = STR;
            this.DEX = DEX;
            this.CON = CON;
            this.INT = INT;
            this.WIS = WIS;
            this.CHA = CHA;
        }

        public CharacterProperties(byte[] AbilityScores)
            : this(AbilityScores[0], AbilityScores[1], AbilityScores[2], AbilityScores[3], AbilityScores[4], AbilityScores[5]) {}

        public CharacterProperties(byte STR, byte DEX, byte CON, byte INT, byte WIS, byte CHA, byte maxHP)
            :this(STR, DEX, CON, INT, WIS, CHA)
        {
            HPMax = maxHP;
        }

        public static string GetTributeName(int i)
        {
            switch(i)
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

        /// <summary>
        /// 检查角色是否已经能够被使用（以及能够行动）
        /// 伊利丹梗
        /// </summary>
        /// <returns>是否自寻死路</returns>
        public bool IsPrepared()
        {
            return (
                (STR > 0) &&
                (DEX > 0) &&
                (CON > 0) &&
                (INT > 0) &&
                (WIS > 0) &&
                (CHA > 0) &&
                
                (HPMax > 0) &&
                (HPCurrent > 0)
                );
        }
    }
}
