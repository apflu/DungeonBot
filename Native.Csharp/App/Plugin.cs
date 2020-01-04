using Native.Csharp.App.Command;
using Native.Csharp.App.Data.Saver;
using Native.Csharp.App.Events;
using Native.Csharp.App.Gameplay.Geography;
using Native.Csharp.App.Gameplay.Handler;
using Native.Csharp.App.UserInteract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Native.Csharp.App
{
    public static class Plugin
    {
        public static MessageSender MessageSender { get; }
        public static LocaleManager LocaleManager { get; }

        public static PlayerHandler PlayerHandler { get; }
        public static CommandHandler CommandHandler { get; }
        public static ItemHandler ItemHandler { get; }
        public static HerbHandler HerbHandler { get; }
        public static CharacterHandler CharacterHandler { get; }
        public static EventContainer EventContainer { get; }

        public static Timer AutoSaveTimer { get; }


        public static Values Values { get; }
        

        static Plugin()
        {
            MessageSender = new MessageSender();
            LocaleManager = new LocaleManager();

            PlayerHandler = new PlayerHandler();
            CommandHandler = new CommandHandler();
            ItemHandler = new ItemHandler();
            HerbHandler = new HerbHandler();
            CharacterHandler = new CharacterHandler();
            EventContainer = new EventContainer();
            
            Values = new Values();
            
            AutoSaveTimer = new Timer()
            {
                Interval = 1800000,
                AutoReset = true,
                Enabled = true
            };
            AutoSaveTimer.Elapsed += DataSaver.AutoSave;
        }

        /*
         * ===========================变量Getter/Setter区域===========================
         * =                                                                         =
         * =                     推荐将Getter和Setter写在一起。                      =
         * =                                                                         =
         * ===========================================================================
         */

        //MessageSender
        public static MessageSender GetMessageSender()
        {
            return MessageSender;
        }

        //LocaleManager
        public static LocaleManager GetLocaleManager()
        {
            return LocaleManager;
        }

        //PlayerHandler
        public static PlayerHandler GetPlayerHandler() => PlayerHandler;

        //CommandHandler
        public static CommandHandler GetCommandHandler() => CommandHandler;


        //ItemHandler
        public static ItemHandler GetItemHandler() => ItemHandler;

        //HerbHandler
        public static HerbHandler GetHerbHandler() => HerbHandler;
        

        //CharacterHandler
        public static CharacterHandler GetCharacterHandler() => CharacterHandler;

    }
}
