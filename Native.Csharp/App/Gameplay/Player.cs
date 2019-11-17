using Native.Csharp.App.Gameplay.Handler;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay
{
    public class Player
    {

        //玩家基础信息
        public long QQID { get; private set; }
        public long LastGroupID { get; set; }
        public Inventory Inventory { get; protected set; }
        public byte MaxCharactersAllowed { get; set; }
        private Character CurrentCharacter;
        

        //玩家信息
        public ArrayList Flags;

        /// <summary>
        /// 使用QQ号来创建尚未登记的玩家
        /// </summary>
        /// <param name="qqID">QQ号</param>
        public Player(long qqID)
        {
            QQID = qqID;
            Inventory = new Inventory();
            MaxCharactersAllowed = PlayerHandler.DefaultMaxCharactersAllowed;

            Flags = new ArrayList();
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

        /*
         * ===========================角色===========================
         * =                                                        =
         * =            这里列出了玩家的角色相关方法。              =
         * =                                                        =
         * ==========================================================
         */
        public Character GetCurrentCharacter()
        {
            if (CurrentCharacter == null)
            {
                Character[] characters = Plugin.GetCharacterHandler().GetCharacters(this);
                if ((characters != null) && (characters.Length != 0))
                {
                    CurrentCharacter = characters[0];
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
