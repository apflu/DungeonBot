using Native.Csharp.App.UserInteract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Geography.LocationUtil
{
    public abstract class ILocation
    {
        public bool HasParentLocation { get; protected set; }
        public ILocation ParentLocation { get; protected set; }

        public List<Character> Characters { get; protected set; }
        public Dictionary<string, LocaleKey> Descriptions;
        public abstract void Unregister(Character character);
        public abstract void Register(Character character);
    }
}
