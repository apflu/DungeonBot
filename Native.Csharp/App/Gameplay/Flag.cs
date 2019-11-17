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
        public const string Char_FlagName_JobCurrent = "JobCurrent";
        public const string Char_FlagName_JobHerb_Amount = "JobHerbAmount";

        public const string Char_FlagName_TypeCharacter = "TypeCharacter";

        //flag内容
        public const string Char_FlagContent_JobNone = "None";
        public const string Char_FlagContent_JobHerb = "GatherHerb";

        public const string Char_FlagContent_TypeTemp = "Temp";
        public const string Char_FlagContent_TypePlayer = "Player";
        public const string Char_FlagContent_TypeFriendly = "Friendly"; //NPC use only
        public const string Char_FlagContent_TypeEnemy = "Enemy";


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
