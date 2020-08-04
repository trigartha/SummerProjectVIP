using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary
{
    public class Address
    {
        #region Properties
        public int AddressId { get; set; }
        public string Streetname { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        #endregion
        #region Constructor
        public Address() { }
        public Address(string street, string number, string city)
        {
            this.Streetname = street;
            this.HouseNumber = number;
            this.City = city;
        }
        #endregion
    }
}
