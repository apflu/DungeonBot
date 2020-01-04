using Native.Csharp.App.Gameplay.Generator;
using Native.Csharp.App.Gameplay.Handler;
using Native.Csharp.App.UserInteract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay
{
    public class Player
    {

        //玩家基础信息
        public long QQID { get; private set; }
        public string Name { get; private set; }
        public long LastGroupID { get; set; }

        //语言&交互
        public Locale CurrentLocale { get; set; }

        public Inventory Inventory { get; protected set; }
        public int Char_MaxAllowed { get; protected set; }
        public List<AbilityScoreGenerator> Char_OnList { get; set; }
        public int Char_MaxOnList { get; protected set; }

        private Character CurrentCharacter;

        //玩家信息
        public List<Flag> Flags { get; protected set; }
        public List<Flag> Settings { get; protected set; }
        public List<Flag> Permissions { get; protected set; }

        /// <summary>
        /// 使用QQ号来创建尚未登记的玩家
        /// </summary>
        /// <param name="qqID">QQ号</param>
        public Player(long qqID)
        {
            QQID = qqID;
            Inventory = new Inventory();
            Char_MaxAllowed = PlayerHandler.DefaultMaxCharactersAllowed;

            Flags = new List<Flag>();
        }

        /*
         * ==========================语言及交互============================
         * =                                                              =
         * =              这里列出了与文字交互相关的方法。                =
         * =                                                              =
         * ================================================================
         */

        public void Reply(string message)
        {
            Reply(message, null);
        }
        public void Reply(string message, Dictionary<string, string> args)
        {
            if (LastGroupID > -1)
                Plugin.GetMessageSender().Send(this, message, args);
            else
                Plugin.GetMessageSender().Whisper(this, message, args);
        }

        /*
         * ===========================基础信息===========================
         * =                                                            =
         * =            这里列出了玩家的基础信息相关方法。              =
         * =                                                            =
         * ==============================================================
         */

        public string GetName()
        {
            if (string.IsNullOrEmpty(Name))
                return Common.CqApi.GetMemberInfo(LastGroupID, QQID).Nick;
            return Name;
        }
        public void SetName(string name)
        {
            Name = name;
        }

        /*
         * ===========================角色===========================
         * =                                                        =
         * =            这里列出了玩家的角色相关方法。              =
         * =                                                        =
         * ==========================================================
         */
        
        /// <summary>
        /// 获取玩家的当前角色；
        /// 如果拥有角色且未选择，则会指定列表中第一名角色
        /// </summary>
        /// <returns></returns>
        public Character GetCurrentCharacter()
        {
            if (CurrentCharacter == null)
            {
                Character[] characters = Plugin.GetCharacterHandler().GetCharacters(this);
                if ((characters != null) && (characters.Length != 0))
                {
                    SetCurrentCharacter(characters[0]);
                }
            }
            return CurrentCharacter;
        }

        /// <summary>
        /// 选择当前所扮演的角色
        /// 注意：不检测角色是否归属该玩家！
        /// </summary>
        /// <param name="character">角色</param>
        /// <returns></returns>
        public bool SetCurrentCharacter(Character character)
        {
            if (Plugin.GetCharacterHandler().IsExist(character))
            {
                CurrentCharacter = character;
                return true;
            }
            return false;
        }

        public bool AddCharacter(Character character)
        {
            return Plugin.GetCharacterHandler().Register(character.SetOwner(this));
        }

        //TODO: 重写Equals(object)方法
    }
}
