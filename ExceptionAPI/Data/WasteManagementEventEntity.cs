using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExceptionAPI.Data
{
    public class WasteManagementEventEntity
    {
        [Required]
        [MaxLength(50)]
        [Key]
        public string EventId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Vin { get; set; }

        [Required]
        [MaxLength(50)]
        public string AccountId { get; set; }

        [Required]
        [MaxLength(50)]
        public string EventType { get; set; }

        [Required]
        [MaxLength(50)]
        public string TransactionId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

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

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        [MaxLength(50)]
        public string ContainerColor { get; set; }

        [Required]
        [MaxLength(50)]
        public string ContainerSize { get; set; }

        [MaxLength(100)]
        public string VideoStatus { get; set; }

        public ExceptionDetailsEntity ExceptionDetails { get; set; }

        public ICollection<ImageEntity> Images { get; set; }

        public ICollection<VideoEntity> Videos { get; set; }
    }
}