using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Native.Csharp.App
{
    public class EventList
    {
        public Timer MinuteTimer;
        public EventList()
        {
            MinuteTimer = new Timer(60000)
            {
                Enabled = true
            };
            MinuteTimer.Start();
            MinuteTimer.Elapsed += new ElapsedEventHandler(Plugin.GetEventContainer().NextMinute);
        }
    }
}
