using System.Text.Json.Serialization;

namespace API.Responses
{
    public class ResponseAllJob
    {
        [JsonPropertyName("id_job")]
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public float Salary { get; set; }

        [JsonPropertyName("is_new")]
        public bool IsNew { get; set; }

        public ResponseAllJob()
        {
            Title = string.Empty;
            Company = string.Empty;
        }
    }
}
