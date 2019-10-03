using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Locale
{
    public class LocaleZHCN : LocaleType
    {
        public LocaleZHCN() : base("ZHCN")
        {
        }

        public new const string Locale_Command = "命令：";
        public new const string Locale_Description = "描述：";
        public new const string Locale_Usage = "用法：";

        public new const string Locale_RollDiceCommand = ".rd";
        public new const string Locale_RollDiceCommand_Description = "进行一次投骰，并输出结果。";
        public new const string Locale_RollDiceCommand_Usage = ".rd [数量]d[大小] 例如：.rd 1d20";
        public new const string Locale_RollDiceCommand_Result = "的结果是：";

    }
}
