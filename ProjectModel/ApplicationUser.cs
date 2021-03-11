using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel
{
    public class ApplicationUser : IdentityUser
    {

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? LastLogOn { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DeActivateOn { get; set; }
        public int UserType { get; set; }

        [NotMapped]
        public virtual IIdentity Identity { get; set; }

        public enum UserTypes { Admin, Host, Participant }
    }
}
