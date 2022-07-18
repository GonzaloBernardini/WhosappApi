using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whosapp.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }        
        public string? Name { get; set; }

        [Required(ErrorMessage = "Se requiere un nombre de usuario")]
        public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Se requiere un email")]
        public string? Email { get; set; }

        public string Role { get; set; } 
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;        
        public string? TelNumber { get; set; }
        public GroupChat? GroupChat { get; set; }
        public string Photo { get; set; }
        public Contacts ContactList { get; set; }

        [ForeignKey("Chat")]
        public int ChatId { get; set; }
        public IList<Chat> Chats { get; set; }

    }
}
