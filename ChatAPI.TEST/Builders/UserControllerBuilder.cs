using Chat.API.Controllers;
using Chat.SERVICE;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatAPI.TEST.Builders
{

    public class UserControllerBuilder
    {
        private IUserService _defaultUserService;
        private bool _useDefaultChannelService = true;
        public UserControllerBuilder WithUserService(IUserService channelService)
        {
            _useDefaultChannelService = false;
            _defaultUserService = channelService;
            return this;
        }


        public UserController Build()
        {
            if (_useDefaultChannelService)
                _defaultUserService = GetDefaultUserService().Object;
            return new UserController(_defaultUserService);
        }

        public Mock<IUserService> GetDefaultUserService()
        {
            return new Mock<IUserService>();
        }
    }   
}
