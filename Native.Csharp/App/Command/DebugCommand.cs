using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Csharp.App.Data.Saver;
using Native.Csharp.App.Gameplay;
using Native.Csharp.App.Gameplay.Generator;

namespace Native.Csharp.App.Command
{
    public class DebugCommand : ICommand
    {
        public void Execute(Player sender, params string[] args)
        {
            
            try
            {
                DataSaver.Save(
                    Plugin.CharacterHandler.Save(),
                    Plugin.PlayerHandler.Save()
                    );
                Plugin.MessageSender.DebugSend("保存数据成功！");

            }
            catch (Exception ex)
            {
                Plugin.MessageSender.DebugSend(ex.ToString());
            }
        }
    }
}
