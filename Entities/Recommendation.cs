namespace JobSearchPortal.Entities
{
    public class Recommendation
    {
        public int RecommendationId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int JobId { get; set; }
        public Job Job { get; set; }

        public float Score { get; set; }
        public DateTime GeneratedDate { get; set; } = DateTime.UtcNow;
    }
}
