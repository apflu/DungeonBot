using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay
{
    public class Character
    {
        //TODO: 继承ICloneable

        //private int cid;
        public Inventory Inventory { get; protected set; }
        public string Name { get; protected set; }
        public Player Owner { get; protected set; }

        public string IsCharacterFinished { get; protected set; }
        protected DateTime NextFreeTime { private get; set; }
        

        private ArrayList Flags;

        

        public Character(string name)
        {
            Inventory = new Inventory();
            Name = name;
            Owner = Plugin.GetPlayerHandler().PlayerWorld;
        }

        public Character SetOwner(Player owner)
        {
            Owner = owner;
            return this;
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
            return (NextFreeTime.Subtract(DateTime.Now) > TimeSpan.Zero);
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
            return GetFlag(CharacterFlag.FlagJobCurrent).Content != CharacterFlag.JobNone;
        }

        /// <summary>
        /// 注意：先判断是否有正在进行的工作！
        /// 将会清除现有的工作！
        /// </summary>
        /// <param name="job"></param>
        /// <param name="period"></param>
        public void SetJob(string job, TimeSpan period)
        {
            SetFlag(new CharacterFlag(CharacterFlag.FlagJobCurrent, job));
            AddBusyTime(period);
        }

        public void ClearJob()
        {
            SetFlag(new CharacterFlag(CharacterFlag.FlagJobCurrent, CharacterFlag.JobNone));
            NextFreeTime = DateTime.Now;
        }

        /*
         * ===========================Flag===========================
         * =                                                        =
         * =            这里列出了玩家的Flag相关方法。              =
         * =                                                        =
         * ==========================================================
         */

        /// <summary>
        /// 获取玩家的一项属性
        /// </summary>
        /// <param name="name">属性名</param>
        /// <returns>若不存在则为null</returns>
        public CharacterFlag GetFlag(string name)
        {
            foreach (CharacterFlag flag in Flags)
            {
                if (flag.Name == name)
                    return flag;
            }
            return null;
        }

        public void SetFlag(CharacterFlag flag)
        {
            CharacterFlag existedFlag = GetFlag(flag.Name);

            if (existedFlag != null)
                existedFlag.Content = flag.Content;
            else
                Flags.Add(flag);
        }

        /// <summary>
        /// 根据属性名，移除玩家的一项属性
        /// </summary>
        /// <param name="flagName">属性名</param>
        /// <returns>成功true，失败false</returns>
        public bool RemoveFlag(string flagName)
        {
            CharacterFlag existedFlag = GetFlag(flagName);

            if (existedFlag != null)
                Flags.Remove(existedFlag);
            else
                return false;
            return true;
        }

        public bool IsFlagExist(string flagName)
        {
            foreach(CharacterFlag flag in Flags)
            {
                if (flag.Name == flagName)
                    return true;
            }
            return false;
        }

        //TODO: 重写Equals(object)方法
    }
}
