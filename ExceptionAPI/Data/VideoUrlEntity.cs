using System;
using System.ComponentModel.DataAnnotations;

namespace ExceptionAPI.Data
{
    public class VideoUrlEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Speed { get; set; }

        [Required]
        public int Heading { get; set; }

        [Required]
        public DateTimeOffset StartDateTime { get; set; }

        [Required]
        public DateTimeOffset EndDateTime { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public int Altitude { get; set; }

        [Required]
        [MaxLength(500)]
        public string MDTUrl { get; set; }

        [Required]
        [MaxLength(500)]
        public string Url { get; set; }

        public int ExceptionId { get; set; }
        public ExceptionEntity ExceptionEntity { get; set; }
    }
}
