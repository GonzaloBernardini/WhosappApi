using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whosapp.Entities
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }

        public User User { get; set; }

        [Required(ErrorMessage = "Se requiere un mensaje")]
        public ChatMessage Message { get; set; }

        public DateTime Time { get; set; } = DateTime.Now;

        public string Photo { get; set; }
    }
}
