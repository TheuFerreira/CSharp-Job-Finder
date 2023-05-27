namespace API.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public float Salary { get; set; }
        public DateTime CreatedAt { get; set; }

        public Job()
        {
            Title = string.Empty;
            Description = string.Empty;
            Company = string.Empty;
            Email = string.Empty;
        }
    }
}
