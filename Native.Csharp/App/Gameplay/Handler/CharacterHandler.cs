using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Handler
{
    public class CharacterHandler
    {
        private ArrayList Characters;

        

        /// <summary>
        /// 默认构造方法
        /// </summary>
        public CharacterHandler()
        {
            Characters = new ArrayList();
        }

        
        public Character[] GetCharacters(Player player)
        {
            ArrayList result = new ArrayList();

            foreach (Character character in Characters)
                if (character.Owner == player)
                    result.Add(character);

            return (Character[])result.ToArray();
        }

        /// <summary>
        /// 判断一名角色是否已注册
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public bool IsExist(Character character)
        {
            foreach (Character c in Characters)
                if (c == character)
                    return true;
            return false;
        }

        /// <summary>
        /// 注册一名角色
        /// 注意：玩家角色请使用Player.AddCharacter(Character)！
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public bool Register(Character character)
        {
            if(!IsExist(character))
            {
                Characters.Add(character);
                return true;
            }
            return false;
        }

        public bool Remove(Character character)
        {
            if (IsExist(character))
            {
                Characters.Remove(character);
                return true;
            }
            return false;
        }

        public Character Parse(string name)
        {
            foreach (Character character in Characters)
                if (character.Name == name)
                    return character;
            return null;
        }
    }
}
