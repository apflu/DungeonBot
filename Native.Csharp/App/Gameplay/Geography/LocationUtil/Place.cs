using Native.Csharp.App.UserInteract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Geography.LocationUtil
{
    /// <summary>
    /// Place是一个较大的地点，指一个城镇、一个地城、一处地穴
    /// 或是其他类似大小的地点。
    /// </summary>
    public class Place : ILocation
    {
        public override void Register(Character character)
        {
            Characters.Add(character);
        }

        public override void Unregister(Character character)
        {
            Characters.Remove(character);
        }
    }
}
