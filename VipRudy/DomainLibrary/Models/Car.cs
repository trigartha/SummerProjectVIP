using DomainLibrary.Enums;
using DomainLibrary.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Models
{
    public class Car : Notifier
    {
        #region Fields
        private string _brand;
        private string _model;
        private string _colour;
        private int _carId;
        private Price _price;
        private CarAvailability _availability;
        private ICollection<Reservation> _reservationDetails;
        #endregion
        #region Constructor
        public Car() { }
        public Car(string brand, string model, string colour, Price price)
        {
            this.Brand = brand;
            this.Model = model;
            this.Colour = colour;
            this.Price = price;
        }
        #endregion
        public string Brand
        {
            get { return _brand; }
            private set
            {
                if (_brand != value)
                {
                    _brand = value;
                    RaisePropertyChanged(() => Brand);
                }
            }
        }
        public string Model
        {
            get { return _model; }
            private set
            {
                if (_model != value)
                {
                    _model = value;
                    RaisePropertyChanged(() => Model);
                }
            }
        }
        public string Colour
        {
            get { return _colour; }
            private set
            {
                if (_colour != value)
                {
                    _colour = value;
                    RaisePropertyChanged(() => Colour);
                }
            }
        }
        public int CarId
        {
            get { return _carId; }
            private set
            {
                if (_carId != value)
                {
                    _carId = value;
                    RaisePropertyChanged(() => CarId);
                }
            }
        }
        public Price Price
        {
            get { return _price; }
            private set
            {
                if (_price != value)
                {
                    _price = value;
                    RaisePropertyChanged(() => Price);
                }
            }
        }
        public CarAvailability Availability
        {
            get { return _availability; }
            private set
            {
                if (_availability != value)
                {
                    _availability = value;
                    RaisePropertyChanged(() => Availability);
                }
            }
        }
        public ICollection<Reservation> ReservationDetails
        {
            get { return _reservationDetails; }
            private set
            {
                if (_reservationDetails != value)
                {
                    _reservationDetails = value;
                    RaisePropertyChanged(() => ReservationDetails);
                }
            }
        }
    }
}
