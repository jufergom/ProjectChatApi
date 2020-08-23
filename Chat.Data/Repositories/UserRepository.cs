using Chat.CORE;
using Chat.Data;
using Chat.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chat.DATA.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly ChatContext _context;

        public UserRepository(ChatContext context)
        {
            _context = context;
        }
        public User Add(User entity)
        {
            _context.User.Add(entity);
            return entity;
        }

        public IQueryable<User> All()
        {
            return _context.User;
        }


        public int saveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
