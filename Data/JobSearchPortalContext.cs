using JobSearchPortal.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobSearchPortal.Data
{
    public class JobSearchPortalContext : DbContext
    {
        public JobSearchPortalContext(DbContextOptions<JobSearchPortalContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<SearchLog> SearchLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relationships
            modelBuilder.Entity<Job>()
                .HasOne(j => j.Recruiter)
                .WithMany(u => u.Jobs)
                .HasForeignKey(j => j.RecruiterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Application>()
                .HasOne(a => a.Job)
                .WithMany(j => j.Applications)
                .HasForeignKey(a => a.JobId);

            modelBuilder.Entity<Application>()
                .HasOne(a => a.User)
                .WithMany(u => u.Applications)
                .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<Recommendation>()
                .HasOne(r => r.User)
                .WithMany(u => u.Recommendations)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Recommendation>()
                .HasOne(r => r.Job)
                .WithMany()
                .HasForeignKey(r => r.JobId);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId);

            modelBuilder.Entity<SearchLog>()
                 .HasKey(s => s.SearchId);
            modelBuilder.Entity<SearchLog>()
                .HasOne(s => s.User)
                .WithMany(u => u.SearchLogs)
                .HasForeignKey(s => s.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
