using Native.Csharp.App.Gameplay.AbstractTool;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay
{
    public class GameAction : Flagable, IFlagable
    {
        public Character SourceCharacter;

        public DateTime Time { get; protected internal set; }

        public GameAction()
        {
            Time = DateTime.Now;
        }
    }
}
