using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whosapp.Entities
{
    public class ChatMessage
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Se requiere un mensaje")]
        public string? Message { get; set; }

        [ForeignKey("User")]
        public int? UserId_Emisor { get; set; }
        public User? UserEmisor { get; set; }

        [ForeignKey("User")]
        public int? UserId_Receptor { get; set; }
        public User? UserReceptor { get; set; }


    }
}
