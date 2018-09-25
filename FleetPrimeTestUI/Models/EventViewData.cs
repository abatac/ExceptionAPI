using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetPrimeTestUI.Models
{
    public class EventViewData
    {

        public Dictionary<string, string> RejectReasons;
        public Dictionary<int, AddressData> Addresses;

        public class AddressData
        { 
            public string Street1 { get; set; }
            public string Street2 { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string ZipCode { get; set; }
            public string Country { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }

        
            public override string ToString()
            {
                return string.Format("{0}, {1}, {2}, {3}, {4}", Street1, City, State, ZipCode ,Country);
            }
        }
    }
}
