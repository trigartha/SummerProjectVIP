using DomainLibrary.Enums;
using DomainLibrary.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainLibrary.Models
{
    public class ReservationInfo : Notifier
    {
        #region Fields
        private int _reservationInfoId;
        private Location _startLocation;
        private Location _endLocation;

        private Arrangement _arrangement;
        private DateTime _startTime;
        private DateTime _endTime;
        private int _startHour;
        private int _endHour;
        private DeliveryAddress _address;

        #endregion
        #region Constructor
        public ReservationInfo() { }
        public ReservationInfo (Location start, Location stop,  DateTime startT, Arrangement arrangement, DateTime end, DeliveryAddress address, int startHour, int endHour)
        {
            this.StartLocation = start;
            this.EndLocation = stop;
            this.StartTime = startT;
            this.Arrangement = arrangement;
            this.StartHour = startHour;
            this.EndHour = endHour;
            this.StartTime = new DateTime(startT.Year, startT.Month, startT.Day, StartHour, 0, 0);
            this.EndTime = new DateTime(end.Year, end.Month, end.Day, endHour, 0, 0);
            this.Address =address ;
        }
        public ReservationInfo(Location start, Location stop, DateTime startT, Arrangement arrangement, DateTime end, DeliveryAddress address)
        {
            this.StartLocation = start;
            this.EndLocation = stop;
            this.StartTime = startT;
            this.Arrangement = arrangement;
           
            this.EndTime = startT;
            this.StartTime = end;
            this.Address = address;
        }
        #endregion
        public int StartHour
        {
            get { return _startHour; }
             set
            {
                if (_startHour != value)
                {
                    _startHour = value;
                    RaisePropertyChanged(() => StartHour);
                }
            }
        }
        public int EndHour
        {
            get { return _endHour; }
             set
            {
                if (_endHour != value)
                {
                    _endHour = value;
                    RaisePropertyChanged(() => EndHour);
                }
            }
        }
        public int ReservationInfoId
        {
            get { return _reservationInfoId; }
            private set
            {
                if (_reservationInfoId != value)
                {
                    _reservationInfoId = value;
                    RaisePropertyChanged(() => ReservationInfoId);
                }
            }
        }
        public Location StartLocation
        {
            get { return _startLocation; }
            set
            {
                if (_startLocation != value)
                {
                    _startLocation = value;
                    RaisePropertyChanged(() => StartLocation);
                }
            }
        }
        public Location EndLocation
        {
            get { return _endLocation; }
            set
            {
                if (_endLocation != value)
                {
                    _endLocation = value;
                    RaisePropertyChanged(() => EndLocation);
                }
            }
        }

        public Arrangement Arrangement
        {
            get { return _arrangement; }
            set
            {
                if (_arrangement != value)
                {
                    _arrangement = value;
                    RaisePropertyChanged(() => Arrangement);
                }
            }
        }
        public DateTime StartTime
        {
            get { return _startTime; }
            set
            {
                if (_startTime != value)
                {
                    _startTime = value;
                    RaisePropertyChanged(() => StartTime);
                }
            }
        }
        public DateTime EndTime
        {
            get { return _endTime; }
            set
            {
                if (_endTime != value)
                {
                    _endTime = value;
                    RaisePropertyChanged(() => EndTime);
                }
            }
        }
        public DeliveryAddress Address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value;
                    RaisePropertyChanged(() => Address);
                }
            }
        }
    }
}
