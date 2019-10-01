﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Util.Message
{
    public class MessageType
    {
        private readonly string type;

        public readonly MessageType Type_Text = new MessageType("text");
        public readonly MessageType Type_Preset_Message = new MessageType("preset message");

        private MessageType(string type)
        {
            this.type = type;
        }

        public override string Tostring()
        {
            return type;
        }
    }
}