using Native.Csharp.App.Command;
using Native.Csharp.App.Gameplay;
using Native.Csharp.Sdk.Cqp.EventArgs;
using Native.Csharp.Sdk.Cqp.Interface;

namespace Native.Csharp.App.Event
{
    public class Event_GroupMessage : IReceiveGroupMessage
    {

        private const long Group = 707526807; //傻猫群
        private const long DebugGroup = 634893702; //debug群

        public void ReceiveGroupMessage(object sender, CqGroupMessageEventArgs e)
        {
            //debug用
            string memberName = Common.CqApi.GetMemberInfo(Group, e.FromQQ, true).Nick;

            //转换为Player
            Player playerSender = Plugin.GetPlayerHandler().ParsePlayer(e.FromQQ);
            playerSender.LastGroupID = e.FromGroup;


            string[] CommandAndArgs = Plugin.GetCommandHandler().Split(e.Message);


            //命令处理

            if (((e.FromGroup == Group) | (e.FromGroup == DebugGroup)) & (CommandAndArgs != null))
            {
                //debug用：伪命令
                if (e.Message.Equals("awsl"))
                {
                    string message = "是" + memberName + "，awsl";
                    Common.CqApi.SendGroupMessage(Group, message);
                }

                else if ((playerSender.QQID == 1010348055) && (CommandAndArgs[0].Equals("Debug"))) //debug
                    new DebugCommand().Execute(playerSender, CommandAndArgs);

                //命令环节
                //TODO: 使用Event来进行命令处理环节
                else if (CommandAndArgs[0].Equals("*采集草药"))
                    new GatherHerbCommand().Execute(playerSender, CommandAndArgs);

                else if (CommandAndArgs[0].Equals("*显示物品栏"))
                    new ShowPlayerInventoryCommand().Execute(playerSender);

                else if (CommandAndArgs[0].Equals("*丢弃物品"))
                    new AbandonItemCommand().Execute(playerSender, CommandAndArgs);

                else if (CommandAndArgs[0].Equals("*创建角色"))
                    new CreateCharacterCommand().Execute(playerSender, CommandAndArgs);

                else if (CommandAndArgs[0].Equals("*招募角色"))
                    new ConfirmCharacterCommand().Execute(playerSender, CommandAndArgs);

                else if (CommandAndArgs[0].Equals("*指定当前角色"))
                    new SetCurrentCharacterCommand().Execute(playerSender, CommandAndArgs);
            }
        }
    }
}