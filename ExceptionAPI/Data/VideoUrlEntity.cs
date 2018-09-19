﻿using System;
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
        public int Camera { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; }

        [Required]
        public DateTime EndDateTime { get; set; }

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

        public string EventId { get; set; }
        public WasteManagementEventEntity WasteManagementEventEntity { get; set; }
    }
}
