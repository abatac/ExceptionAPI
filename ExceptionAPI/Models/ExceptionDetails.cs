using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace ExceptionAPI.Models
{
    public class ExceptionDetails
    {
        [JsonProperty("type")]
        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        [JsonProperty("color")]
        [Required]
        [MaxLength(50)]
        public string Color { get; set; }

        [JsonProperty("size")]
        [Required]
        [MaxLength(50)]
        public string Size { get; set; }

        [JsonProperty("description")]
        [MaxLength(500)]
        public string Description { get; set; }

        [JsonProperty("notes")]
        [MaxLength(500)]
        public string Notes { get; set; }

        [JsonProperty("picture_urls")]
        public String[] PictureUrls { get; set; }
    }
}
