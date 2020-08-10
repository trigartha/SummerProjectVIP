using DomainLibrary.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Models
{
    public class Reservation : Notifier
    {
        #region Fields
        private Client _client { get; set; }
        private Car _car { get; set; }
        private DateTime _reservationDate { get; set; }
        private int _reservationId { get; set; }
        private ReservationInfo _reservationInfo { get; set; }
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

        #endregion
        public Client Client
        {
            get { return _client; }
            private set
            {
                if (_client != value)
                {
                    _client = value;
                    RaisePropertyChanged(() => Client);
                }
            }
        }
        public Car Car
        {
            get { return _car; }
            private set
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
            private set
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
            private set
            {
                if (_reservationId != value)
                {
                    _reservationId = value;
                    RaisePropertyChanged(() => ReservationId);
                }
            }
        }
        public ReservationInfo ReservationInfo
        {
            get { return _reservationInfo; }
            private set
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
