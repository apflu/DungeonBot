using MySql.Data.MySqlClient;
using Native.Csharp.App.Gameplay;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Data.Sql
{
    public class SqlHandler
    {
        //连接信息
        private const string host = "localhost";
        private const string username = "DungeonBot";
        private const string port = "3306";
        private const string password = "Meowtainaut";

        //SQL语句
        private const string initSqlCommand = "SELECT";

        private MySqlConnection mySqlConnection;

        public SqlHandler()
        {
            string connectionInfo = "server=" + host + ";user=" + username + ";database=dungeonrpg;port=" + port + ";password=" + password;
            mySqlConnection = new MySqlConnection(connectionInfo);

            //DataSet players = new DataSet();
        }

        public void EndTask()
        {
            //保存数据

            //释放对象
            mySqlConnection = null;
        }
    }
}
