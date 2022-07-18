using Whosapp.Data;
using Whosapp.Entities;
using Whosapp.Repository.Interface;

namespace Whosapp.Repository.Class
{
    public class ChatMessageRepo : GenericRepo<ChatMessage>, IChatMessageRepo
    {
        public ChatMessageRepo(ApplicationDbContext db) : base(db)
        {
        }
    }
}
