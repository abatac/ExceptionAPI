using Newtonsoft.Json;
using System.Collections.Generic;

namespace FleetPrimeTestUI.Models
{
    public class ErrorModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("messages")]
        public ICollection<string> Messages { get; set; }
    }
}
