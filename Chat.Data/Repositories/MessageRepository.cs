using Chat.CORE;
using Chat.Data;
using Chat.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chat.DATA.Repositories
{
    public class MessageRepository: IRepository<Message>
    {
        private readonly ChatContext _context;

        public MessageRepository(ChatContext context)
        {
            _context = context;
        }

        public Message Add(Message entity)
        {
            _context.Message.Add(entity);
            return entity;
        }

        public IQueryable<Message> All()
        {
            return _context.Message;
        }

        public int saveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
