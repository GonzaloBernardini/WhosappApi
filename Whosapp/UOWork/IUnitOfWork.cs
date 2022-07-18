using System;
using Whosapp.Repository.Interface;

namespace Whosapp.UOWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepo UserRepository { get; }
        IChatRepo ChatRepository { get; }
        IGroupChatRepo GroupChatRepository { get; }
        IChatMessageRepo ChatMessageRepository { get; }
        void Save();
    }
}
