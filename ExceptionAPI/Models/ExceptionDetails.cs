﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExceptionAPI.Models
{
    public class ExceptionDetails
    {
        [JsonProperty("type")]
        [Display(Name ="type")]
        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        [JsonProperty("contact_name")]
        [Display(Name = "contact_name")]
        [MaxLength(20)]
        public string ContactName { get; set; }

        [JsonProperty("contact_number")]
        [Display(Name = "contact_number")]
        public int ContactNumber { get; set; }

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
        public ICollection<string> PictureUrls { get; set; }
    }
}
