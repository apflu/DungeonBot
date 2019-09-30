﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Command.Interface
{
    interface ICommand
    {
        void Execute(Player sender, String[] args);
        void Register();

    }
}
