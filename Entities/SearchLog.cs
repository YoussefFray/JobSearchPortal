namespace JobSearchPortal.Entities
{
    public class SearchLog
    {
        public int SearchId { get; set; } 
        public int UserId { get; set; }
        public User User { get; set; }

        public string SearchQuery { get; set; }
        public DateTime SearchDate { get; set; } = DateTime.UtcNow;
    }

}
