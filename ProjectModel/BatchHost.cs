using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using static ProjectModels.ApplicationDbContext;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectModel;

namespace ProjectModels
{
    public class BatchHost : BaseClass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public Guid BatchId { get; set; }
        public string HostId { get; set; }


        [NotMapped]
        public virtual ICollection<Batch> Batches { get; set; }
        public virtual ICollection<ApplicationUser> Hosts { get; set; }
    }
}
