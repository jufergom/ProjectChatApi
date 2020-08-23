using Chat.CORE;
using Chat.CORE.DataObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.SERVICE
{
    public interface IChannelService
    {
        public ServiceResult<IEnumerable<ChannelTransferObject>> getAllChannels();
        public ServiceResult<IEnumerable<ChannelTransferObject>> getChannelsByUser(string username);
        public ServiceResult<ChannelTransferObject> addChannel(ChannelTransferObject channel);

        public ServiceResult<bool> assignChannelToUser(long idChannel, string username);
    }
}
