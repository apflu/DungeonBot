using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Handler
{
    public class PlayerHandler
    {
        //临时方法：后续版本将被数据库连接代替
        public ArrayList Players { get; private set; }

        public PlayerHandler()
        {
            Players = new ArrayList
            {
                new Player(1010348055)
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
    }
}
