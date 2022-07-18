using System;
using System.Threading.Tasks;
using Whosapp.Data;
using Whosapp.Entities;
using Whosapp.Repository.Interface;

namespace Whosapp.Repository.Class
{
    public class ChatRepo : GenericRepo<Chat>, IChatRepo
    {
        readonly ApplicationDbContext _db;
        public ChatRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task AddMessage(Chat message)
        {
            try
            {
                //Add chat object to table
                await _db.Chats.AddAsync(message);
                //save changes.
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
