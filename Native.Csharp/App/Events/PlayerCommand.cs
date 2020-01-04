using Native.Csharp.App.Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Events
{
    public class PlayerCommand
    {
        public delegate void PlayerCommandHandler(Player sender, string[] args);
        public event PlayerCommandHandler PlayerCommandEvent;

        private List<CommandHandler> handlers;

        PlayerCommand()
        {
            handlers = new List<CommandHandler>();
        }

        public void OnPlayerCommand(Player sender, string[] args)
        {

        }

        public void Register(PlayerCommandHandler handler) 
        {

        }

        public void Register(PlayerCommandHandler handler, EventContainer.Priority priority)
        {

        }

        public void Stop()
        {

        }

        class CommandHandler : IComparable
        {
            private EventContainer.Priority priority;
            public PlayerCommandHandler handler;
            public int CompareTo(object obj)
            {
                try
                {
                    CommandHandler target = (CommandHandler)obj;
                    if (priority == target.priority)
                        return 0;
                    return priority > target.priority ? 1 : -1;
                } catch (InvalidCastException)
                {
                    return 0;
                }
            }
        }
    }
}
