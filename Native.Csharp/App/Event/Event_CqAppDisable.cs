﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Csharp.App.Data.Saver;
using Native.Csharp.Sdk.Cqp.EventArgs;
using Native.Csharp.Sdk.Cqp.Interface;

namespace Native.Csharp.App.Event
{
    /// <summary>
	/// Type=1004 应用被禁用, 事件实现
	/// </summary>
    public class Event_CqAppDisable : ICqAppDisable
    {
        /// <summary>
		/// 处理 酷Q 的插件关闭事件回调
		/// </summary>
		/// <param name="sender">事件的触发对象</param>
		/// <param name="e">事件的附加参数</param>
        public void CqAppDisable(object sender, CqAppDisableEventArgs e)
        {
            // 当应用被停用前，本方法将被调用一次
            // 如果酷Q载入时应用已被停用，则本方法【不会】被调用。
            // 无论本应用是否被启用，酷Q关闭前本方法都【不会】被调用。
            try
            {
                SaveData();
            }
            catch (Exception ex)
            {
                DirectoryInfo configDir = new DirectoryInfo(Common.AppDirectory);
                if (!configDir.Exists)
                    configDir.Create();
                File.WriteAllText(configDir.FullName + "log.txt", ex.ToString());
            }

            Common.IsRunning = false;
        }

        private void SaveData()
        {
            
            DataSaver.Save(Plugin.PlayerHandler.Save(), Plugin.CharacterHandler.Save());
        }


    }
}
