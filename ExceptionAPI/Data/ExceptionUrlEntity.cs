using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionAPI.Data
{
    public class ExceptionUrlEntity
    {

        public const string IMAGE = "Image";
        public const string VIDEO = "Video";

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string MediaType { get; set; }

        [Required]
        [MaxLength(500)]
        public string Url { get; set; }

        public int ExceptionId { get; set; }
        public ExceptionEntity ExceptionItem { get; set; }
    }
}
