using DomainLibrary.Enums;
using DomainLibrary.Framework;
using DomainLibrary.Models;
using System;

namespace DomainLibrary.ViewModels
{
    public class OverViewReservationViewModel : VipRudyViewModelBase
    {
        #region Properties

        #endregion
        #region Fields
        private ReservationOverview _currentReservation;

        
        #endregion
        #region Constructor
        public OverViewReservationViewModel(ReservationOverview reservation)
        {
            this._currentReservation = reservation;
        }
        #endregion
        #region Methods
        public ReservationOverview CurrentReservation
        {
            get
            {
                return _currentReservation;
            }
            set
            {
                if (_currentReservation != value)
                {
                    _currentReservation = value;
                    RaisePropertyChanged(() => CurrentReservation);
                }
            }
            #endregion
        }
        public string Name
        {
            get
            {
                return _currentReservation.Reservation.Client.Name;
            }
            set
            {
                if (_currentReservation.Reservation.Client.Name != value)
                {
                    _currentReservation.Reservation.Client.Name = value;
                    RaisePropertyChanged(() => Name);
                }
            }
        }
        public int ClientId
        {
            get
            {
                return _currentReservation.Reservation.Client.ClientNumber;
            }
            set
            {
                if (_currentReservation.Reservation.Client.ClientNumber != value)
                {
                    _currentReservation.Reservation.Client.ClientNumber = value;
                    RaisePropertyChanged(() => ClientId);
                }
            }
        }
        public string Streetname
        {
            get
            {
                return _currentReservation.Reservation.Client.Address.Streetname;
            }
            set
            {
                if (_currentReservation.Reservation.Client.Address.Streetname != value)
                {
                    _currentReservation.Reservation.Client.Address.Streetname = value;
                    RaisePropertyChanged(() => Streetname);
                }
            }
        }
        public string HouseNumber
        {
            get
            {
                return _currentReservation.Reservation.Client.Address.HouseNumber;
            }
            set
            {
                if (_currentReservation.Reservation.Client.Address.HouseNumber != value)
                {
                    _currentReservation.Reservation.Client.Address.HouseNumber = value;
                    RaisePropertyChanged(() => HouseNumber);
                }
            }
        }
        public string City
        {
            get
            {
                return _currentReservation.Reservation.Client.Address.City;
            }
            set
            {
                if (_currentReservation.Reservation.Client.Address.City != value)
                {
                    _currentReservation.Reservation.Client.Address.City = value;
                    RaisePropertyChanged(() => City);
                }
            }
        }
        public string TaxNumber
        {
            get
            {
                return _currentReservation.Reservation.Client.TaxNumber;
            }
            set
            {
                if (_currentReservation.Reservation.Client.TaxNumber != value)
                {
                    _currentReservation.Reservation.Client.TaxNumber = value;
                    RaisePropertyChanged(() => TaxNumber);
                }
            }
        }
        public int Id
        {
            get
            {
                return _currentReservation.Reservation.ReservationId;
            }
            set
            {
                if (_currentReservation.Reservation.ReservationId != value)
                {
                    _currentReservation.Reservation.ReservationId = value;
                    RaisePropertyChanged(() => Id);
                }
            }
        }
        public DateTime ReservationDate
        {
            get
            {
                return _currentReservation.Reservation.ReservationDate;
            }
            set
            {
                if (_currentReservation.Reservation.ReservationDate != value)
                {
                    _currentReservation.Reservation.ReservationDate = value;
                    RaisePropertyChanged(() => ReservationDate);
                }
            }
        }
        public string StreetnameR
        {
            get
            {
                return _currentReservation.Reservation.ReservationInfo.Address.Streetname;
            }
            set
            {
                if (_currentReservation.Reservation.Client.Address.Streetname != value)
                {
                    _currentReservation.Reservation.Client.Address.Streetname = value;
                    RaisePropertyChanged(() => StreetnameR);
                }
            }
        }
        public string HouseNumberR
        {
            get
            {
                return _currentReservation.Reservation.ReservationInfo.Address.HouseNumber;
            }
            set
            {
                if (_currentReservation.Reservation.ReservationInfo.Address.HouseNumber != value)
                {
                    _currentReservation.Reservation.ReservationInfo.Address.HouseNumber = value;
                    RaisePropertyChanged(() => HouseNumberR);
                }
            }
        }
        public string CityR
        {
            get
            {
                return _currentReservation.Reservation.ReservationInfo.Address.City;
            }
            set
            {
                if (_currentReservation.Reservation.ReservationInfo.Address.City != value)
                {
                    _currentReservation.Reservation.ReservationInfo.Address.City = value;
                    RaisePropertyChanged(() => CityR);
                }
            }
        }
        public Location StartLocation
        {
            get
            {
                return _currentReservation.Reservation.ReservationInfo.StartLocation;
            }
            set
            {
                if (_currentReservation.Reservation.ReservationInfo.StartLocation != value)
                {
                    _currentReservation.Reservation.ReservationInfo.StartLocation = value;
                    RaisePropertyChanged(() => StartLocation);
                }
            }
        }
        public Location EndLocation
        {
            get
            {
                return _currentReservation.Reservation.ReservationInfo.EndLocation;
            }
            set
            {
                if (_currentReservation.Reservation.ReservationInfo.EndLocation != value)
                {
                    _currentReservation.Reservation.ReservationInfo.EndLocation = value;
                    RaisePropertyChanged(() => EndLocation);
                }
            }
        }
        public int CarId
        {
            get
            {
                return _currentReservation.Reservation.Car.CarId;
            }
            set
            {
                if (_currentReservation.Reservation.Car.CarId != value)
                {
                    _currentReservation.Reservation.Car.CarId = value;
                    RaisePropertyChanged(() => CarId);
                }
            }
        }
        public string Brand
        {
            get
            {
                return _currentReservation.Reservation.Car.Brand;
            }
            set
            {
                if (_currentReservation.Reservation.Car.Brand != value)
                {
                    _currentReservation.Reservation.Car.Brand = value;
                    RaisePropertyChanged(() => Brand);
                }
            }
        }
        public string Model
        {
            get
            {
                return _currentReservation.Reservation.Car.Model;
            }
            set
            {
                if (_currentReservation.Reservation.Car.Model != value)
                {
                    _currentReservation.Reservation.Car.Model = value;
                    RaisePropertyChanged(() => Model);
                }
            }
        }
        public string Colour
        {
            get
            {
                return _currentReservation.Reservation.Car.Colour;
            }
            set
            {
                if (_currentReservation.Reservation.Car.Colour != value)
                {
                    _currentReservation.Reservation.Car.Colour = value;
                    RaisePropertyChanged(() => Colour);
                }
            }
        }
        public Arrangement Arrangement
        {
            get
            {
                return _currentReservation.Reservation.ReservationInfo.Arrangement;
            }
            set
            {
                if (_currentReservation.Reservation.ReservationInfo.Arrangement != value)
                {
                    _currentReservation.Reservation.ReservationInfo.Arrangement = value;
                    RaisePropertyChanged(() => Arrangement);
                }
            }
        }
        public DateTime StartTime
        {
            get
            {
                return _currentReservation.Reservation.ReservationInfo.StartTime;
            }
            set
            {
                if (_currentReservation.Reservation.ReservationInfo.StartTime != value)
                {
                    _currentReservation.Reservation.ReservationInfo.StartTime = value;
                    RaisePropertyChanged(() => StartTime);
                }
            }
        }
        public DateTime EndTime
        {
            get
            {
                return _currentReservation.Reservation.ReservationInfo.EndTime;
            }
            set
            {
                if (_currentReservation.Reservation.ReservationInfo.EndTime != value)
                {
                    _currentReservation.Reservation.ReservationInfo.EndTime = value;
                    RaisePropertyChanged(() => EndTime);
                }
            }
        }
        public decimal HourPriceNormalPrice
        {
            get
            {
                return _currentReservation.HourPriceNormalPrice;
            }
            set
            {
                if (_currentReservation.HourPriceNormalPrice != value)
                {
                    _currentReservation.HourPriceNormalPrice = value;
                    RaisePropertyChanged(() => HourPriceNormalPrice);
                }
            }
        }
        public decimal HourPriceNightPrice
        {
            get
            {
                return _currentReservation.HourPriceNightPrice;
            }
            set
            {
                if (_currentReservation.HourPriceNightPrice != value)
                {
                    _currentReservation.HourPriceNightPrice = value;
                    RaisePropertyChanged(() => HourPriceNightPrice);
                }
            }
        }
        public decimal HourPriceOverTimePrice
        {
            get
            {
                return _currentReservation.HourPriceOverTimePrice;
            }
            set
            {
                if (_currentReservation.HourPriceOverTimePrice != value)
                {
                    _currentReservation.HourPriceOverTimePrice = value;
                    RaisePropertyChanged(() => HourPriceOverTimePrice);
                }
            }
        }
        public int TotalHoursNormalPrice
        {
            get
            {
                return _currentReservation.TotalHoursNormalPrice;
            }
            set
            {
                if (_currentReservation.TotalHoursNormalPrice != value)
                {
                    _currentReservation.TotalHoursNormalPrice = value;
                    RaisePropertyChanged(() => TotalHoursNormalPrice);
                }
            }
        }
        public int TotalHoursNightPrice
        {
            get
            {
                return _currentReservation.TotalHoursNightPrice;
            }
            set
            {
                if (_currentReservation.TotalHoursNightPrice != value)
                {
                    _currentReservation.TotalHoursNightPrice = value;
                    RaisePropertyChanged(() => TotalHoursNightPrice);
                }
            }
        }
        public int TotalHoursOverTimePrice
        {
            get
            {
                return _currentReservation.TotalHoursOverTimePrice;
            }
            set
            {
                if (_currentReservation.TotalHoursOverTimePrice != value)
                {
                    _currentReservation.TotalHoursOverTimePrice = value;
                    RaisePropertyChanged(() => TotalHoursOverTimePrice);
                }
            }
        }
        public decimal TotalNormal
        {
            get
            {
                return _currentReservation.TotalNormal;
            }
            set
            {
                if (_currentReservation.TotalNormal != value)
                {
                    _currentReservation.TotalNormal = value;
                    RaisePropertyChanged(() => TotalNormal);
                }
            }
        }
        public decimal TotalNight
        {
            get
            {
                return _currentReservation.TotalNight;
            }
            set
            {
                if (_currentReservation.TotalNight != value)
                {
                    _currentReservation.TotalNight = value;
                    RaisePropertyChanged(() => TotalNight);
                }
            }
        }
        public decimal TotalOverTime
        {
            get
            {
                return _currentReservation.TotalOverTime;
            }
            set
            {
                if (_currentReservation.TotalOverTime != value)
                {
                    _currentReservation.TotalOverTime = value;
                    RaisePropertyChanged(() => TotalOverTime);
                }
            }
        }
        public decimal TotalBeforeDiscount
        {
            get
            {
                return _currentReservation.TotalBeforeDiscount;
            }
            set
            {
                if (_currentReservation.TotalBeforeDiscount != value)
                {
                    _currentReservation.TotalBeforeDiscount = value;
                    RaisePropertyChanged(() => TotalBeforeDiscount);
                }
            }
        }
        public decimal Discount
        {
            get
            {
                return _currentReservation.Discount;
            }
            set
            {
                if (_currentReservation.Discount != value)
                {
                    _currentReservation.Discount = value;
                    RaisePropertyChanged(() => Discount);
                }
            }
        }
        public decimal TotalBeforeTaxAfterDiscount
        {
            get
            {
                return _currentReservation.TotalBeforeTaxAfterDiscount;
            }
            set
            {
                if (_currentReservation.TotalBeforeTaxAfterDiscount != value)
                {
                    _currentReservation.TotalBeforeTaxAfterDiscount = value;
                    RaisePropertyChanged(() => TotalBeforeTaxAfterDiscount);
                }
            }
        }
        public decimal Tax
        {
            get
            {
                return _currentReservation.Tax;
            }
            set
            {
                if (_currentReservation.Tax != value)
                {
                    _currentReservation.Tax = value;
                    RaisePropertyChanged(() => Tax);
                }
            }
        }
        public decimal TotalToPay
        {
            get
            {
                return _currentReservation.TotalToPay;
            }
            set
            {
                if (_currentReservation.TotalToPay != value)
                {
                    _currentReservation.TotalToPay = value;
                    RaisePropertyChanged(() => TotalToPay);
                }
            }
        }

    }
}
