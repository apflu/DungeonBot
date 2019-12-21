using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.CharacterUtil.Classes
{
    public abstract class CharacterClass
    {
        public byte Level { get; protected set; }
        public List<byte> HPGrowth { get; protected set; }

        public abstract void LevelUp();
    }
}
