using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.CORE.DataObjects
{
    public class MessageTransferObject
    {
        public long id { get; set; }
        public string message { get; set; }
        public long channelId { get; set; }
        public string username { get; set; }

    }
}
