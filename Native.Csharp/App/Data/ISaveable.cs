using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Data
{
    /// <summary>
    /// 所有能够保存的属性需要实现该接口。
    /// </summary>
    public interface ISaveable
    {
        DataSet Save();
    }
}
