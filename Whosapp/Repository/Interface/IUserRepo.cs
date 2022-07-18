using Whosapp.Entities;

namespace Whosapp.Repository.Interface
{
    public interface IUserRepo : IGenericRepo<User>
    {
        User GetByEmail(string email);
        bool ExisteUsuario(string email);
    }
}
