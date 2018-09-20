using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace ExceptionAPI.Models
{
    public class ExceptionDetails
    {
        [JsonProperty("type")]
        [Display(Name ="type")]
        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        [JsonProperty("description")]
        [Display(Name = "description")]
        [MaxLength(500)]
        public string Description { get; set; }

        [JsonProperty("notes")]
        [Display(Name = "notes")]
        [MaxLength(500)]
        public string Notes { get; set; }

        [JsonProperty("max_weight_allowed")]
        [Display(Name = "max_weight_allowed")]
        [Required]
        public int MaximumWeightAllowed { get; set; }

        [JsonProperty("actual_weight")]
        [Display(Name = "actual_weight")]
        [Required]
        public int ActualWeight { get; set; }

        [JsonProperty("weight_units")]
        [Display(Name = "weight_units")]
        [MaxLength(50)]
        [Required]
        public string WeightUnits { get; set; }

        [JsonProperty("picture_urls")]
        [Display(Name = "picture_urls")]
        public String[] PictureUrls { get; set; }
    }
}
