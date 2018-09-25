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
                        Street2 = "",
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
                        Street2 = "",
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
                        Street2 = "",
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
                        Street2 = "",
                        City = "Flushing",
                        State = "NY",
                        ZipCode = "11367",
                        Country = "USA",
                        Latitude = 40.722413,
                        Longitude = -73.818147
                    }},
                    {4, new AddressData {

                        Street1 = "800-898 Lakeview Ave",
                        Street2 = "",
                        City = "Laurel Springs",
                        State = "NJ",
                        ZipCode = "08021",
                        Country = "USA",
                        Latitude = 39.819397,
                        Longitude = -75.008047
                    }}

                }
            };
        }
    }
}
