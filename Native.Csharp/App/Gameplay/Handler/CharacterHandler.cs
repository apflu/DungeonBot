using Native.Csharp.App.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Handler
{
    public class CharacterHandler : ISaveable
    {
        private readonly List<Character> Characters;

        

        /// <summary>
        /// 默认构造方法
        /// </summary>
        public CharacterHandler()
        {
            Characters = new List<Character>();
        }

        
        public Character[] GetCharacters(Player player)
        {
            List<Character> result = new List<Character>();

            foreach (Character character in Characters)
                if (character.Owner == player)
                    result.Add(character);

            return result.ToArray();
        }

        /// <summary>
        /// 判断一名角色是否已注册
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public bool IsExist(Character character)
        {
            foreach (Character c in Characters)
                if (c == character)
                    return true;
            return false;
        }

        /// <summary>
        /// 注册一名角色
        /// 注意：玩家角色请使用Player.AddCharacter(Character)！
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public bool Register(Character character)
        {
            if(!IsExist(character))
            {
                Characters.Add(character);
                return true;
            }
            return false;
        }

        public void Load(params Character[] characters)
        {
            foreach (Character character in characters)
                Register(character);
        }

        public bool Remove(Character character)
        {
            if (IsExist(character))
            {
                Characters.Remove(character);
                return true;
            }
            return false;
        }

        public Character Parse(string name)
        {
            foreach (Character character in Characters)
                if (character.Name == name)
                    return character;
            return null;
        }

        protected static DataSet GetDataSet()
        {
            DataSet result = new DataSet();

            DataTable Characters = new DataTable("characters");
            result.Tables.Add(Characters);
            Characters.Columns.Add("character_name");
            Characters.Columns.Add("owner_qqid");
            Characters.Columns.Add("next_free_time");

            DataTable Flags = new DataTable("flags");
            result.Tables.Add(Flags);
            Flags.Columns.Add("character_name");
            Flags.Columns.Add("key");
            Flags.Columns.Add("value");

            DataTable Inventory = new DataTable("inventory");
            result.Tables.Add(Inventory);
            Inventory.Columns.Add("character_name");
            Inventory.Columns.Add("item_name");
            Inventory.Columns.Add("quantity");

            DataSet unfinish = GetUnfinishCharDataSet();
            unfinish.Tables["properties"].Columns.Add("character_name");
            result.Merge(unfinish);
            unfinish.Dispose();

            return result;
        }

        public static DataSet GetUnfinishCharDataSet()
        {
            DataSet result = new DataSet();

            DataTable Properties = new DataTable("properties");
            result.Tables.Add(Properties);
            Properties.Columns.Add("str");
            Properties.Columns.Add("dex");
            Properties.Columns.Add("con");
            Properties.Columns.Add("int");
            Properties.Columns.Add("wis");
            Properties.Columns.Add("cha");

            return result;
        }

        public DataSet Save()
        {
            DataSet result = GetDataSet();

            foreach (Character character in Characters)
            {
                DataRow characters = result.Tables["characters"].NewRow();
                characters["character_name"] = character.Name;
                characters["owner_qqid"] = character.Owner.QQID;
                characters["next_free_time"] = character.NextFreeTime.Ticks;
                result.Tables["characters"].Rows.Add(characters);

                foreach (Flag flag in character.Flags)
                {
                    DataRow flags = result.Tables["flags"].NewRow();
                    flags["character_name"] = character.Name;
                    flags["key"] = flag.Key;
                    flags["value"] = flag.Value;
                    result.Tables["flags"].Rows.Add(flags);
                }
                
                DataRow properties = result.Tables["properties"].NewRow();
                properties["character_name"] = character.Name;
                properties["str"] = character.Properties.STR;
                properties["dex"] = character.Properties.DEX;
                properties["con"] = character.Properties.CON;
                properties["int"] = character.Properties.INT;
                properties["wis"] = character.Properties.WIS;
                properties["cha"] = character.Properties.CHA;
                result.Tables["properties"].Rows.Add(properties);

                DataRow Inventory = result.Tables["inventory"].NewRow();
                foreach (ItemStack item in character.Inventory.Items)
                {
                    DataRow inventories = result.Tables["inventory"].NewRow();
                    inventories["character_name"] = character.Name;
                    inventories["item_name"] = item.Item.InternalName;
                    inventories["quantity"] = item.Quantity;
                    result.Tables["inventory"].Rows.Add(inventories);
                }
            }

            return result;
        }
    }
}
