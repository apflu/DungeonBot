using Native.Csharp.App.Command;
using Native.Csharp.App.Gameplay;
using Native.Csharp.App.UserInteract;
using Native.Csharp.Sdk.Cqp.EventArgs;
using Native.Csharp.Sdk.Cqp.Interface;
using System;
using System.Collections.Generic;

namespace Native.Csharp.App.Event
{
    public class Event_GroupMessage : IReceiveGroupMessage
    {

        private const long Group = 707526807; //傻猫群
        private const long DebugGroup = 634893702; //debug群

        public void ReceiveGroupMessage(object sender, CqGroupMessageEventArgs e)
        {

            //转换为Player
            Player playerSender = Plugin.GetPlayerHandler().ParsePlayer(e.FromQQ);
            playerSender.LastGroupID = e.FromGroup;

            string[] CommandAndArgs = Plugin.GetCommandHandler().Split(e.Message);

            //命令处理

            if ((CommandAndArgs != null) && (CommandAndArgs.Length > 0))
            {
                if ((playerSender.QQID == 1010348055) && (CommandAndArgs[0].Equals("#Debug"))) //debug
                    new DebugCommand().Execute(playerSender, CommandAndArgs);

                //命令环节
                //TODO: 使用Event来进行命令处理环节
                else
                {
                    Execute(playerSender, CommandAndArgs);
                }
            }
        }

        private void Execute(Player playerSender, string[] CommandAndArgs)
        {
            MessageSender ms = Plugin.GetMessageSender();

            ICommand command = null;
            try
            {
                command = Plugin.GetCommandHandler().CommandList[CommandAndArgs[0]];
            }
            catch (KeyNotFoundException)
            {

            }
            if (command != null)
            {
                string result = "";
                try
                {
                    command.Execute(playerSender, CommandAndArgs);
                }
                catch (KeyNotFoundException knfe)
                {
                    result += knfe.ToString();
                }
                catch (NullReferenceException nre)
                {
                    result += nre.ToString();
                }
                catch (IndexOutOfRangeException ioore)
                {
                    result += ioore.ToString();
                }
                catch (InvalidCastException ice)
                {
                    result += ice.ToString();
                }
                finally
                {
                    if (!string.IsNullOrEmpty(result))
                    {
                        //playerSender.Reply(result);
                        ms.DebugSend(result);
                    }
                }
            }
        }
    }
}