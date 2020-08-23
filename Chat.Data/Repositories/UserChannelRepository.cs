using Chat.CORE;
using Chat.CORE.DataObjects;
using Chat.Data;
using Chat.DATA.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chat.DATA.Repositories
{
    public class UserChannelRepository : IRepository<UserChannel>
    {
        private readonly ChatContext _chatContext;

        public UserChannelRepository(ChatContext chatContext)
        {
            _chatContext = chatContext;
        }
        public UserChannel Add(UserChannel entity)
        {
            _chatContext.Add(entity);
            return entity;
        }

        public IQueryable<UserChannel> All()
        {
            return _chatContext.userChannel;
        }

        public int saveChanges()
        {
            return _chatContext.SaveChanges();
        }
    }
}
