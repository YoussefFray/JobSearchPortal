using static System.Net.Mime.MediaTypeNames;

namespace JobSearchPortal.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } // JobSeeker or Recruiter
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }

        public ICollection<Job> Jobs { get; set; } // For recruiters
        public ICollection<Application> Applications { get; set; } // For job seekers
        public ICollection<Recommendation> Recommendations { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<SearchLog> SearchLogs { get; set; }
    }
}
