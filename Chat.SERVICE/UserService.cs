using Chat.CORE;
using Chat.CORE.DataObjects;
using Chat.DATA.Entities;
using Chat.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chat.SERVICE
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public ServiceResult<UserTransferObject> AddUser(UserTransferObject user)
        {
            var newUser = new User
            {
                name = user.name,
                username = user.username,
                password = user.password
            };

            _userRepository.Add(newUser);
            _userRepository.saveChanges();

            return ServiceResult<UserTransferObject>.SuccessResult(user);
        }

        public ServiceResult<bool> checkCredentials(UserTransferObject user)
        {
            var check = _userRepository.All().Where(x => (x.username == user.username) && ( x.password == user.password)).FirstOrDefault();
            if (check != null)
            {
                return ServiceResult<bool>.SuccessResult(true);
            }

            return ServiceResult<bool>.ErrorResult("Bad Credentials");
        }

        public ServiceResult<IEnumerable<UserTransferObject>> getAll()
        {
            var users = _userRepository.All()
                .Select(x => new UserTransferObject
                {
                    name = x.name,
                    username = x.username,
                    password = x.password
                });

            return ServiceResult<IEnumerable<UserTransferObject>>.SuccessResult(users);
        }
    }
}
