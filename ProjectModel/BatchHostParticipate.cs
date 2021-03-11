using ProjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static ProjectModels.ApplicationDbContext;

namespace ProjectModels
{
    public class BatchHostParticipate : BaseClass
    {
        [Key]
        public Guid Id { get; set; }
        public Guid BatchId { get; set; }
        public string HostId { get; set; }
        public string ParticipateId { get; set; }

        [NotMapped]
        public virtual ApplicationUser Host { get; set; }
        public virtual ICollection<ApplicationUser> Participants { get; set; }
    }
}
