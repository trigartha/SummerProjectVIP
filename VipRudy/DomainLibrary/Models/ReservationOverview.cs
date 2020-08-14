using DomainLibrary.Enums;
using DomainLibrary.Framework;
using System;

namespace DomainLibrary.Models
{
    public class ReservationOverview : Notifier
    {
        #region Properties

        private Reservation _reservation;
        private int _totalHoursNormalPrice;
        private int _totalHoursNightPrice;
        private int _totalHoursOverTimePrice;
        private decimal _hourPriceNormalPrice;
        private decimal _hourPriceNightPrice;
        private decimal _hourPriceOverTimePrice;
        private decimal _totalNormal;
        private decimal _totalNight;
        private decimal _totalOverTime;
        private decimal _totalBeforeDiscount;
        private decimal _discount;
        private decimal _totalBeforeTaxAfterDiscount;
        private decimal _tax;
        private decimal _totalToPay;
        #endregion
        #region Fields
        #endregion
        #region Constructor
        public ReservationOverview()
        { }
        #endregion
        #region Methods
        public Reservation Reservation
        {
            get { return _reservation; }
             set
            {
                if (_reservation != value)
                {
                    _reservation = value;
                    RaisePropertyChanged(() => Reservation);
                }
            }
        }
        public int TotalHoursNormalPrice
        {
            get { return _totalHoursNormalPrice; }
             set
            {
                if (_totalHoursNormalPrice != value)
                {
                    _totalHoursNormalPrice = value;
                    RaisePropertyChanged(() => TotalHoursNormalPrice);
                }
            }
        }
        public int TotalHoursNightPrice
        {
            get { return _totalHoursNightPrice; }
             set
            {
                if (_totalHoursNightPrice != value)
                {
                    _totalHoursNightPrice = value;
                    RaisePropertyChanged(() => TotalHoursNightPrice);
                }
            }
        }
        public int TotalHoursOverTimePrice
        {
            get { return _totalHoursOverTimePrice; }
             set
            {
                if (_totalHoursOverTimePrice != value)
                {
                    _totalHoursOverTimePrice = value;
                    RaisePropertyChanged(() => TotalHoursOverTimePrice);
                }
            }
        }
        public decimal HourPriceNormalPrice
        {
            get { return _hourPriceNormalPrice; }
             set
            {
                if (_hourPriceNormalPrice != value)
                {
                    _hourPriceNormalPrice = value;
                    RaisePropertyChanged(() => HourPriceNormalPrice);
                }
            }
        }
        public decimal HourPriceNightPrice
        {
            get { return _hourPriceNightPrice; }
             set
            {
                if (_hourPriceNightPrice != value)
                {
                    _hourPriceNightPrice = value;
                    RaisePropertyChanged(() => HourPriceNightPrice);
                }
            }
        }
        public decimal HourPriceOverTimePrice
        {
            get { return _hourPriceOverTimePrice; }
             set
            {
                if (_hourPriceOverTimePrice != value)
                {
                    _hourPriceOverTimePrice = value;
                    RaisePropertyChanged(() => HourPriceOverTimePrice);
                }
            }
        }
        public decimal TotalNormal
        {
            get { return _totalNormal; }
             set
            {
                if (_totalNormal != value)
                {
                    _totalNormal = value;
                    RaisePropertyChanged(() => TotalNormal);
                }
            }
        }
        public decimal TotalNight
        {
            get { return _totalNight; }
             set
            {
                if (_totalNight != value)
                {
                    _totalNight = value;
                    RaisePropertyChanged(() => TotalNight);
                }
            }
        }
        public decimal TotalOverTime
        {
            get { return _totalOverTime; }
             set
            {
                if (_totalOverTime != value)
                {
                    _totalOverTime = value;
                    RaisePropertyChanged(() => TotalOverTime);
                }
            }
        }
        public decimal TotalBeforeDiscount
        {
            get { return _totalBeforeTaxAfterDiscount; }
             set
            {
                if (_totalBeforeTaxAfterDiscount != value)
                {
                    _totalBeforeTaxAfterDiscount = value;
                    RaisePropertyChanged(() => TotalBeforeDiscount);
                }
            }
        }
        public decimal Discount
        {
            get { return _discount; }
             set
            {
                if (_discount != value)
                {
                    _discount = value;
                    RaisePropertyChanged(() => Discount);
                }
            }
        }
        public decimal TotalBeforeTaxAfterDiscount
        {
            get { return _totalBeforeTaxAfterDiscount; }
             set
            {
                if (_totalBeforeTaxAfterDiscount != value)
                {
                    _totalBeforeTaxAfterDiscount = value;
                    RaisePropertyChanged(() => TotalBeforeTaxAfterDiscount);
                }
            }
        }
    
        public decimal Tax
        {
            get { return _tax; }
             set
            {
                if (_tax != value)
                {
                    _tax = value;
                    RaisePropertyChanged(() => Tax);
                }
            }
        }
        public decimal TotalToPay
        {
            get { return _totalToPay; }
             set
            {
                if (_totalToPay != value)
                {
                    _totalToPay = value;
                    RaisePropertyChanged(() => TotalToPay);
                }
            }
        }
        #endregion
    }
}
