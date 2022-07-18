using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whosapp.Entities
{
    public class GroupChat
    {
        [Key]
        public int Id { get; set; }
        public string Chatname { get; set; }
        public ChatMessage Message { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public IList<User> Users { get; set; }
    }
}
