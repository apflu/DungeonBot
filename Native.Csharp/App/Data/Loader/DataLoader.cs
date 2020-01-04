using Native.Csharp.App.Gameplay;
using Native.Csharp.App.Gameplay.Generator;
using Native.Csharp.App.Gameplay.Handler;
using Native.Csharp.App.Gameplay.Items.ItemTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Data.Loader
{
    public static class DataLoader
    {
        public static void Load()
        {
            XmlReader reader = new XmlReader();
            DataSet[] data = new XmlReader().LoadAll();

            foreach (DataSet dataSet in data)
            {
                LoadPlayers(dataSet);
                LoadCharacters(dataSet);
            }
        }

        private static void LoadPlayers(DataSet data)
        {
            PlayerHandler handler = Plugin.PlayerHandler;
            List<Player> players = new List<Player>();

            
        }
        
        private static void LoadCharacters(DataSet data)
        {
            CharacterHandler handler = Plugin.CharacterHandler;
            List<Character> characters = new List<Character>();

            DataTable Characters;
            DataTable Flags;
            DataTable Inventory;
            DataTable Properties;
            try
            {
                Characters = data.Tables["characters"];
                Flags = data.Tables["flags"];
                Inventory = data.Tables["inventory"];
                Properties = data.Tables["properties"];
            }
            catch (NullReferenceException)
            {
                return;
            }
            catch(ArgumentException)
            {
                return;
            }

            foreach (DataRow row in Characters.Rows)
            {
                Player owner = Plugin.PlayerHandler.ParsePlayer(long.Parse(row["owner_qqid"].ToString()));
                string character_name = row["character_name"].ToString();
                long next_free_time = long.Parse(row["next_free_time"].ToString());

                characters.Add(new Character(character_name, owner)
                {
                    NextFreeTime = new DateTime(next_free_time)
                });
            }

            foreach (DataRow row in Properties.Rows)
            {
                string Name = row["character_name"].ToString();
                Character character = characters.Find((listedChar) =>
                {
                    return listedChar.Name == Name;
                });

                byte STR = byte.Parse(row["str"].ToString());
                byte DEX = byte.Parse(row["dex"].ToString());
                byte CON = byte.Parse(row["con"].ToString());
                byte INT = byte.Parse(row["int"].ToString());
                byte WIS = byte.Parse(row["wis"].ToString());
                byte CHA = byte.Parse(row["cha"].ToString());

                AbilityScoreGenerator gen = new AbilityScoreGenerator()
                {
                    Results = new byte[6]
                    {
                        STR, DEX, CON, INT, WIS, CHA
                    }
                };

                character.Properties = new Gameplay.CharacterUtil.CharacterProperties(gen);
            }

            foreach (DataRow row in Inventory.Rows)
            {
                string Name = row["character_name"].ToString();
                Character character = characters.Find((listedChar) =>
                {
                    return listedChar.Name == Name;
                });

                Item item = Plugin.ItemHandler.Parse(row["item_name"].ToString());
                int quantity = int.Parse(row["quantity"].ToString());

                character.Inventory.AddItem(new ItemStack(item, quantity));
            }

            foreach (DataRow row in Flags.Rows)
            {
                string Name = row["character_name"].ToString();
                Character character = characters.Find((listedChar) =>
                {
                    return listedChar.Name == Name;
                });

                string Key = row["key"].ToString();
                string Value = row["value"].ToString();

                character.SetFlag(new Flag(Key, Value));
            }

            Plugin.CharacterHandler.Load(characters.ToArray());
        }
    }
}
