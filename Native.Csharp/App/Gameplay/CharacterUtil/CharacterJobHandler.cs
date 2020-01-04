using Native.Csharp.App.Gameplay.Jobs;
using Native.Csharp.App.Util.Time;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.CharacterUtil
{
    public class CharacterJobHandler //: TimePresequence
    {
        public Character Owner;
        protected internal DateTime NextFreeTime { get; set; }

        public CharacterJobHandler()
        {
            //Presequence = new List<TimeElement>();
        }

        /*
         * ===========================忙碌时间===========================
         * =                                                            =
         * =            这里列出了玩家的忙碌时间相关方法。              =
         * =                                                            =
         * ==============================================================
         */

        /// <summary>
        /// 判断玩家是否忙碌
        /// </summary>
        /// <returns></returns>
        public bool IsCurrentBusy()
        {
            return NextFreeTime.Subtract(DateTime.Now) > TimeSpan.Zero;
        }

        /// <summary>
        /// 返回剩余的忙碌时间
        /// </summary>
        /// <returns></returns>
        public TimeSpan GetBusyTimeLeft()
        {
            TimeSpan timeLeft = NextFreeTime.Subtract(DateTime.Now);

            if (timeLeft > TimeSpan.Zero)
                return timeLeft;
            return TimeSpan.Zero;
        }

        /// <summary>
        /// 添加忙碌时间
        /// 注意：先判断是否忙碌！
        /// </summary>
        public void AddBusyTime(TimeSpan timeSpan)
        {
            NextFreeTime = DateTime.Now;
            NextFreeTime = NextFreeTime.Add(timeSpan);
        }

        /// <summary>
        /// 减少忙碌时间
        /// </summary>
        /// <param name="timeSpan"></param>
        public void ReduceBusyTime(TimeSpan timeSpan)
        {
            NextFreeTime.Subtract(timeSpan);
        }

        public string GetBusyTimeLeft(bool _)
        {
            TimeSpan timeLeft = GetBusyTimeLeft();
            string result = Owner.Name + "当前正忙！剩余时间：";
            result += Values.TimeToString(timeLeft);
            return result;
        }

        /*
         * ===========================工作===========================
         * =                                                        =
         * =            这里列出了玩家的工作相关方法。              =
         * =                                                        =
         * ==========================================================
         */

        /*
         * 须知：这些方法仅仅是提供了一些简便方法，以及作为调用/设定Flag的例子，
         * 你仍然可以通过直接访问Flag来做到相同的事情。
         */
        public bool HasFinishedJob()
        {
            return IsDoingJob() && !IsCurrentBusy();
        }

        public bool IsDoingJob()
        {
            return Owner.GetFlag(Flag.Key_JobCurrent).Value != Flag.Value_JobNone;
        }

        /// <summary>
        /// 注意：先判断是否有正在进行的工作！
        /// 将会清除现有的工作！
        /// </summary>
        /// <param name="job"></param>
        /// <param name="period"></param>
        public void SetJob(string job, TimeSpan period)
        {
            Owner.SetFlag(new Flag(Flag.Key_JobCurrent, job));
            AddBusyTime(period);
        }

        public void ClearJob()
        {
            Owner.SetFlag(new Flag(Flag.Key_JobCurrent, Flag.Value_JobNone));
            NextFreeTime = DateTime.Now;
        }
    }
}
