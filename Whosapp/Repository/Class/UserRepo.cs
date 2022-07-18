using System.Linq;
using Whosapp.Data;
using Whosapp.Entities;
using Whosapp.Repository.Interface;

namespace Whosapp.Repository.Class
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        private readonly ApplicationDbContext _context;

        public UserRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(a => a.Email == email);
        }

        public bool ExisteUsuario(string email)
        {

            return _context.Users.Any(a => a.Email == email);
        }

    }
}
