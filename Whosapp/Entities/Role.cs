using System.ComponentModel.DataAnnotations;

namespace Whosapp.Entities
{
    public class Role
    {
        private string admin;

        private string user;

        private string groupadmin;
        [Key]
        public int Id { get; set; }

        public string Admin { get => admin ; set => admin = "Admin"  ; }

        public string User  { get => user;set=> user = "User"; }

        public string GroupAdmin { get => groupadmin; set=> groupadmin = "GroupAdmin"; }
        
        
    }
}
