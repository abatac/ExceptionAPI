using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetPrimeTestUI.Models
{
    public class Event
    {
        [JsonProperty("vin")]
        public string Vin { get; set; }

        [JsonProperty("event_type")]
        public string EventType { get; set; }

        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("container_color")]
        public string ContainerColor { get; set; }

        [JsonProperty("container_size")]
        public string ContainerSize { get; set; }

        [JsonProperty("datetime_utc")]
        public DateTime DateTime { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("exception_details", NullValueHandling = NullValueHandling.Ignore)]
        public ExceptionDetails ExceptionDetails { get; set; }
    }   
}
