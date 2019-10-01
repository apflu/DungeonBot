using Native.Csharp.App.Command.Interface;
using Native.Csharp.App.Commands.PointCommand;
using Native.Csharp.App.EventArgs;
using Native.Csharp.App.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Command
{
    public class CommandHandler
    {

        private List<ICommand> CommandList;
        private readonly Event.EventHandler EventHandler;

        public CommandHandler()
        {
            EventHandler = Values.GetEventHandler();
            
            CommandList.Add(new RollDiceCommand());
            CommandList.Add(new HelpCommand());
        }

        public void Execute(CqGroupMessageEventArgs message)
        {
            Player sender = Player.Parse(message.FromQQ);
            sender.SetCurrentGroup(message.FromGroup);

            Values.GetEventHandler().PlayerCommand(sender, SplitArgs(message.Message));
        }

        private string[] SplitArgs(string args)
        {
            return args.Split(' ');
        }

        public List<ICommand> GetCommandList()
        {
            return CommandList;
        }

        public void RegisterAllCommands()
        {
            CommandList.ForEach((command) =>
            {
                RegisterCommand(command);
            });
        }

        private Boolean RegisterCommand(ICommand command)
        {

            EventHandler.RegisterPlayerCommand(command.Register());
            
            return true;
        }

        public Boolean AddCommand(ICommand command)
        {
            if (CommandList.Contains(command))
                return false;
            else
            {
                CommandList.Add(command);
                RegisterCommand(command);

                return true;
            }
        }
    }
}
