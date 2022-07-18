using System;
using Whosapp.Data;
using Whosapp.Entities;
using Whosapp.Repository.Interface;

namespace Whosapp.Repository.Class
{
    public class GroupChatRepo : GenericRepo<GroupChat>, IGroupChatRepo
    {
        public GroupChatRepo(ApplicationDbContext db) : base(db)
        {
        }

        public User GetByName(string nombre)
        {
            var aux = _db.Set<User>().Find(nombre);
            return aux;
        }

        public void KickFromGroup(string nombre)
        {
            var entity = GetByName(nombre);
            if (entity == null)
                throw new Exception("No se encontro objeto");
            _db.Set<User>().Remove(entity);
        }

    }
}
