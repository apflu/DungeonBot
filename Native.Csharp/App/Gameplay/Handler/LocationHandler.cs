using Native.Csharp.App.Gameplay.Geography.LocationUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Handler
{
    public class LocationHandler
    {
        private readonly Dictionary<string, ILocation> LocationList = new Dictionary<string, ILocation>();

        public ILocation GetLocation(string InternalName)
        {
            try
            {
                return LocationList[InternalName];
            } catch(KeyNotFoundException)
            {
                try
                {
                    //从数据库中加载地点
                } catch(Exception)
                {
                    //DebugSend
                }
            }
            return null;
        }
    }
}
