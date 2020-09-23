using Chat.CORE;
using Chat.DATA.Entities;
using Chat.SERVICE;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAPI.TEST.Builders
{
    public class ChannelServiceBuilder
    {
        private bool _useDefaultChannelRepository = true;
        private IRepository<Channel> _defaultChannelRepository;
        private IRepository<UserChannel> _defaultUserChannelRepository;

        public ChannelServiceBuilder WithChannelRepository(IRepository<Channel> channelRepository, IRepository<UserChannel> userChannelRepository)
        {
            _useDefaultChannelRepository = false;
            _defaultChannelRepository = channelRepository;
            _defaultUserChannelRepository = userChannelRepository;
            return this;
        }

        public Mock<IRepository<Channel>> GetDefaultChannelRepository() => new Mock<IRepository<Channel>>();

        public Mock<IRepository<UserChannel>> GetDefaultUserChannelRepository() => new Mock<IRepository<UserChannel>>();

        public ChannelService Build()
        {
            if (_useDefaultChannelRepository)
            {
                _defaultChannelRepository = GetDefaultChannelRepository().Object;
                _defaultUserChannelRepository = GetDefaultUserChannelRepository().Object;
            }
            return new ChannelService(_defaultChannelRepository, _defaultUserChannelRepository);
        }
    }
}
