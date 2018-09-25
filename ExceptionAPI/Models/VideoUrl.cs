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
        [Display(Name = "speed")]
        [Required]
        public int Speed { get; set; }

        [JsonProperty("heading")]
        [Display(Name = "heading")]
        [Required]
        public int Heading { get; set; }

        [JsonProperty("camera_number")]
        [Display(Name = "camera_number")]
        [Required]
        public int Camera { get; set; }

        [JsonProperty("start_datetime")]
        [Display(Name = "start_datetime")]
        [Required]
        public DateTime StartDateTime { get; set; }

        [JsonProperty("end_datetime")]
        [Display(Name = "end_datetime")]
        [Required]
        public DateTime EndDateTime { get; set; }

        [JsonProperty("lat")]
        [Display(Name = "lat")]
        [Required]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        [Display(Name = "lon")]
        [Required]
        public double Longitude { get; set; }

        [JsonProperty("altitude")]
        [Display(Name = "altitude")]
        [Required]
        public int Altitude { get; set; }

        [JsonProperty("download_url")]
        [Display(Name = "download_url")]
        [Required]
        [MaxLength(500)]
        public string MDTUrl { get; set; }

        [JsonProperty("play_url")]
        [Display(Name = "play_url")]
        [Required]
        [MaxLength(500)]
        public string Url { get; set; }
    }
}
