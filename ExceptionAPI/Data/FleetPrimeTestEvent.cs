using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExceptionAPI.Data
{
    public class FleetPrimeTestEvent
    {
        public int Id { get; set; }

        public bool Success  { get; set; }

        public string ErrorMessage { get; set; }

        public string Vin { get; set; }

        public string AccountId { get; set; }

        public string EventType { get; set; }

        public string TransactionId { get; set; }

        public DateTime DateTime { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Street1 { get; set; }

        public string Street2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }

        public DateTime DateCreated { get; set; }

        public string ContainerColor { get; set; }

        public string ContainerSize { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string Notes { get; set; }

        public string ImageURL1 { get; set; }

        public string ImageURL2 { get; set; }

        public string ImageURL3 { get; set; }

        public string ContainerType { get; set; }

        public string ContactName { get; set; }

        public string ContactNumber { get; set; }
    }
}