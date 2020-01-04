using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Csharp.App.Gameplay;
using Native.Csharp.App.Gameplay.Items.ItemTypes;

namespace Native.Csharp.App.Command
{
    public class ShowItemDescriptionCommand : ICommand
    {
        public void Execute(Player sender, params string[] args)
        {
            if (IsInputValid(sender, args))
            {
                Character character = sender.GetCurrentCharacter();
                if (character == null)
                {
                    sender.Reply("{ERROR_CHARACTER_NONE_IN_LIST}");
                    return;
                }

                Item item = Plugin.ItemHandler.GetItem(args[1]);
                if (item == null)
                {
                    sender.Reply("{ERROR_IS_NOT_VALID}", new Dictionary<string, string>
                    {
                        { "key", "{ITEM}" },
                        { "value", args[1] }
                    });
                }
            }
        }

        private bool IsInputValid(Player sender, params string[] args)
        {
            if (args.Length < 2)
            {
                sender.Reply("{JOB_AMOUNT_TOO_SMALL}", new Dictionary<string, string>
                {
                    { "player_name", sender.GetName() },
                    { "job_name_short", "{JOB_CHECK_SHORT}" }
                });
                return false;
            }
            if (args.Length > 2)
            {
                //sender.Reply();
                return false;
            }
            return true;
        }
    }
}
 