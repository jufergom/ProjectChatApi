using Chat.CORE;
using Chat.CORE.DataObjects;
using Chat.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.SERVICE
{
    public interface IUserService
    {
        public ServiceResult<UserTransferObject> AddUser(UserTransferObject user);

        public ServiceResult<bool> checkCredentials(UserTransferObject user);

        public ServiceResult<IEnumerable<UserTransferObject>> getAll();
    }
}
