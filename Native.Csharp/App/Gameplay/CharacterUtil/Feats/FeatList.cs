using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.CharacterUtil.Feats
{
    public class FeatList
    {
        public List<FeatSlot> Feats { get; }

        FeatList()
        {
        }

        /// <summary>
        /// 选择最“严格”的
        /// </summary>
        /// <param name="feat"></param>
        /// <returns></returns>
        public bool Add(Feat feat)
        {
            Feats.Sort();
            foreach(FeatSlot slot in Feats)
                if (slot.IsFit(feat))
                {
                    slot.Fill(feat);
                    return true;
                }
            return false;
        }
    }
}
