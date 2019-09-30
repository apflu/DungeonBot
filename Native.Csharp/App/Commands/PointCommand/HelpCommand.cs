using Native.Csharp.App.Command;
using Native.Csharp.App.Command.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Commands.PointCommand
{
    public class HelpCommand : ICommand
    {
        public void Execute(Player sender, string[] args)
        {
            if (args == null)
            {

            }
        }

        public void Register()
        {
            
        }
    }
}
