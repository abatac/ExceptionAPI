using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionAPI.Models
{
    public class Address
    {
        [JsonProperty("street1")]
        [Display(Name ="street1")]
        [Required]
        [MaxLength(100)]
        public string Street1 { get; set; }

        [JsonProperty("street2")]
        [Display(Name = "street2")]
        [MaxLength(100)]
        public string Street2 { get; set; }

        [JsonProperty("city")]
        [Display(Name = "city")]
        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [JsonProperty("state")]
        [Display(Name = "state")]
        [Required]
        [MaxLength(50)]
        public string State { get; set; }

        [JsonProperty("zipcode")]
        [Display(Name = "zipcode")]
        [Required]
        [MaxLength(50)]
        public string ZipCode { get; set; }

        [JsonProperty("country")]
        [Display(Name = "country")]
        [MaxLength(50)]
        public string Country { get; set; }
    }
}
