using Chat.CORE;
using Chat.Data;
using Chat.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chat.DATA.Repositories
{
    public class ChannelRepository : IRepository<Channel>
    {
        private readonly ChatContext _context;

        public ChannelRepository(ChatContext context)
        {
            _context = context;
        }
        public Channel Add(Channel entity)
        {
            _context.Channel.Add(entity);
            return entity;
        }

        public IQueryable<Channel> All()
        {
            return _context.Channel;
        }

        public int saveChanges()
        {
            return _context.SaveChanges();
        }
    }

}
