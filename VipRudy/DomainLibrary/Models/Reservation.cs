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
        private int _clientId;
        private Car _car;
        private int _carId;
        private DateTime _reservationDate;
        private int _reservationId;
        private ReservationInfo _reservationInfo;
        private int _reservationInfoId;
        private Discount discount;
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
        public Reservation(int client, int car, DateTime date, int reservationInfo)
        {
            this.ClientId = client;
            this.CarId = car;
            this.ReservationDate = date;
            this.ReservationInfoId = reservationInfo;
        }

        #endregion
        [ForeignKey("ClientNumber")]
        public int ClientId
            
        {
            get { return _clientId; }
            set
            {
                if (_clientId != value)
                {
                    _clientId = value;
                    RaisePropertyChanged(() => ClientId);
                }
            }
        }
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
        public int CarId

        {
            get { return _carId; }
            set
            {
                if (_carId != value)
                {
                    _carId = value;
                    RaisePropertyChanged(() => CarId);
                }
            }
        }
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
        public Discount Discount
        {
            get { return discount; }
            set
            {
                if (discount != value)
                {
                    discount = value;
                    RaisePropertyChanged(() => Discount);
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
        public int ReservationInfoId

        {
            get { return _reservationInfoId; }
            set
            {
                if (_reservationInfoId != value)
                {
                    _reservationInfoId = value;
                    RaisePropertyChanged(() => ReservationInfoId);
                }
            }
        }
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
