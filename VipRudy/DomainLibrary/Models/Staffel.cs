using System;

namespace DomainLibrary.Models
{
    public class Staffel
    {
        #region Properties
        public int Amount { get; set; }
        public int Discount { get; set; }
        public int StaffelId {get;set;}
        #endregion
        #region Fields
        #endregion
        #region Constructor
        public Staffel() { }
        public Staffel(int amount, int discount)
        {
            this.Amount = amount;
            this.Discount = discount;
        }
        #endregion
        #region Methods

        #endregion
    }
}
