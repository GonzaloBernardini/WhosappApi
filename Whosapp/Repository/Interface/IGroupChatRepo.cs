using Whosapp.Entities;

namespace Whosapp.Repository.Interface
{
    public interface IGroupChatRepo : IGenericRepo<GroupChat>
    {
        public User GetByName(string nombre);
        public void KickFromGroup(string nombre);

    }
}
