using Native.Csharp.App.Gameplay.AbstractTool;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay
{
    public abstract class Flagable : IFlagable
    {
        protected internal readonly List<Flag> Flags;

        internal Flagable()
        {
            Flags = new List<Flag>();
        }

        /// <summary>
        /// 获取一项属性
        /// </summary>
        /// <param name="name">属性名</param>
        /// <returns>若不存在则为null</returns>
        public Flag GetFlag(string name)
        {
            foreach (Flag flag in Flags)
            {
                if (flag.Key == name)
                    return flag;
            }
            return null;
        }

        public void SetFlag(params Flag[] flags)
        {
            foreach(Flag flag in flags)
            {
                Flag existedFlag = GetFlag(flag.Key);

                if (existedFlag != null)
                    existedFlag.Value = flag.Value;
                else
                    Flags.Add(flag);
            }
        }

        /// <summary>
        /// 根据属性名，移除一项属性
        /// </summary>
        /// <param name="flagName">属性名</param>
        /// <returns>成功true，失败false</returns>
        public bool RemoveFlag(string flagName)
        {
            Flag existedFlag = GetFlag(flagName);

            if (existedFlag != null)
            {
                return Flags.Remove(existedFlag);
            }
            return false;
        }

        public bool RemoveFlag(Flag flag) => Flags.Remove(flag);

        public bool IsFlagExist(string flagName)
        {
            foreach (Flag flag in Flags)
            {
                if (flag.Key == flagName)
                    return true;
            }
            return false;
        }
    }
}
