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
        public byte Char_MaxAllowed { get; protected set; }
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

        private void Send(LocaleKey key, Dictionary<string, string> args)
        {
            if (LastGroupID > -1)
                Plugin.GetMessageSender().Send(this, key, args);
            else
                Plugin.GetMessageSender().Whisper(this, key, args);
        }

        private void Send(string message)
        {
            if (LastGroupID > -1)
                Plugin.GetMessageSender().Send(LastGroupID, message);
            else
                Plugin.GetMessageSender().Whisper(QQID, message);
        }

        /// <summary>
        /// 对该名玩家回复一条消息
        /// </summary>
        /// <param name="message"></param>
        public void Reply(string messageKey, Dictionary<string, string> args)
        {
            //检测是否存在预格式化文本
            bool isPreformatMesssageExists = true;
            while (isPreformatMesssageExists)
            {
                isPreformatMesssageExists = false;
                foreach (KeyValuePair<string, string> arg in args)
                {
                    LocaleKey parsedKey = Plugin.GetLocaleManager().GetKey(arg.Key);
                    if (parsedKey != null)
                    {
                        args.Remove(arg.Key);
                        args.Add(arg.Key, CurrentLocale.GetValue(parsedKey));
                        isPreformatMesssageExists = true;
                    }
                }
            } //直到不剩下预格式化文本为止
            LocaleKey key = Plugin.GetLocaleManager().GetKey(messageKey);
            if (key != null)
                Send(key, args);
            else
                Send(messageKey);
        }

        public void Reply(string messageKey, params KeyValuePair<string, string>[] args)
        {
            Reply(messageKey, args.ToDictionary(arg => arg.Key, arg => arg.Value));
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
            return Common.CqApi.GetMemberInfo(LastGroupID, QQID).Nick;
        }

        public bool SetName(string name)
        {
            if(!Regex.IsMatch(name, Values.RegexName))
                return false;
            Name = name;
            return true;
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
