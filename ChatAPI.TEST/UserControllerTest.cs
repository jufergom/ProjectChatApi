using Chat.CORE;
using Chat.CORE.DataObjects;
using ChatAPI.TEST.Builders;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ChatAPI.TEST
{
    public class UserControllerTest
    {
        [Fact]
        public void GetAll_User_Returns200OK()
        {
            var builder = new UserControllerBuilder();
            var serviceMock = builder.GetDefaultUserService();

            serviceMock.Setup(r => r.getAll())
                .Returns(ServiceResult<IEnumerable<UserTransferObject>>.SuccessResult(
                    Enumerable.Empty<UserTransferObject>()));

            var controller = builder.WithUserService(serviceMock.Object).Build();
            var response = controller.getUsers();

            Assert.IsType<OkObjectResult>(response);
        }

        [Theory]
        [InlineData("Mario","Marioxe","Contraseña")]
        public void Add_NewUser_Returns200OK(string name,string username,string password)
        {
            var expected = new UserTransferObject
            {
                name = name,
                username = username,
                password = password
            };

            var builder = new UserControllerBuilder();
            var serviceMock = builder.GetDefaultUserService();

            serviceMock.Setup(r => r.AddUser(It.IsAny<UserTransferObject>()))
                .Returns(ServiceResult<UserTransferObject>.SuccessResult(
                    new UserTransferObject
                    {
                        name = name,
                        username = username,
                        password = password
                    }));

            var controller = builder.WithUserService(serviceMock.Object).Build();

            var response = controller.addUsers(expected);

            Assert.IsType<OkObjectResult>(response);
        }
    }
}
