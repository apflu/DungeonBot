﻿using Native.Csharp.Sdk.Cqp.EventArgs;
using Native.Csharp.Sdk.Cqp.Interface;
using Native.Csharp.App.Util;
using System.Collections;

namespace Native.Csharp.App.Event
{
    /// <summary>
    /// Type=1003 应用被启用, 事件实现
    /// </summary>
    public class Event_CqAppEnable : ICqAppEnable
    {
        /// <summary>
		/// 处理 酷Q 的插件启动事件回调
		/// </summary>
		/// <param name="sender">事件的触发对象</param>
		/// <param name="e">事件的附加参数</param>
        public void CqAppEnable(object sender, CqAppEnableEventArgs e)
        {
            // 当应用被启用后，本方法将被调用。
            // 如果酷Q载入时应用已被启用，则在 ICqStartup 接口的实现方法被调用后，本方法也将被调用一次。
            // 如非必要，不建议在这里加载窗口。（可以添加菜单，让用户手动打开窗口）

            // 创建公用变量
            InitObjects();
            InitValues();

            Common.IsRunning = true;
            
        }

        private void InitObjects()
        {
            Plugin.SetMessageSender(new UserInteract.MessageSender());
            Plugin.SetLocaleManager(new UserInteract.LocaleManager());

            Plugin.SetPlayerHandler(new Gameplay.Handler.PlayerHandler());
            Plugin.SetCommandHandler(new Command.CommandHandler());
            Plugin.SetItemHandler(new Gameplay.Handler.ItemHandler());
            Plugin.SetHerbHandler(new Gameplay.Handler.HerbHandler());
            Plugin.SetCharacterHandler(new Gameplay.Handler.CharacterHandler());
            //Plugin.SetEventContainer(new Events.EventContainer());

            Plugin.GetMessageSender().DebugSend("Dungeon Bot启动完成！");
        }

        private void InitValues()
        {
            Plugin.Values = new Values();

            Plugin.GetLocaleManager().RegisterLocale(new UserInteract.LocaleDefault());
            //Plugin.GetLocaleManager().RegisterLocale(new UserInteract.LocaleLila());
        }
    }
}
