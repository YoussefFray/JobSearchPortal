using System.Text.Json.Serialization;

namespace JobSearchPortal.Entities
{
    public class Application
    {
        public int ApplicationId { get; set; }

        public int ? JobId { get; set; }
        [JsonIgnore]
        public Job? Job { get; set; }

        public int ?UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }

        public string Status { get; set; } = "Pending"; // Pending, Accepted, Rejected
        public DateTime AppliedDate { get; set; } = DateTime.UtcNow;
    }
}
