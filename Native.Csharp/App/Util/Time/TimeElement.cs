using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Util.Time
{
    public abstract class TimeElement
    {
        public TimeSpan Duration { get; }
        public TimeSpan TimeSpent { get; set; }
        protected TimeElement(TimeSpan duration)
        {
            Duration = duration;
            TimeSpent = new TimeSpan(0);
        }

        public TimeSpan GetRemainTime() => Duration - TimeSpent;

        public abstract void StartInPresequence();
        public abstract void EndInPresequence();
        public abstract void FinishInPresequence();
    }
}
