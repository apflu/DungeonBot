using Native.Csharp.App.Gameplay.Items.ItemTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Handler
{
    public class HerbHandler
    {
        public const int MinutesGatherSingleHerb = 10;
        public const int MinutesGatherMultipleHerb = 12;
        public Item[] GetHerb(Player _, int quantity)
        {
            return Plugin.GetItemHandler().DefaultItemGenerator.Generate(quantity);
        }

        /// <summary>
        /// 不能为负数
        /// </summary>
        /// <param name="sender">执行玩家</param>
        /// <param name="quantity">数量，不能为负</param>
        public void GatherHerb(Player sender, int quantity)
        {
            if (quantity > 1)
                sender.GetCurrentCharacter().SetJob(
                    Flag.Value_JobHerb,
                    new TimeSpan(0, quantity * MinutesGatherMultipleHerb, 0)
                    );
            else
                sender.GetCurrentCharacter().SetJob(
                    Flag.Value_JobHerb,
                    new TimeSpan(0, MinutesGatherSingleHerb, 0)
                    );

            //设置正在采集的数量
            sender.GetCurrentCharacter().SetFlag(new Flag("quantityJobGatheringHerb", quantity + ""));
            sender.GetCurrentCharacter().SetFlag(new Flag("currentJob", "GatherHerb"));
        }
    }
}
