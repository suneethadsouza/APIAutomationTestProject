using Newtonsoft.Json;

namespace APIAutomationTestProject.Model
{
    public class User
    {
        public string Id { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string City { get; set; }
    }
}

