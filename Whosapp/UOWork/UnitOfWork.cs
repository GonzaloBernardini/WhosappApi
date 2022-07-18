using Whosapp.Data;
using Whosapp.Repository.Class;
using Whosapp.Repository.Interface;

namespace Whosapp.UOWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IUserRepo UserRepository { get; private set; }
        public IChatRepo ChatRepository { get; private set; }

        public IGroupChatRepo GroupChatRepository { get; private set; }

        public IChatMessageRepo ChatMessageRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            UserRepository = new UserRepo(context);
            ChatRepository = new ChatRepo(context);
            GroupChatRepository = new GroupChatRepo(context);
            ChatMessageRepository = new ChatMessageRepo(context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
