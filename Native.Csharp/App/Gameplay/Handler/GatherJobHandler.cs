using Native.Csharp.App.Gameplay.Items.ItemTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.Handler
{
    public class GatherJobHandler : JobHandler
    {

        public void BeginGatherHerb(Character sender) => BeginGatherHerb(sender, 1);

        public void BeginGatherHerb(Character sender, int quantity)
        {
            if (quantity > 1)
                sender.SetJob(
                    Flag.Value_JobHerb,
                    new TimeSpan(0, quantity * MinutesGatherMultipleHerb, 0)
                    );
            else
                sender.SetJob(
                    Flag.Value_JobHerb,
                    new TimeSpan(0, MinutesGatherSingleHerb, 0)
                    );

            //设置正在采集的数量
            sender.SetFlag(new Flag(Flag.Key_JobCurrent, Flag.Value_JobHerb));
            sender.SetFlag(new Flag(Flag.Key_JobHerb_Amount, quantity + ""));
        }

        public Inventory FinishGatherHerb(Character sender)
        {
            Flag flagCurrentJob = sender.GetFlag(Flag.Key_JobCurrent);

            //解决历史遗留问题
            if (flagCurrentJob == null)
                flagCurrentJob = sender.GetFlag("currentJob");

            if ((flagCurrentJob == null) 
                || (flagCurrentJob.Value != Flag.Value_JobHerb))
                return null;

            int quantity = 1;
            Flag flagQuantity = sender.GetFlag(Flag.Key_JobHerb_Amount);
            if (flagQuantity == null)
                flagQuantity = sender.GetFlag("quantityJobGatheringHerb");
            try
            {
                quantity = int.Parse(sender.GetFlag(Flag.Key_JobHerb_Amount).Value);
            }
            catch (ArgumentNullException)
            {
                //不行，这太傻猫了
            }
            if (quantity < 1)
                return null;

            Inventory result = new Inventory();
            Item[] itemGathered = Plugin.ItemHandler.DefaultItemGenerator.Generate(quantity);

            foreach (Item item in itemGathered)
                result += item;

            sender.RemoveFlag(flagCurrentJob);
            sender.RemoveFlag(flagQuantity);

            return result;
        }

        public void BeginGatherFood(Character sender) => BeginGatherFood(sender, 1);

        public void BeginGatherFood(Character sender, int quantity)
        {

        }
    }
}
