using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Csharp.App.Gameplay;

namespace Native.Csharp.App.Command
{
    public class PlayerChangeNameCommand : ICommand
    {
        public void Execute(Player sender, params string[] args)
        {
            throw new NotImplementedException();
        }
    }
}
