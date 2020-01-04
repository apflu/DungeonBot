using Native.Csharp.App.UserInteract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Geography.LocationUtil
{
    /// <summary>
    /// Location几乎是最小的单位，它的大小一般与一张战术地图相当。
    /// 它并不会在地图上规则排列。
    /// </summary>
    public class Location : ILocation
    {
        public Location(ILocation parentLocation)
        {
            HasParentLocation = true;
            ParentLocation = parentLocation;
        }

        public override void Register(Character character)
        {
            ParentLocation.Register(character);
            Characters.Add(character);
        }

        public override void Unregister(Character character)
        {
            ParentLocation.Unregister(character);
            Characters.Remove(character);
        }
    }
}
