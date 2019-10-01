using Native.Csharp.App.Mysql;
using System;

using Native.Csharp.App.Command;
using Native.Csharp.App.Util.Message;
using Native.Csharp.App.Locale;

namespace Native.Csharp.App.Util
{
    public static class Values
    {
        //General status
        public static Boolean PluginEnabled = false;

        //pattern
        public const String PatternCommand = "^[\\.\\*\\&\\#]";

        //SQL
        

        public const String SQL_Credit = "server=127.0.0.1;port=3306;database=DungeonRPG;user=QBot;password=Meowtainaut";

        public const String SQL_Command_Status_Get = "SELECT status FROM status WHERE qqid={0}";
        public const String SQL_Command_Status_Set = "UPDATE status SET status={0} WHERE qqid={0}";
        public const String SQL_Command_Status_Init = "INSERT INTO status(qq_id, status) VALUES({0}, {0})";
        

        private static ConnectManager connectManager;
        private static Event.EventHandler eventHandler;
        private static CommandHandler commandHandler;
        
        public static MessageSender messageSender { get; set; }

        /// <summary>
        /// read-only, no longer avaliable after it's set
        /// </summary>
        /// <param name="manager"></param>
        public static void SetConnectManager(ConnectManager manager) 
        {
            if(connectManager == null)
                connectManager = manager;
        }

        public static ConnectManager GetConnectManager()
        {
            return connectManager;
        }

        public static void SetEventHandler(Event.EventHandler handler)
        {
            if (eventHandler == null)
                eventHandler = handler;
        }

        public static Event.EventHandler GetEventHandler()
        {
            return eventHandler;
        }

        public static void SetCommandHandler(CommandHandler handler)
        {
            if (commandHandler == null)
                commandHandler = handler;
        }

        public static CommandHandler GetCommandHandler()
        {
            return commandHandler;
        }

        public static LocaleManager GetLocaleManager()
        {
            //TODO
        }


    }
}
