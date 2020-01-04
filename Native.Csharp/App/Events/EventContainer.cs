using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Native.Csharp.App.Events
{
    public class EventContainer
    {
        public delegate void MinuteEvent();
        public event MinuteEvent MinutePassed;

        public enum Priority
        {
            Lowest, Low, Normal, High, Highest
        }

        public void NextMinute(object sender, ElapsedEventArgs e)
        {
            MinutePassed();
        }

    }
}
