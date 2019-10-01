using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Native.Csharp.App.Event.EventHandler;

namespace Native.Csharp.App.Command.Interface
{
    public interface ICommand
    {
        void Execute(Player sender, string[] args);
        PlayerCommandHandler Register();
        
    }
}
