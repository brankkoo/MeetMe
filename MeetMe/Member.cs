using Newtonsoft.Json;

namespace MeetMe
{
    public class Member
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
    }
}