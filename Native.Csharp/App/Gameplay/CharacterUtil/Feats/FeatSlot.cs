using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.CharacterUtil.Feats
{
    public class FeatSlot
    {
        public List<Feat> AllowedFeats { get; }
        public Feat Feat;

        public FeatSlot(params Feat[] allowedFeat) 
        {
            if (allowedFeat != null)
                AllowedFeats = allowedFeat.ToList();
        }

        public bool Fill(Feat feat)
        {
            if (IsFit(feat))
            {
                Feat = feat;
                return true;
            }
            return false;
        }

        public bool IsFit(Feat feat)
        {
            if (Feat != null)
                return false;

            foreach (Feat allowedFeat in AllowedFeats)
                if (feat == allowedFeat)
                    return true;
            return false;
        }

        /// <summary>
        /// 检查a是否是b的子集
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator <(FeatSlot a, FeatSlot b)
        {
            foreach (Feat allowedFeat in a.AllowedFeats)
            {
                if (!(b.IsFit(allowedFeat)))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 检查b是否是a的子集
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator >(FeatSlot a, FeatSlot b)
        {
            foreach (Feat allowedFeat in b.AllowedFeats)
            {
                if (!(a.IsFit(allowedFeat)))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 检查a是否与b完全相等
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool Equals(FeatSlot target)
        {
            return ((target > this) && (target < this));
        }
    }
}
