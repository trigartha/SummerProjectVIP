using DomainLibrary.Enums;
using System;

namespace DomainLibrary.Models
{
    public class ReservationOverview
    {
        #region Properties
        
        public Reservation Reservation { get; set; }
        public int TotalHoursNormalPrice { get; set; }
        public int TotalHoursNightPrice { get; set; }
        public int TotalHoursOverTimePrice { get; set; }
        public decimal HourPriceNormalPrice { get; set; }
        public decimal HourPriceNightPrice { get; set; }
        public decimal HourPriceOverTimePrice { get; set; }
        public decimal TotalNormal { get; set; }
        public decimal TotalNight { get; set; }
        public decimal TotalOverTime { get; set; }
        public decimal TotalBeforeDiscount { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalBeforeTaxAfterDiscount { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalToPay { get; set; }
        #endregion
        #region Fields
        #endregion
        #region Constructor

        #endregion
        #region Methods

        #endregion
    }
}
