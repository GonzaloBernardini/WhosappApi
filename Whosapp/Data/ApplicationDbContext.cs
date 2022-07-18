using Microsoft.EntityFrameworkCore;
using Whosapp.Entities;

namespace Whosapp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<GroupChat> GroupChats { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Contacts> Contacts { get; set; }

        public DbSet<Role> Roles { get; set; }


        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(b => b.);
        }
        */

    }
}
