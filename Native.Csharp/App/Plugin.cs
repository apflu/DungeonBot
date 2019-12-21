using Native.Csharp.App.Command;
using Native.Csharp.App.Events;
using Native.Csharp.App.Gameplay.Handler;
using Native.Csharp.App.UserInteract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App
{
    public static class Plugin
    {
        private static MessageSender messageSender;
        private static LocaleManager localeManager;

        private static PlayerHandler playerHandler;
        private static CommandHandler commandHandler;
        private static ItemHandler itemHandler;
        private static HerbHandler herbHandler;
        private static CharacterHandler characterHandler;

        private static EventContainer eventContainer;

        public static Values Values;

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
            return messageSender;
        }

        public static bool SetMessageSender(MessageSender sender)
        {
            if (messageSender == null)
            {
                messageSender = sender;
                return true;
            }
            return false;

        }

        //LocaleManager
        public static LocaleManager GetLocaleManager()
        {
            return localeManager;
        }

        public static bool SetLocaleManager(LocaleManager manager)
        {
            if(localeManager == null)
            {
                localeManager = manager;
                return true;
            }
            return false;
        }

        //PlayerHandler
        public static PlayerHandler GetPlayerHandler() => playerHandler;

        public static bool SetPlayerHandler(PlayerHandler handler)
        {
            if(playerHandler == null)
            {
                playerHandler = handler;
                return true;
            }
            return false;
        }

        //CommandHandler
        public static CommandHandler GetCommandHandler() => commandHandler;

        public static bool SetCommandHandler(CommandHandler handler)
        {
            if (commandHandler == null)
            {
                commandHandler = handler;
                return true;
            }
            return false;
        }


        //ItemHandler
        public static ItemHandler GetItemHandler() => itemHandler;

        public static bool SetItemHandler(ItemHandler handler)
        {
            if (itemHandler == null)
            {
                itemHandler = handler;
                return true;
            }
            return false;
        }

        //HerbHandler
        public static HerbHandler GetHerbHandler() => herbHandler;

        public static bool SetHerbHandler(HerbHandler handler)
        {
            if (herbHandler == null)
            {
                herbHandler = handler;
                return true;
            }
            return false;
        }

        //CharacterHandler
        public static CharacterHandler GetCharacterHandler() => characterHandler;

        public static bool SetCharacterHandler(CharacterHandler handler)
        {
            if (characterHandler == null)
            {
                characterHandler = handler;
                return true;
            }
            return false;
        }

        //EventContainer
        public static EventContainer GetEventContainer() => eventContainer;

        public static bool SetEventContainer(EventContainer container)
        {
            if (eventContainer == null)
            {
                eventContainer = container;
                return true;
            }
            return false;
        }
    }
}
