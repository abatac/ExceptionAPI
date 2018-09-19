using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionAPI.Models
{
    public class VideoUrl
    {
        [JsonProperty("speed")]
        [Required]
        public int Speed { get; set; }

        [JsonProperty("heading")]
        [Required]
        public int Heading { get; set; }

        [JsonProperty("camera")]
        [Required]
        public int Camera { get; set; }

        [JsonProperty("start_date_time")]
        [Required]
        public DateTime StartDateTime { get; set; }

        [JsonProperty("end_date_time")]
        [Required]
        public DateTime EndDateTime { get; set; }

        [JsonProperty("latitude")]
        [Required]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        [Required]
        public double Longitude { get; set; }

        [JsonProperty("altitude")]
        [Required]
        public int Altitude { get; set; }

        [JsonProperty("mdt_url")]
        [Required]
        [MaxLength(500)]
        public string MDTUrl { get; set; }

        [JsonProperty("url")]
        [Required]
        [MaxLength(500)]
        public string Url { get; set; }
    }
}
