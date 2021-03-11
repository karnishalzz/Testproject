using ProjectModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static ProjectModels.ApplicationDbContext;

namespace ProjectModel
{
    public class Conference : BaseClass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string RoomId { get; set; }
        public Guid BatchId { get; set; }
        public string HostId { get; set; }
        public string ParticipateId { get; set; }


        [NotMapped]
        public virtual Batch Batch { get; set; }
        public virtual ICollection<ApplicationUser> Host { get; set; }
        public virtual ICollection<ApplicationUser> Participate { get; set; }
    }
}
