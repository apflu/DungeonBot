using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Native.Csharp.App.Util;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace Native.Csharp.App.Mysql
{
    public class ConnectManager
    {
        private readonly MySqlConnection Connection = new MySqlConnection(Values.SQL_Credit);

        public ConnectManager()

        {
            Connection.Open();
        }

        private MySqlCommand Format(String Command, object arg)
        {
            return new MySqlCommand(String.Format(Command, arg), Connection);
        }

        public void Close()
        {
            Connection.Close();
        }
    }
}
