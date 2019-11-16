using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay
{
    public class CharacterProperties
    {
        public byte STR, DEX, CON, INT, WIS, CHA;

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
    }
}
