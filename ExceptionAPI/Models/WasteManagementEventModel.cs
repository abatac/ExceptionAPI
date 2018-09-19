using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExceptionAPI.Models
{
    public class WasteManagementEventModel
    {
        [JsonProperty("vin")]
        [Required]
        [MaxLength(50)]
        public string Vin { get; set; }

        [JsonProperty("account_id")]
        [Required]
        public long AccountId { get; set; }

        [JsonProperty("event_id")]
        [Required]
        [MaxLength(50)]
        public string EventId { get; set; }

        [JsonProperty("event_type")]
        [Required]
        [MaxLength(50)]
        public string EventType { get; set; }

        [JsonProperty("transaction_id")]
        [Required]
        [MaxLength(50)]
        public string TransactionId { get; set; }

        [JsonProperty("date_time")]
        public DateTime DateTime { get; set; }

        [JsonProperty("address")]
        [Required]
        public Address Address { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("exception_details")]
        public ExceptionDetails ExceptionDetails { get; set; }

        [JsonProperty("video_urls")]
        public ICollection<VideoUrl> VideoUrls { get; set; }
    }
}
