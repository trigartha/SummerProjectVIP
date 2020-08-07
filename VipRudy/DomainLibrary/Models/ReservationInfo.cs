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

        public Arrangement Arrangement { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

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
    }
}
