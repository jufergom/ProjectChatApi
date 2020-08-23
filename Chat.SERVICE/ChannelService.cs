using Chat.CORE;
using Chat.CORE.DataObjects;
using Chat.DATA.Entities;
using Chat.DATA.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chat.SERVICE
{
    public class ChannelService : IChannelService
    {
        private readonly IRepository<Channel> _channelRepository;
        private readonly IRepository<UserChannel> _userChannelRepository;

        public ChannelService(IRepository<Channel> channelRepository, IRepository<UserChannel> userChannelRepository)
        {
            _channelRepository = channelRepository;
            _userChannelRepository = userChannelRepository;
        }

        public ServiceResult<ChannelTransferObject> addChannel(ChannelTransferObject channel)
        {
            var newChannel = new Channel
            {
                name = channel.name,
                topic = channel.topic
            };

            _channelRepository.Add(newChannel);
            _channelRepository.saveChanges();
            channel.id = newChannel.id;
            return ServiceResult<ChannelTransferObject>.SuccessResult(channel);
        }

        public ServiceResult<bool> assignChannelToUser(long idChannel, string username)
        {
            var newAssing = new UserChannel
            {
                idChannel = idChannel,
                userTag = username
            };

            _userChannelRepository.Add(newAssing);
            _userChannelRepository.saveChanges();
            return ServiceResult<bool>.SuccessResult(true);
        }

        public ServiceResult<IEnumerable<ChannelTransferObject>> getAllChannels()
        {
            var channels = _channelRepository.All()
                .Select(x => new ChannelTransferObject
                {
                    id = x.id,
                    name = x.name,
                    topic = x.topic,
                    username = null
                });
            return ServiceResult<IEnumerable<ChannelTransferObject>>.SuccessResult(channels);
        }

        public ServiceResult<IEnumerable<ChannelTransferObject>> getChannelsByUser(string username)
        {
            var channels = _userChannelRepository.All()
                .Include(x => x.Channel)
                .Select(x => new ChannelTransferObject
                {
                    id = x.idChannel,
                    name = x.Channel.name,
                    topic = x.Channel.topic,
                    username = x.userTag
                }).Where(x => x.username == username).ToList();

            return ServiceResult<IEnumerable<ChannelTransferObject>>.SuccessResult(channels);
        }
    }
}
