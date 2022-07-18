using System.Threading.Tasks;
using Whosapp.Entities;

namespace Whosapp.Repository.Interface
{
    public interface IChatRepo : IGenericRepo<Chat>
    {
        Task AddMessage(Chat message);
    }
}
