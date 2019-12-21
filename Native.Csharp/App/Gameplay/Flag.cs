using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay
{
    public class Flag
    {
        public string Key { get; private set; }
        public string Value { get; set; }

        /*
         * ===========================角色Flag===========================
         * =                                                            =
         * =               这里列出了角色相关Flag。                     =
         * =                                                            =
         * ==============================================================
         */
        
        public const string Char_FlagName_JobCurrent = "JobCurrent";
            public const string Char_FlagContent_JobNone = "None";
            public const string Char_FlagContent_JobHerb = "GatherHerb";
                public const string Char_FlagName_JobHerb_Amount = "JobHerbAmount";

        public const string Char_FlagName_TypeCharacter = "CharType";
            public const string Char_FlagContent_TypeTemp = "Temp";
            public const string Char_FlagContent_TypePlayer = "Player";
            public const string Char_FlagContent_TypeNPCFriendly = "Friendly";
            public const string Char_FlagContent_TypeNPCEnemy = "Enemy";

        /*
         * ===========================动作Flag===========================
         * =                                                            =
         * =            这里列出了角色的动作相关Flag。                  =
         * =                                                            =
         * ==============================================================
         */

        public const string Action_FlagName_TypeSender = "TypeSender";
            public const string Action_FlagName_Sender = "Sender";

        public const string Action_FlagName_TypeObject = "TypeObject";
            public const string Action_FlagName_Object = "Object";

        //public const string Action_FlagName_ActionSource = "Source";
            public const string Action_FlagContent_SourceSelf = "Self";
            public const string Action_FlagContent_SourceNature = "Nature";
            public const string Action_FlagContent_SourceCharacter = "Character";
            public const string Action_FlagContent_SourceTime = "time";


        public const string Action_FlagName_ActionType = "Action";
            public const string Action_FlagContent_TypeDamaged = "Damaged";
            public const string Action_FlagContent_TypeHeal = "Heal";
                public const string Action_FlagName_TypeHeal_Overheal = "Overheal";
                public const string Action_FlagName_ExceedHealToTempHP = "ExceedHealToTempHP";
            public const string Action_FlagContent_TypeAttack = "Attack";

        /*
         * ===========================状态Flag===========================
         * =                                                            =
         * =            这里列出了角色的状态相关Flag。                  =
         * =                                                            =
         * ==============================================================
         */

        public const string Status_FlagName_CanBenefitFromRest = "BenefitFromRest";



        /// <summary>
        /// 构造方法：不能包括空格或分号
        /// </summary>
        /// <param name="key">名字；不能包括空格或分号</param>
        /// <param name="value">内容；不能包括空格或分号</param>
        public Flag(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public Flag Parse(string strFlag)
        {
            string[] flag = strFlag.TrimEnd(';').Split(' ');

            return new Flag(flag[0], flag[1]);
        }

        public KeyValuePair<string, string> ToKeyValuePair()
        {
            return new KeyValuePair<string, string>(Key, Value);
        }

        public override string ToString()
        {
            return Key + " " + Value + ";";
        }
    }
}
