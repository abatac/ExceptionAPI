using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExceptionAPI.Data
{
    public class ExceptionEntity
    {
        [Key]
        public int ExceptionId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Vin { get; set; }

        [Required]
        public long AccountId { get; set; }

        [Required]
        [MaxLength(50)]
        public string EventType { get; set; }

        [Required]
        [MaxLength(50)]
        public string TransactionId { get; set; }

        [Required]
        public DateTimeOffset DateTime { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        [MaxLength(100)]
        public string Street1 { get; set; }

        [MaxLength(100)]
        public string Street2 { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(50)]
        public string State { get; set; }

        [Required]
        [MaxLength(50)]
        public string ZipCode { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        [MaxLength(50)]
        public string ExceptionType { get; set; }

        [MaxLength(50)]
        public string ExceptionColor { get; set; }

        [MaxLength(50)]
        public string ExceptionSize { get; set; }

        [MaxLength(500)]
        public string ExceptionDesciption { get; set; }

        [MaxLength(500)]
        public string ExceptionNotes { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public ICollection<ExceptionUrlEntity> Urls { get; set; }
    }
}