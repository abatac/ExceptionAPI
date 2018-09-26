using FleetPrimeTestUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FleetPrimeTestUI.Models.EventViewData;

namespace FleetPrimeTestUI.Util
{
    public class TestDataGenerator
    {
        public EventViewData CreateEventViewData()
        {
            return new EventViewData
            {
                RejectReasons = new Dictionary<string, string>
                {
                    {"WEIGHT_EXCEEDED", "Weight exceeded."},
                    {"CONTAINER_NOT_OUT", "Container not out."},
                    {"OVERFLOW", "Overflow"},
                    {"CONTAMINATED", "Contaminated"},
                    {"OTHERS", "Others"},
                },
                Addresses = new Dictionary<int, AddressData>
                {
                    {0, new AddressData
                    {
                        Street1 = "Vista Bonita Dr",
                        Street2 = "Some County",
                        City = "Irvine",
                        State = "CA",
                        ZipCode = "92617",
                        Country = "USA",
                        Latitude = 33.638324,
                        Longitude = -117.842256
                    }},
                    {1, new AddressData
                    {
                        Street1 = "61-1 Mistral Ln",
                        Street2 = "Some County",
                        City = "Irvine",
                        State = "CA",
                        ZipCode = "92617",
                        Country = "USA",
                        Latitude = 33.634066,
                        Longitude = -117.839353
                    }},
                    {2, new AddressData
                    {
                        Street1 = "2-26 E 57th St",
                        Street2 = "Some County",
                        City = "New York",
                        State = "CA",
                        ZipCode = "10022",
                        Country = "USA",
                        Latitude = 40.762620,
                        Longitude = -73.973126
                    }},
                      {3, new AddressData
                    {
                        Street1 = "144-55-144-11 76th Rd",
                        Street2 = "Some County",
                        City = "Flushing",
                        State = "NY",
                        ZipCode = "11367",
                        Country = "USA",
                        Latitude = 40.722413,
                        Longitude = -73.818147
                    }},
                    {4, new AddressData {

                        Street1 = "800-898 Lakeview Ave",
                        Street2 = "Some County",
                        City = "Laurel Springs",
                        State = "NJ",
                        ZipCode = "08021",
                        Country = "USA",
                        Latitude = 39.819397,
                        Longitude = -75.008047
                    }},
                     {5, new AddressData {

                        Street1 = "1901-1917 W Adams Blvd",
                        Street2 = "Some County",
                        City = "Los Angeles",
                        State = "CA",
                        ZipCode = "90018",
                        Country = "USA",
                        Latitude = 34.032691,
                        Longitude = -118.306579
                    }},
                       {6, new AddressData {
                        Street1 =  "101-195 W 67th St",
                        Street2 = "Some County",
                        City = "Laurel Springs",
                        State = "CA",
                        ZipCode = "90003",
                        Country = "USA",
                        Latitude = 33.979003,
                        Longitude = -118.275787
                    }},
                        {7, new AddressData {
                        Street1 =  "14598-14588 S Figueroa St",
                        Street2 = "Some County",
                        City = "Gardena",
                        State = "CA",
                        ZipCode = "90248",
                        Country = "USA",
                        Latitude = 33.899768,
                        Longitude = -118.282965
                    }},
                        {8, new AddressData {
                        Street1 =  "676-698 W 5th St",
                        Street2 = "Some County",
                        City = "San Pedro",
                        State = "CA",
                        ZipCode = "90731",
                        Country = "USA",
                        Latitude = 33.739680,
                        Longitude = -118.291956
                    }},
                    { 9, new AddressData {
                        Street1 =  "E Howard Ln",
                        Street2 = "Some County",
                        City = "Austin",
                        State = "TX",
                        ZipCode = "78753",
                        Country = "USA",
                        Latitude = 30.408442,
                        Longitude = -97.646316
                    }}
                }
            };
        }
    }
}
