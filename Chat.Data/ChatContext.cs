using Chat.DATA.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Chat.Data
{
    public class ChatContext: DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Channel> Channel { get; set; }
        public DbSet<Message> Message { get; set; }

        public DbSet<UserChannel> userChannel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=Data.db");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.Entity<UserChannel>().HasKey(k => new { k.idChannel, k.userTag });
    }
}
