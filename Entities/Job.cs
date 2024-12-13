using static System.Net.Mime.MediaTypeNames;

namespace JobSearchPortal.Entities
{
    public class Job
    {
        public int JobId { get; set; }
        public string ?Title { get; set; }
        public string ?Description { get; set; }
        public string ?Company { get; set; }
        public string ?Location { get; set; }
        public string ?SalaryRange { get; set; }
        public DateTime PostedDate { get; set; } = DateTime.UtcNow;

        public int ? RecruiterId { get; set; }
        public User ?Recruiter { get; set; }

        public ICollection<Application>? Applications { get; set; }
    }
}
