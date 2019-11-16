using Native.Csharp.App.Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Command
{
    public interface ICommand
    {
        void Execute(Player sender, params string[] args);
    }
}
