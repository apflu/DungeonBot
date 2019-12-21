using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Command
{
    public class CommandHandler
    {
        /// <summary>
        /// 提供一个“命令名->命令”的词典
        /// </summary>
        protected Dictionary<string, ICommand> Commands { get; private set; }

        /// <summary>
        /// 提供一个“命令调用名->命令”的词典
        /// </summary>
        public Dictionary<string, ICommand> CommandList { get; protected set; }

        public CommandHandler()
        {
            Commands = new Dictionary<string, ICommand>
            {
                { "AbandonItemCommand", new AbandonItemCommand() },
                { "ConfirmCharacterCommand", new ConfirmCharacterCommand() },
                { "CreateCharacterCommand", new CreateCharacterCommand() },
                { "DebugCommand", new DebugCommand() },
                { "GatherHerbCommand", new GatherHerbCommand() },
                { "PlayerChangeNameCommand", new PlayerChangeNameCommand() },
                { "PlayerInfoCommand", new PlayerInfoCommand() },
                { "SetCurrentCharacterCommand", new SetCurrentCharacterCommand() },
                { "ShowInventoryCommand", new ShowInventoryCommand() },
            };

            CommandList = new Dictionary<string, ICommand>
            {
                //{ "", Commands[""] },

                //系统
                
                { "&改名", Commands["PlayerChangeNameCommand"] },
                { "&改名字", Commands["PlayerChangeNameCommand"] },
                { "&玩家名", Commands["PlayerChangeNameCommand"] },
                { "&玩家改名", Commands["PlayerChangeNameCommand"] },
                { "&更名", Commands["PlayerChangeNameCommand"] },
                { "&更改玩家名", Commands["PlayerChangeNameCommand"] },
                { "&更改名字", Commands["PlayerChangeNameCommand"] },

                //玩家
                { "#创建角色", Commands["CreateCharacterCommand"] },
                { "#创建", Commands["CreateCharacterCommand"] },
                { "#发现", Commands["CreateCharacterCommand"] },
                { "#发现角色", Commands["CreateCharacterCommand"] },
                { "#寻找", Commands["CreateCharacterCommand"] },
                { "#寻找角色", Commands["CreateCharacterCommand"] },
                { "#找寻", Commands["CreateCharacterCommand"] },

                { "#招募角色", Commands["ConfirmCharacterCommand"] },
                { "#招募", Commands["ConfirmCharacterCommand"] },
                { "#确认角色", Commands["ConfirmCharacterCommand"] },
                { "#登记角色", Commands["ConfirmCharacterCommand"] },
                { "#登记", Commands["ConfirmCharacterCommand"] },

                { "#指定角色", Commands["SetCurrentCharacterCommand"] },
                { "#指定", Commands["SetCurrentCharacterCommand"] },
                { "#选择角色", Commands["SetCurrentCharacterCommand"] },
                { "#选择", Commands["SetCurrentCharacterCommand"] },
                { "#角色", Commands["SetCurrentCharacterCommand"] },

                { "#个人信息", Commands["PlayerInfoCommand"] },
                { "#玩家", Commands["PlayerInfoCommand"] },
                { "#玩家信息", Commands["PlayerInfoCommand"] },
                { "#我的信息", Commands["PlayerInfoCommand"] },
                { "#信息", Commands["PlayerInfoCommand"] },

                //角色
                { "*采集草药", Commands["GatherHerbCommand"] },
                { "*采集杂草", Commands["GatherHerbCommand"] },
                { "*采集", Commands["GatherHerbCommand"] },

                { "*丢弃物品", Commands["AbandonItemCommand"] },
                { "*丢弃", Commands["AbandonItemCommand"] },
                { "*丢掉", Commands["AbandonItemCommand"] },
                { "*丢", Commands["AbandonItemCommand"] },

                { "*显示物品栏", Commands["ShowInventoryCommand"] },
                { "*物品栏", Commands["ShowInventoryCommand"] },
                { "*显示物品", Commands["ShowInventoryCommand"] },
                { "*物品", Commands["ShowInventoryCommand"] },

                //
            };
        }

        public string[] Split(string message)
        {
            //拆分命令本体与参数
            return message.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
