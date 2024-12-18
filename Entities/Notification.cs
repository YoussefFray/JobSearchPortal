using System.Text.Json.Serialization;

namespace JobSearchPortal.Entities
{
    public class Notification
    {
        public int NotificationId { get; set; }

        public int UserId { get; set; }
        [JsonIgnore]
        public User ? User { get; set; }

        public string Message { get; set; }
        public string Type { get; set; } // e.g., JobPosted, ApplicationStatus
        public bool IsRead { get; set; } = false;
        public DateTime SentDate { get; set; } = DateTime.UtcNow;
    }
}
