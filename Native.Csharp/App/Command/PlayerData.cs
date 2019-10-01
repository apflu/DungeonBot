using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Command
{
    class PlayerData
    {
        private DataSet data;
        public PlayerData(DataSet dataSet)
        {
            data = dataSet;
        }
    }
}
