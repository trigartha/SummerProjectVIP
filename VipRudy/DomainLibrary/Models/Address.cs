using DomainLibrary.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary
{
    public class Address : Notifier
    {
        #region Fields
        private int _addresId;
        private string _streetName;
        private string _houseNumber;
        private string _city;
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
       
        public int AddressId
        {
            get { return _addresId; }
            private set
            {
                if (_addresId != value)
                {
                    _addresId = value;
                    RaisePropertyChanged(() => AddressId);
                }
            }
        }
        public string Streetname 
        {
            get { return _streetName; }
            set
            {
                if (_streetName != value)
                {
                    _streetName = value;
                    RaisePropertyChanged(() => Streetname);
                }
            }
        }
        public string HouseNumber
        {
            get { return _houseNumber; }
            set
            {
                if (_houseNumber != value)
                {
                    _houseNumber = value;
                    RaisePropertyChanged(() => HouseNumber);
                }
            }
        }
        public string City
        {
            get { return _city; }
            set
            {
                if (_city != value)
                {
                    _city = value;
                    RaisePropertyChanged(() => City);
                }
            }
        }
    
    }
}
