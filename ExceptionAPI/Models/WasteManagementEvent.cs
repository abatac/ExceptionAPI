using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExceptionAPI.Models
{
    public class WasteManagementEvent
    {
        [JsonProperty("vin")]
        [Display(Name ="vin")]
        [Required]
        [MaxLength(50)]
        public string Vin { get; set; }

        [JsonProperty("account_id")]
        [Display(Name = "account_id")]
        [Required]
        public string AccountId { get; set; }

        [JsonProperty("event_id")]
        [Display(Name = "event_id")]
        [Required]
        [MaxLength(50)]
        public string EventId { get; set; }

        [JsonProperty("event_type")]
        [Display(Name = "event_type")]
        [Required]
        [MaxLength(50)]
        public string EventType { get; set; }

        [JsonProperty("transaction_id")]
        [Display(Name = "transaction_id")]
        [Required]
        [MaxLength(50)]
        public string TransactionId { get; set; }

        [JsonProperty("container_color")]
        [Display(Name = "container_color")]
        [MaxLength(50)]
        public string ContainerColor { get; set; }

        [JsonProperty("container_size")]
        [Display(Name = "container_size")]
        [MaxLength(50)]
        public string ContainerSize { get; set; }

        [JsonProperty("container_type")]
        [Display(Name = "container_type")]
        [MaxLength(50)]
        public string ContainerType { get; set; }

        [JsonProperty("datetime_utc")]
        [Display(Name = "datetime_utc")]
        public DateTime DateTime { get; set; }

        [JsonProperty("address")]
        [Display(Name = "address")]
        [Required]
        public Address Address { get; set; }

        [JsonProperty("latitude")]
        [Display(Name = "latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        [Display(Name = "longitude")]
        public double Longitude { get; set; }

        [JsonProperty("video_status")]
        [Display(Name = "video_status")]
        [MaxLength(100)]
        public string VideoStatus { get; set; }

        [JsonProperty("exception_details")]
        [Display(Name = "exception_details")]
        public ExceptionDetails ExceptionDetails { get; set; }

        [JsonProperty("video_urls")]
        [Display(Name = "video_urls")]
        public ICollection<VideoUrl> VideoUrls { get; set; }
    }
}
