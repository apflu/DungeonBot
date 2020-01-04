using Native.Csharp.App.Data;
using Native.Csharp.App.Gameplay.Generator;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Handler
{
    public class PlayerHandler : ISaveable
    {
        //临时方法：后续版本将被数据库连接代替
        public const byte DefaultMaxCharactersAllowed = 3;

        public List<Player> Players { get; private set; }

        //玩家World定义：所有NPC都在其名下
        private const long IDPlayerWorld = 344879070;
        public Player PlayerWorld;

        public PlayerHandler()
        {
            PlayerWorld = new Player(IDPlayerWorld);
            Players = new List<Player>
            {
                PlayerWorld
            };
        }

        /// <summary>
        /// 使用QQ号获取Player对象；如果未注册，则进行登记
        /// </summary>
        /// <param name="qqID">QQ号</param>
        /// <returns></returns>
        public Player ParsePlayer(long qqID)
        {
            foreach(Player player in Players)
            {
                if (player.QQID == qqID)
                    return player;
            }
            //如果没有找到：未登记
            Player newPlayer = new Player(qqID);
            Players.Add(newPlayer);

            return newPlayer;
        }

        public static DataSet GetDataSet()
        {
            DataSet result = new DataSet();

            DataTable player = new DataTable("player");
            player.Columns.Add("qqid");
            player.Columns.Add("name");
            result.Tables.Add(player);

            DataSet unfinish = CharacterHandler.GetUnfinishCharDataSet();
            unfinish.Tables["properties"].TableName = "pending_character";
            unfinish.Tables["pending_character"].Columns.Add("qqid");
            result.Merge(unfinish);
            unfinish.Dispose();

            return result;
        }

        public DataSet Save()
        {
            DataSet result = GetDataSet();
            foreach (Player player in Players)
            {

                DataRow playerDR = result.Tables["player"].NewRow();
                playerDR["qqid"] = player.QQID;
                playerDR["name"] = player.Name;
                result.Tables["player"].Rows.Add(playerDR);
            }

            return result;
        }
    }
}
