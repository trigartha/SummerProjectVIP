using DomainLibrary.Framework;
using System;

namespace DomainLibrary.Models
{
    public class Staffel : Notifier
    {
        #region Properties
        private int _amount;
        private decimal _discount;
        private int _staffelId;
        #endregion
        #region Fields
        #endregion
        #region Constructor
        public Staffel() { }
        public Staffel(int amount, decimal discount)
        {
            this.Amount = amount;
            this.Discount = discount;
        }
        #endregion
        #region Methods

        #endregion
        public int Amount
        {
            get { return _amount; }
            private set
            {
                if (_amount != value)
                {
                    _amount = value;
                    RaisePropertyChanged(() => Amount);
                }
            }
        }
        public decimal Discount
        {
            get { return _discount; }
            private set
            {
                if (_discount != value)
                {
                    _discount = value;
                    RaisePropertyChanged(() => Discount);
                }
            }
        }
        public int StaffelId
        {
            get { return _staffelId; }
            private set
            {
                if (_staffelId != value)
                {
                    _staffelId = value;
                    RaisePropertyChanged(() => StaffelId);
                }
            }
        }
    }
}
