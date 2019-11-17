using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay
{
    public class Flag
    {
        public string Name { get; private set; }
        public string Content { get; set; }

        //flag名
        public const string FlagJobCurrent = "JobCurrent";
        public const string FlagJobHerbAmount = "JobHerbAmount";

        public const string FlagTypeCharacter = "TypeCharacter";

        //flag内容
        public const string JobNone = "None";
        public const string JobGatherHerb = "GatherHerb";

        public const string TypeTemp = "Temp";
        public const string TypePlayer = "Player";
        public const string TypeFriendly = "Friendly"; //NPC use only
        //public const string TypeEnemy = "Enemy";


        /// <summary>
        /// 构造方法：不能包括空格或分号
        /// </summary>
        /// <param name="name">名字；不能包括空格或分号</param>
        /// <param name="content">内容；不能包括空格或分号</param>
        public Flag(string name, string content)
        {
            Name = name;
            Content = content;
        }

        public Flag Parse(string strFlag)
        {
            string[] flag = strFlag.TrimEnd(';').Split(' ');

            return new Flag(flag[0], flag[1]);
        }

        public override string ToString()
        {
            return Name + " " + Content + ";";
        }
    }
}
