using Newtonsoft.Json;

namespace FleetPrimeTestUI.Models
{
    public class ErrorModel
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
