using Native.Csharp.App.Data;
using Native.Csharp.App.Gameplay.CharacterUtil;
using Native.Csharp.App.Gameplay.CharacterUtil.Classes;
using Native.Csharp.App.Gameplay.CharacterUtil.Classes.Template;
using Native.Csharp.App.Gameplay.Generator;
using Native.Csharp.App.Gameplay.Geography.LocationUtil;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay
{
    public class Character : CharacterCore
    {
        //TODO: 继承ICloneable

        //private int cid;
        public string Name { get; protected set; }

        //基础信息
        public Inventory Inventory { get; protected set; }
        public Player Owner { get; protected set; }

        //附属类别
        public CharacterProperties Properties { get; internal set; }
        public CharacterModifiers Modifiers { get; internal set; }
        
        public ILocation CurrentLocation { get; protected set; }
        protected internal DateTime NextFreeTime { get; set; }

        public Character(string name)
            : base()
        {
            NextFreeTime = DateTime.Now;
            Name = name;
            Owner = Plugin.GetPlayerHandler().PlayerWorld;

            Inventory = new Inventory();
        }

        public Character(string name, Player owner)
            : this(name)
        {
            SetOwner(owner);
        }

        public Character(string name, AbilityScoreGenerator properties)
            : this(name)
        {
            Properties = new CharacterProperties(properties)
            {
                Owner = this
            };
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

        public string GetBusyTimeLeft(bool _)
        {
            TimeSpan timeLeft = GetBusyTimeLeft();
            string result = Name + "当前正忙！剩余时间：";
            if (timeLeft.Days != 0)
                result += timeLeft.Days + "天";
            if (timeLeft.Hours != 0)
                result += timeLeft.Hours + "小时";
            if (timeLeft.Minutes != 0)
                result += timeLeft.Minutes + "分钟";
            if (timeLeft.Seconds != 0)
                result += timeLeft.Seconds + "秒";
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
            return GetFlag(Flag.Key_JobCurrent).Value != Flag.Value_JobNone;
        }

        /// <summary>
        /// 注意：先判断是否有正在进行的工作！
        /// 将会清除现有的工作！
        /// </summary>
        /// <param name="job"></param>
        /// <param name="period"></param>
        public void SetJob(string job, TimeSpan period)
        {
            SetFlag(new Flag(Flag.Key_JobCurrent, job));
            AddBusyTime(period);
        }

        public void ClearJob()
        { 
            SetFlag(new Flag(Flag.Key_JobCurrent, Flag.Value_JobNone));
            NextFreeTime = DateTime.Now;
        }

        public void Rest()
        {
            Modifiers.NextFatigueTime = DateTime.Now + Values.Day;
            Heal(Properties.HealthDices);
        }

        /*
         * ===========================属性===========================
         * =                                                        =
         * =            这里列出了玩家的属性相关方法。              =
         * =                                                        =
         * ==========================================================
         */

        public GameAction Heal(int amount, Flag flagSource, bool isExceedHPTempHP = false)
        {
            GameAction result = new GameAction();
            result.SetFlag(
                Plugin.Values.Flag_ActionHeal, //是一个治疗动作
                flagSource, //来源于…
                new Flag(Flag.Action_FlagName_Object, GetFlag(Flag.Char_FlagName_TypeCharacter).Value), //目标是（我自己）
                new Flag(Flag.Action_FlagName_Object, Name) //我自己又是谁
                );

            
            return result;
        }

        public void Heal(int amount, bool isExceedHPTempHP = false)
        {
            if (Owner != null)
            {
                Owner.Reply(""); //TODO: 受到治疗的提示信息
            }
            Properties.HPCurrent += (byte)amount;
            if (Properties.HPCurrent > Properties.HPMax)
            {
                byte exceededHeal = (byte)(Properties.HPCurrent - Properties.HPMax);

                Properties.HPCurrent = Properties.HPMax;

                if (isExceedHPTempHP)
                {
                    Properties.HPTemp += exceededHeal;
                }
            }
        }

        /*
         * ===========================移动===========================
         * =                                                        =
         * =            这里列出了玩家的移动相关方法。              =
         * =                                                        =
         * ==========================================================
         */

        /// <summary>
        /// 将角色移动到一个新的位置
        /// 注意：尽可能将角色移动至最符合其所在地点的位置。
        /// </summary>
        /// <param name="newLocation"></param>
        public void Move(ILocation newLocation)
        {
            CurrentLocation.Unregister(this);
            newLocation.Register(this);
        }

        

        //TODO: 重写Equals(object)方法
    }
}
