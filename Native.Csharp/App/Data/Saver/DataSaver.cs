using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Native.Csharp.App.Data.Saver
{
    public static class DataSaver
    {
        public static DataSet AutoSaveData;
        public static Timer SaveTimer;

        public static void AutoSave(object _e, ElapsedEventArgs _) => Save(AutoSaveData);
        public static void Save(params DataSet[] dataSets)
        {
            DataSet AllData = new DataSet();
            foreach (DataSet dataSet in dataSets)
                AllData.Merge(dataSet);

            Plugin.MessageSender.DebugSend("合并数据完毕！");

            DirectoryInfo configDir = new DirectoryInfo(Common.AppDirectory);
            if (!configDir.Exists)
                configDir.Create();

            string dataFile = configDir.FullName + "data.xml";

            Plugin.MessageSender.DebugSend(configDir.FullName + "data." + DateTime.Now);

            if (File.Exists(dataFile))
                File.Copy(dataFile, configDir.FullName + "data." + DateTime.Now.Ticks);

            Plugin.MessageSender.DebugSend("正在保存文件…");

            File.WriteAllText(dataFile, AllData.GetXml());

            AllData.Dispose();
        }
    }
}
