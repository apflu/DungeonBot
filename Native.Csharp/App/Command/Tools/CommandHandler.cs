using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Command
{
    public class CommandHandler
    {
        public string[] Split(string message)
        {
            //拆分命令本体与参数
            return message.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
