﻿using Newtonsoft.Json;
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

        [JsonProperty("color")]
        [Display(Name = "color")]
        [Required]
        [MaxLength(50)]
        public string Color { get; set; }

        [JsonProperty("size")]
        [Display(Name = "size")]
        [Required]
        [MaxLength(50)]
        public string Size { get; set; }

        [JsonProperty("description")]
        [Display(Name = "description")]
        [MaxLength(500)]
        public string Description { get; set; }

        [JsonProperty("notes")]
        [Display(Name = "notes")]
        [MaxLength(500)]
        public string Notes { get; set; }

        [JsonProperty("picture_urls")]
        [Display(Name = "picture_urls")]
        public String[] PictureUrls { get; set; }
    }
}
