using DomainLibrary.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainLibrary.Models
{
    public class ReservationInfo
    {
        #region Properties
        public int ReservationInfoId { get; set; }
        public Location StartLocation { get; set; }
        public Location EndLocation { get; set; }

        public Car Car { get; set; }
        public Arrangement Arrangement { get; set; }
        public DateTime StartTime { get; set; }
        public int AmountNormalHours { get; set; }
        public int AmountNightHours { get; set; }
        public int AmountOverTimeHours { get; set; }
        public Discount Discount { get; set; }

        #endregion
        #region Constructor
        public ReservationInfo() { }
        public ReservationInfo (Location start, Location stop, Car car, DateTime dateTime, Arrangement arrangement,int first, int night, int overtime)
        {
            this.StartLocation = start;
            this.EndLocation = stop;
            this.Car = car;
            this.StartTime = dateTime;
            this.Arrangement = Arrangement;
            this.AmountNormalHours = first;
            this.AmountNightHours = night;
            this.AmountOverTimeHours = overtime;
        }
        #endregion
    }
}
