using DomainLibrary.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainLibrary.Models
{
    public class Reservation : Notifier
    {
        #region Fields
        private Client _client;
        private Car _car;
        private DateTime _reservationDate;
        private int _reservationId;
        private ReservationInfo _reservationInfo;
        #endregion
        #region Constructor
        public Reservation() { }
        public Reservation(Client client, Car car, ReservationInfo reservationInfo)
        {
            this.Client = client;
            this.Car = car;
            this.ReservationDate = DateTime.Now;
            this.ReservationInfo = reservationInfo;
        }
        public Reservation(Client client, Car car,DateTime date, ReservationInfo reservationInfo)
        {
            this.Client = client;
            this.Car = car;
            this.ReservationDate = date;
            this.ReservationInfo = reservationInfo;
        }

        #endregion
        [ForeignKey("ClientNumber")]
        public Client Client
        {
            get { return _client; }
            set
            {
                if (_client != value)
                {
                    _client = value;
                    RaisePropertyChanged(() => Client);
                }
            }
        }
        [ForeignKey("CarId")]
        public Car Car
        {
            get { return _car; }
            set
            {
                if (_car != value)
                {
                    _car = value;
                    RaisePropertyChanged(() => Car);
                }
            }
        }
        public DateTime ReservationDate
        {
            get { return _reservationDate; }
            set
            {
                if (_reservationDate != value)
                {
                    _reservationDate = value;
                    RaisePropertyChanged(() => ReservationDate);
                }
            }
        }
        public int ReservationId
        {
            get { return _reservationId; }
            set
            {
                if (_reservationId != value)
                {
                    _reservationId = value;
                    RaisePropertyChanged(() => ReservationId);
                }
            }
        }
        [ForeignKey("ReservationInfoId")]
        public ReservationInfo ReservationInfo
        {
            get { return _reservationInfo; }
            set
            {
                if (_reservationInfo != value)
                {
                    _reservationInfo = value;
                    RaisePropertyChanged(() => ReservationInfo);
                }
            }
        }
    }
}
