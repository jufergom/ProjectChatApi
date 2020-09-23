using Chat.CORE;
using Chat.CORE.DataObjects;
using Chat.DATA.Entities;
using ChatAPI.TEST.Builders;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace ChatAPI.TEST
{
    public class ChannelServiceTest
    {
        [Theory]
        [InlineData("Nuevo Canal","Canal de Prueba")]
        public void Add_NewChannel_Succeeds(string name, string topic)
        {
            var expected = new ChannelTransferObject
            {
                name = name,
                topic = topic
            };

            var builder = new ChannelServiceBuilder();
            var mockChannel = builder.GetDefaultChannelRepository();
            var mockUserChannel = builder.GetDefaultUserChannelRepository();

            mockChannel.Setup(r => r.Add(It.IsAny<Channel>()))
                .Returns(new Channel
                {
                    id = 1,
                    name = name,
                    topic = topic
                });
            mockChannel.Setup(r => r.saveChanges())
                .Returns(1);

            mockUserChannel.Setup(r => r.Add(It.IsAny<UserChannel>()))
                .Returns(new UserChannel
                {
                    idChannel = 1,
                    userTag = null
                });
            mockUserChannel.Setup(r => r.saveChanges())
                .Returns(1);

            var service = builder.WithChannelRepository(mockChannel.Object, mockUserChannel.Object).Build();

            var result = service.addChannel(expected);
            Assert.Equal(ResponseCode.Success, result.ResponseCode);
            Assert.Equal(name, result.Result.name);
            Assert.Equal(topic, result.Result.topic);
        }
    }
}
