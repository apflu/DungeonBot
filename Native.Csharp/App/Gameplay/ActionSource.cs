using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay
{
    public class ActionSource
    {
        public string Type { get; protected set; }

        public const string TypeSelf = "Self";
        public const string TypeEnvironment = "Environment";
        public const string TypeTime = "Time";

        public const string TypeCharacter = "Character";

        public Character SourceCharacter;

        public ActionSource(string type)
        {
            Type = type;
        }

        public ActionSource(Character character)
        {
            Type = TypeCharacter;
            SourceCharacter = character;
        }
    }
}
