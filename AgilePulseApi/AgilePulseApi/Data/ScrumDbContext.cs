using AgilePulseApi.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AgilePulseApi.Data
{
    public class ScrumDbContext:DbContext
    {
        public ScrumDbContext(DbContextOptions<ScrumDbContext> options):base(options)
        {
            
        }

        public DbSet<ScrumUser> ScumUser { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Issue> Issue { get; set; }
        public DbSet<Cycle> Cycle { get; set; }
        public DbSet<ScrumUserProject> ScrumUserProject { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Project
            modelBuilder.Entity<Project>().HasOne(x => x.scrumUser).WithMany(x => x.projects).HasForeignKey(x => x.LeadId);

            // Issue
          
            modelBuilder.Entity<Issue>().Property(x => x.StartDate).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Issue>().HasOne(x => x.scrumUser).WithMany(x => x.issues).HasForeignKey(x => x.scrumUserId);
            modelBuilder.Entity<Issue>().HasOne(x => x.project).WithMany(x => x.issues).HasForeignKey(x => x.projectId);
            modelBuilder.Entity<Issue>().HasOne(x => x.cycle).WithMany(x => x.issues).HasForeignKey(x => x.cycleId);

            // Cycle

            modelBuilder.Entity<Cycle>().Property(x => x.StartDate).HasDefaultValueSql("GETDATE()");


            //ScrumUserPrjoect
            modelBuilder.Entity<ScrumUserProject>().HasKey(b => new { b.ScrumUserId, b.ProjectId });
            modelBuilder.Entity<ScrumUserProject>().HasOne(b => b.ScrumUser).WithMany(b => b.ScrumUserProjects).HasForeignKey(b => b.ScrumUserId);
            modelBuilder.Entity<ScrumUserProject>().HasOne(b => b.Project).WithMany(b => b.ScrumUserProjects).HasForeignKey(b => b.ProjectId);
        }
    }
}
