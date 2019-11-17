using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Csharp.App.Gameplay;
using Native.Csharp.App.Gameplay.Generator;

namespace Native.Csharp.App.Command
{
    public class DebugCommand : ICommand
    {
        public void Execute(Player sender, params string[] args)
        {
            if(args.Length > 1)
                switch (args[1])
                {
                    case "AbilityScoreGenerator":
                        string result = "";
                        foreach (byte score in new AbilityScoreGenerator().Generate())
                            result += score + " ";
                        Plugin.GetMessageSender().DebugSend(result);
                        break;
                }
        }
    }
}
