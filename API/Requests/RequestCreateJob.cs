namespace API.Requests
{
    public class RequestCreateJob
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public float Salary { get; set; }

        public RequestCreateJob()
        {
            Title = string.Empty;
            Description = string.Empty;
            Company = string.Empty;
            Email = string.Empty;
        }
    }
}
