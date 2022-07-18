using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Whosapp.Entities;
using Whosapp.Entities.Authentication;

namespace Whosapp.Service
{
    public interface IUserService
    {
        AuthenticateResponse RegisterUser(AuthenticateRequest usuario, string password);
        AuthenticateResponse RegisterAdmin(AuthenticateRequest usuario, string password);
        AuthenticateResponse Login(string email, string password);
        string GetToken(AuthenticateResponse usuario);
    }
}
