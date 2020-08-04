using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Models
{
    public class Price
    {
        #region Properties
        public int PriceId { get; set; }
        public decimal FirstHourPrice { get; set; }
        public decimal NightLifePrice { get; set; }
        public decimal WeddingPrice { get; set; }
        public decimal WellnessPrice { get; set; }
        #endregion
        #region Fields
        public decimal TaxRate = 0.06m;
        #endregion
        #region Constructor
        public Price() { }
        public Price(decimal firstH, decimal nightL, decimal wedding, decimal wellnes)
        {
            this.FirstHourPrice = firstH;
            this.NightLifePrice = nightL;
            this.WeddingPrice = wedding;
            this.WellnessPrice = wellnes;
        }
        #endregion
    }
}
