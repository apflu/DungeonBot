using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay
{
    public class Flagable : IFlagable
    {
        private readonly ArrayList Flags;

        internal Flagable()
        {
            Flags = new ArrayList();
        }

        /// <summary>
        /// 获取玩家的一项属性
        /// </summary>
        /// <param name="name">属性名</param>
        /// <returns>若不存在则为null</returns>
        public Flag GetFlag(string name)
        {
            foreach (Flag flag in Flags)
            {
                if (flag.Name == name)
                    return flag;
            }
            return null;
        }

        public void SetFlag(params Flag[] flags)
        {
            foreach(Flag flag in flags)
            {
                Flag existedFlag = GetFlag(flag.Name);

                if (existedFlag != null)
                    existedFlag.Content = flag.Content;
                else
                    Flags.Add(flag);
            }
        }

        /// <summary>
        /// 根据属性名，移除玩家的一项属性
        /// </summary>
        /// <param name="flagName">属性名</param>
        /// <returns>成功true，失败false</returns>
        public bool RemoveFlag(string flagName)
        {
            Flag existedFlag = GetFlag(flagName);

            if (existedFlag != null)
                Flags.Remove(existedFlag);
            else
                return false;
            return true;
        }

        public bool IsFlagExist(string flagName)
        {
            foreach (Flag flag in Flags)
            {
                if (flag.Name == flagName)
                    return true;
            }
            return false;
        }
    }
}
