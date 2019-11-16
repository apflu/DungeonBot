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

        public const int MaxCharactersAllowed = 3;

        /// <summary>
        /// 默认构造方法
        /// </summary>
        public CharacterHandler()
        {
            Characters = new ArrayList();
        }

        
        public Character[] GetCharacters(Player player)
        {
            Character[] result = new Character[MaxCharactersAllowed];

            //TODO

            return result;
        }

        /// <summary>
        /// 判断一名角色是否已注册
        /// 如果角色有flag
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public bool IsExist(Character character)
        {
            //TODO
        }

        public bool Register(Character character)
        {
            if(IsExist(character))
            {
                //TODO
                return true;
            }
            return false;
        }

        public bool Remove(Character character)
        {
            if (IsExist(character))
            {
                //TODO
                return true;
            }
            return false;
        }

        public Character Parse()
        {
            //TODO
        }
    }
}
