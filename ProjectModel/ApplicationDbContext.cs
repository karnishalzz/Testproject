using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;


namespace ProjectModels
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Project> Projects { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<BatchHost> BatchHosts { get; set; }
        public DbSet<BatchHostParticipate> BatchHostParticipates { get; set; }
        public DbSet<Conference> Conferences { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<Batch>().ToTable("Batch");
            modelBuilder.Entity<BatchHost>().ToTable("BatchHost");
            modelBuilder.Entity<Conference>().ToTable("Conference");
            modelBuilder.Entity<BatchHostParticipate>().ToTable("BatchHostParticipate");


        }
    }
}


//using System.Linq;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;

//namespace Commander.Models
//{
//    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
//    {
//        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//            : base(options)
//        {
//        }




//        protected override void OnModelCreating(ModelBuilder *)
//        {
//            base.OnModelCreating(builder);
//            // Customize the ASP.NET Core Identity model and override the defaults if needed.
//            // For example, you can rename the ASP.NET Core Identity table names and more.
//            // Add your customizations after calling base.OnModelCreating(builder);

//            // https://stackoverflow.com/questions/49326769/entity-framework-core-delete-cascade-and-required/49326983

//            // builder.Entity<ApplicationUser>(entity => {entity.ToTable(name:"IdentityUser"); });
//            // builder.Entity<IdentityRole>(entity => {entity.ToTable(name:"IdentityRole"); });




//            // modelBuilder.Entity<ApplicationUser>().ToTable("IdentityUser");
//            // //AspNetRoles -> Role
//            // modelBuilder.Entity<IdentityRole>().ToTable("IdentityRole");
//            // //AspNetUserRoles -> UserRole
//            // modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
//            // //AspNetUserClaims -> UserClaim
//            // modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
//            // //AspNetUserLogins -> UserLogin
//            // modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
//            // modelBuilder.Entity<Conference>().HasRequired(s => s.Participant).WithMany().WillCascadeOnDelete(false);
//            // modelBuilder.Entity<BatchHost>().HasRequired(s => s.Project).WithMany().WillCascadeOnDelete(false);
//            // modelBuilder.Entity<BatchHostParticipant>().HasRequired(s => s.Host).WithMany().WillCascadeOnDelete(false);
//            // modelBuilder.Entity<BatchHostParticipant>().HasRequired(s => s.Project).WithMany().WillCascadeOnDelete(false);

//            // modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

//            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
//            {
//                relationship.DeleteBehavior = DeleteBehavior.Restrict;
//            }

//        }



//        #region DbSet
//        public DbSet<Project> Project { get; set; }
//        public DbSet<Batch> Batch { get; set; }
//        public DbSet<BatchHost> BatchHost { get; set; }
//        public DbSet<BatchHostParticipant> BatchHostParticipant { get; set; }
//        public DbSet<Conference> Conference { get; set; }
//        public DbSet<ConferenceHistory> ConferenceHistory { get; set; }
//        public DbSet<Command> Command { get; set; }
//        #endregion


//    }
//}
