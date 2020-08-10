﻿using DomainLibrary.Enums;
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

        #endregion
        #region Constructor
        public ReservationInfo() { }
        public ReservationInfo (Location start, Location stop,  DateTime startT, Arrangement arrangement, DateTime end)
        {
            this.StartLocation = start;
            this.EndLocation = stop;
            this.StartTime = startT;
            this.Arrangement = arrangement;
            this.EndTime = end;
        }
        #endregion
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
            private set
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
            private set
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
            private set
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
            private set
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
            private set
            {
                if (_endTime != value)
                {
                    _endTime = value;
                    RaisePropertyChanged(() => EndTime);
                }
            }
        }
    }
}
