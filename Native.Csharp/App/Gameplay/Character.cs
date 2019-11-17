using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay
{
    public class Character : Flagable, IFlagable
    {
        //TODO: 继承ICloneable

        //private int cid;
        public Inventory Inventory { get; protected set; }
        public string Name { get; protected set; }
        public Player Owner { get; protected set; }
        public CharacterProperties Properties { get; }

        public string IsCharacterFinished { get; protected set; }
        protected DateTime NextFreeTime { private get; set; }

        public Character(string name)
            :base()
        {
            NextFreeTime = DateTime.Now;
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
            return GetFlag(Flag.Char_FlagName_JobCurrent).Content != Flag.Char_FlagContent_JobNone;
        }

        /// <summary>
        /// 注意：先判断是否有正在进行的工作！
        /// 将会清除现有的工作！
        /// </summary>
        /// <param name="job"></param>
        /// <param name="period"></param>
        public void SetJob(string job, TimeSpan period)
        {
            SetFlag(new Flag(Flag.Char_FlagName_JobCurrent, job));
            AddBusyTime(period);
        }

        public void ClearJob()
        {
            SetFlag(new Flag(Flag.Char_FlagName_JobCurrent, Flag.Char_FlagContent_JobNone));
            NextFreeTime = DateTime.Now;
        }

        /*
         * ===========================属性===========================
         * =                                                        =
         * =            这里列出了玩家的属性相关方法。              =
         * =                                                        =
         * ==========================================================
         */

        public GameAction AddHP(int amount, Flag flagSource, bool isExceedHPTempHP = false)
        {
            GameAction result = new GameAction();
            result.SetFlag(
                Plugin.Values.Flag_ActionHeal, //是一个治疗动作
                flagSource, //来源于…
                new Flag(Flag.Action_FlagName_Object, GetFlag(Flag.Char_FlagName_TypeCharacter).Content), //目标是（我自己）
                new Flag(Flag.Action_FlagName_Object, Name) //我自己又是谁
                );

            Properties.HPCurrent += (byte) amount;
            if(Properties.HPCurrent > Properties.HPMax)
            {
                byte exceededHeal = (byte) (Properties.HPCurrent - Properties.HPMax);

                Properties.HPCurrent = Properties.HPMax;

                if (isExceedHPTempHP)
                {
                    Properties.HPTemp += exceededHeal;
                    result.SetFlag(new Flag(Flag.Action_FlagName_TypeHeal_Overheal, exceededHeal + ""));
                }
            }
            return result;
        }

        //TODO: 重写Equals(object)方法
    }
}
