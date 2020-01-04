using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Handler
{
    public class JobHandler
    {
        public const int MinutesGatherSingleHerb = 10;
        public const int MinutesGatherMultipleHerb = 12;

        private Dictionary<string, ArrayList> jobs = new Dictionary<string, ArrayList>
        {
            { "herb", new ArrayList
            {
                new TimeSpan(0, MinutesGatherSingleHerb, 0),
                new TimeSpan(0, MinutesGatherMultipleHerb, 0),
                Flag.Value_JobHerb,
                Flag.Key_JobHerb_Amount
            }},

        };

        protected void BeginJob(Character sender, int quantity, string job)
        {
            TimeSpan timeSingle = new TimeSpan(), baseTimeMultiple = new TimeSpan();
            string valueJob = "", keyAmount = "";

            try
            {
                ArrayList argsJob = jobs[job];
                timeSingle = (TimeSpan)argsJob[0];
                baseTimeMultiple = (TimeSpan)argsJob[1];
                valueJob = (string)argsJob[2];
                keyAmount = (string)argsJob[3];
            }
            catch (KeyNotFoundException)
            {
                throw new ArgumentException("无效的工作名！", "job");
            }
            catch (InvalidCastException e)
            {
                Plugin.MessageSender.DebugSend("JobHandler: 你Dictionary写错啦！\n" 
                    + e.ToString());
            }

            if (quantity > 1)
                sender.SetJob(valueJob, new TimeSpan(quantity * baseTimeMultiple.Ticks));
            else
                sender.SetJob( Flag.Value_JobHerb, timeSingle);

            //设置正在采集的数量
            sender.SetFlag(new Flag(Flag.Key_JobCurrent, Flag.Value_JobHerb));
            sender.SetFlag(new Flag(Flag.Key_JobHerb_Amount, quantity + ""));
        }
    }
}
