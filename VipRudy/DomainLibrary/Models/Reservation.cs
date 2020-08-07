using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Models
{
    public class Reservation
    {
        #region Properties
        public Client Client { get; set; }
        public Car Car { get; set; }
        public DateTime ReservationDate { get; set; }
        public int ReservationId { get; set; }
        public ReservationInfo ReservationInfo { get; set; }
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

    }
}
