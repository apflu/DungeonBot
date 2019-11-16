using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay
{
    public class Player
    {

        //玩家基础信息
        public long QQID { get; private set; }

        public long LastGroupID { get; set; }

        private Character CurrentCharacter;

        public Inventory Inventory { get; protected set; }

        protected DateTime NextFreeTime { private get; set; }

        //玩家标签
        public ArrayList Flags;

        /// <summary>
        /// 使用QQ号来创建尚未登记的玩家
        /// </summary>
        /// <param name="qqID">QQ号</param>
        public Player(long qqID)
        {
            QQID = qqID;
            Inventory = new Inventory();

            Flags = new ArrayList();
        }

        /*
         * ===========================基础信息===========================
         * =                                                            =
         * =            这里列出了玩家的基础信息相关方法。              =
         * =                                                            =
         * ==============================================================
         */

        public string GetName()
        {
            return Common.CqApi.GetMemberInfo(LastGroupID, QQID).Nick;
        }

        /*
         * ===========================角色===========================
         * =                                                        =
         * =            这里列出了玩家的角色相关方法。              =
         * =                                                        =
         * ==========================================================
         */
        public Character GetCurrentCharacter()
        {
            if (CurrentCharacter == null)
            {
                Character[] characters = Plugin.GetCharacterHandler().GetCharacters(this);
                if ((characters != null) && (characters.Length != 0))
                {
                    CurrentCharacter = characters[0];
                }
            }
            return CurrentCharacter;
        }

        /// <summary>
        /// 选择当前所扮演的角色
        /// 注意：不检测角色是否归属该玩家！
        /// </summary>
        /// <param name="character">角色</param>
        /// <returns></returns>
        public bool SetCurrentCharacter(Character character)
        {
            if (Plugin.GetCharacterHandler().IsExist(character))
            {
                CurrentCharacter = character;
                return true;
            }
            return false;
        }

        public bool AddCharacter(Character character)
        {

        }

        public bool RemoveCharacter(Character character)
        {

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
        /// <returns>nullable</returns>
        public CharacterFlag GetFlag(string name)
        {
            foreach(CharacterFlag flag in Flags)
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
        /// <param name="name">属性名</param>
        /// <returns>成功true，失败false</returns>
        public bool RemoveFlag(string name)
        {
            CharacterFlag existedFlag = GetFlag(name);

            if (existedFlag != null)
                Flags.Remove(existedFlag);
            else
                return false;
            return true;
        }
    }
}
