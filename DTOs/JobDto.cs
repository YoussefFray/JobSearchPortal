namespace JobSearchPortal.DTOs
{
    public class JobDto
    {
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public string Location { get; set; }
        public string SalaryRange { get; set; }
        public DateTime PostedDate { get; set; }
        public string RecruiterUsername { get; set; }
    }

}
