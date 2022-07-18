using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Whosapp.Entities.Authentication
{
    public class AuthenticateRequest
    {
        [Required(ErrorMessage = "Se requiere un nombre de usuario")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Se requiere un email")]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
