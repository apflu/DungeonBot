using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay
{
    public class GameAction
    {
        public string Type { get; protected set; }

        public const string TypeSelf = "Self";
        public const string TypeEnvironment = "Environment";
        public const string TypeTime = "Time";

        public const string TypeCharacter = "Character";

        public Character SourceCharacter;

        public GameAction(string type)
        {
            Type = type;
        }

        public GameAction(Character character)
        {
            Type = TypeCharacter;
            SourceCharacter = character;
        }
    }
}
