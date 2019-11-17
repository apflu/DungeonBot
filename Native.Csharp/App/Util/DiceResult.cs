using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Util
{
    public class DiceResult
    {
        public string StrResult { get; private set; }
        public int IntResult { get; private set; }
        public DiceResult(string strResult, int intResult)
        {
            StrResult = strResult + "=" + intResult;
            IntResult = intResult;
        }
    }
}
