using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Whosapp.Entities.Authentication
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string  Role { get; set; }
       
    }
}
