using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.CharacterUtil.Feats
{
    public abstract class Feat
    {
        /// <summary>
        /// 当专长满足前提条件并被启用时的方法
        /// </summary>
        public void OnEnable()
        {

        }

        /// <summary>
        /// 当专长被禁用（或不满足前提条件）时的方法
        /// </summary>
        public void OnDisable()
        {

        }
    }
}
