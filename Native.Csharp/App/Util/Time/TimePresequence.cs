using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Native.Csharp.App.Util.Time
{
    public abstract class TimePresequence : ITimePresequence<TimeElement>
    {
        public abstract List<TimeElement> Presequence { get; set; }

        private Timer timer;
        private DateTime startTime;

        public delegate void PresequenceChangeHandler(TimePresequence sender);
        public event PresequenceChangeHandler PresequenceChangeEvent;

        public TimePresequence()
        {
            Presequence = new List<TimeElement>();
            PresequenceChangeEvent += Check;
        }

        public void Check(TimePresequence _)
        {
            if (Presequence[0].GetRemainTime() <= new TimeSpan(0))
                Finish();

            if (!IsEmpty())
                Start();
        }

        public void Start()
        {
            timer = new Timer()
            {
                AutoReset = false,
                Interval = Presequence[0].GetRemainTime().TotalMilliseconds
            };
            startTime = DateTime.Now;
            timer.Elapsed += Finish;
            timer.Start();
        }

        public void Pause()
        {
            Presequence[0].TimeSpent += DateTime.Now - startTime;
            timer.Dispose();
        }

        public void Add(TimeElement element)
        {
            element.StartInPresequence();
            Presequence.Add(element);
            PresequenceChangeEvent(this);
        }

        public void Clear()
        {
            foreach (TimeElement element in Presequence)
                element.EndInPresequence();
            Presequence.Clear();
            PresequenceChangeEvent(this);
        }

        public void RemoveAll(TimeElement target)
        {
            foreach (TimeElement match in Presequence.FindAll(element => element == target))
                match.EndInPresequence();
            Presequence.RemoveAll((element) => element == target);
            PresequenceChangeEvent(this);
        }

        public void Remove(TimeElement target)
        {
            Presequence.Find(element => element == target).EndInPresequence();
            Presequence.Remove(target);
            PresequenceChangeEvent(this);
        }

        public bool IsEmpty() => Presequence.Count == 0;

        private void Finish()
        {
            Presequence[0].FinishInPresequence();
            Presequence.RemoveAt(0);
            PresequenceChangeEvent(this);
        }

        private void Finish(object _e, ElapsedEventArgs _args) => Finish();

        public abstract DataSet Save();
    }
}
