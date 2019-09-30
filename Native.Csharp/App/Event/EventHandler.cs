﻿using Native.Csharp.App.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Native.Csharp.App.Gameplay;

namespace Native.Csharp.App.Event
{
    public class EventHandler
    {
        //player event
        public delegate void PlayerCommandHandler(Player sender, String[] args);
        //public delegate void PlayerDataChangeHander(Player target);
        //public delegate void PlayerCharacterChangeHandler(Player sender, Character character);
        //public delegate void PlayerUseSkillHandler(Player sender, Skill skill);

        //character event
        //public delegate void CharacterCreateHandler(Player sender, Character character);
        //public delegate void CharacterStatusChangeHandler(Player sender, Character character);

        //inventory event
        //public delegate void InventoryOpenHandler(Player sender, Inventory inventory);
        //public delegate void InventoryCloseHandler(Player sender, Inventory inventory);
        //public delegate void InventoryDestroyHandler(Inventory inventory);

        //item event
        //public delegate void ItemTransferHandler(Player sender, Item item, Inventory[] inventories);
        //public delegate void ItemDestroyHandler(Player sender, Item item);
        //public delegate void ItemUseHandler(Player sender, Item item);
        //public delegate void ItemConsumeHandler(Player sender, Item item);

        //plugin event
        //public delegate void PluginGroupStatusChangeHandler(Player sender, long group);
        //public delegate void PluginGlobalStatusChangeHandler(Player sender);

        //time event
        //public delegate void NextMinuteHandler();
        //public delegate void NextDayHandler();
        
        //events
        public event PlayerCommandHandler PlayerCommandEvent;

        public void PlayerCommand(Player sender, String[] args)
        {
            PlayerCommandEvent(sender, args);
        }
    }
}
