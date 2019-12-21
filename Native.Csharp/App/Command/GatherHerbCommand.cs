using Native.Csharp.App.Gameplay;
using Native.Csharp.App.Gameplay.Handler;
using Native.Csharp.App.Gameplay.Items.ItemTypes;
using Native.Csharp.App.UserInteract;
using Native.Csharp.App.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Command
{
    public class GatherHerbCommand : ICommand
    {

        public void Execute(Player sender, params string[] args)
        {
            string result = "";

            Character character = sender.GetCurrentCharacter();

            if(character != null)
            {
                //判断是否忙碌
                if (character.IsCurrentBusy())
                    sender.Reply(character.GetBusyTimeLeft(true));
                else
                {
                    Flag existedJob = character.GetFlag("quantityJobGatheringHerb");
                    //如果有已完成的草药采集
                    if (existedJob.Value != null)
                    {
                        if (int.Parse(existedJob.Value) != 0)
                        {
                            //TODO: 创建JobHandler
                            IItem[] gatheredItem = Plugin.GetHerbHandler().GetHerb(sender, int.Parse(existedJob.Value));

                            sender.GetCurrentCharacter().Inventory.AddItem(gatheredItem);
                            result += character.Name + "上次采集到了" + ItemHandler.ConvertToString(gatheredItem) + "！\r\n";

                            character.SetFlag(new Flag("quantityJobGatheringHerb", 0 + ""));
                        }
                    }

                    int quantity = ParseInput(sender, args);
                    //执行命令
                    if (quantity > 0)
                    {
                        result += character.Name + "正在进行新的采集工作：采集" + quantity + "个草药…\r\n";
                        Plugin.GetHerbHandler().GatherHerb(sender, quantity);
                    }
                }
                sender.Reply(result.TrimEnd('\r', '\n'));
            }
            else
                sender.Reply("你当前没有角色！\r\n" + "使用 *创建角色 来创建一个！");
        }
            


        /// <summary>
        /// 解析命令输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private int ParseInput(Player sender, params string[] args)
        {
            MessageSender mSender = Plugin.GetMessageSender();
            int quantity;

            if (args.Length == 1)
                return 1;
                

            //数据有效性检测
            try
            {
                quantity = int.Parse(args[1]);
            }
            catch (FormatException) //文本无法被转换成数字
            {
                mSender.Send(sender.LastGroupID, "数量" + args[1] + "无效！");

                return 0;
            }
            catch (ArgumentNullException) //null问题
            {
                mSender.Send(sender.LastGroupID, "命令执行失败。"); //怎么可能发生这个？！
                mSender.DebugSend("玩家" + sender.GetName() + "在执行MultipleGatherHerbCommand时出现ArgumentNullException。");

                return 0;
            }
            catch (OverflowException)
            {
                //看看是谁采那么多
                mSender.Send(sender.LastGroupID, sender.GetName() + "，给我站住，你采那么多是要把整个地球都搬走吗？！");

                return 0;
            }

            //数量检测
            if (quantity <= 0)
            {
                mSender.Send(sender.LastGroupID, sender.GetName() + "，不想采就别采！");

                return 0;
            }
            if (quantity > 10)
            {
                //看看是谁采那么多
                mSender.Send(sender.LastGroupID, sender.GetName() + "你采那么多干嘛！别人都没得采了（x");

                return 0;
            }
            return quantity;
        }
    }
}
