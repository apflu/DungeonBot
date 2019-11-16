using System;
using System.Collections;

namespace Native.Csharp.App.Util
{
    public class RandomTable
    {
        private readonly ArrayList table;
        private Possibility result;

        private readonly Random random;

        public RandomTable()
        {
            table = new ArrayList();
            random = new Random();
        }
        
        /// <summary>
        /// 对随机掉落表添加项目，将返回新的掉落表
        /// </summary>
        /// <param name="possibilities">欲要添加的项目（们）</param>
        /// <returns></returns>
        public RandomTable AddPossibility(params Possibility[] possibilities)
        {

            foreach(Possibility possibility in possibilities)
                table.Add(possibility);

            return this;
        }

        public int GetTableSize()
        {
            int tableSize = 1;

            foreach (Possibility possibility in table)
                tableSize += possibility.Chance;

            return tableSize;
        }

        /// <summary>
        /// 在不重置结果的情况下获取结果
        /// </summary>
        /// <returns></returns>
        public Possibility GetResult()
        {
            //如果已有结果，将不会使用DoRandomize()
            if(result == null)
                DoRandomize();

            return result;

        }

        /// <summary>
        /// 重置结果
        /// </summary>
        public void DoRandomize()
        {
            //获取随机数
            int randomResult = random.Next(1, GetTableSize());

            foreach (Possibility possibility in table)
            {
                //TODO: 是否有潜在bug？
                randomResult -= possibility.Chance;
                if(randomResult <= 0)
                {
                    result = possibility;
                    break;
                }
            }
        }
        
    }
}
