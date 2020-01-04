using Native.Csharp.App.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Util.Time
{
    public interface ITimePresequence<TimeElement> : ISaveable
    {
        List<TimeElement> Presequence { get; set; }

        /// <summary>
        /// 添加一个项目到时间序列上
        /// </summary>
        void Add(TimeElement element);
        void RemoveAll(TimeElement target);

        /// <summary>
        /// 移除一个匹配项目
        /// </summary>
        /// <param name="target"></param>
        void Remove(TimeElement target);
        bool IsEmpty();
        void Clear();
    }
}
