using DomainLibrary.Enums;
using DomainLibrary.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Models
{
    public class Price : Notifier
    {
        #region Fields
        private int _priceId;
       
        public decimal TaxRate = 0.06m;
        private Arrangement _arrangement;
        private decimal? _priceRate;
        #endregion
        #region Constructor
       public Price() { }
        public Price(Arrangement arrangement, decimal? price)
        {
            this.Arrangement = arrangement;
            this.PriceRate = price;
        }
        #endregion
        public int PriceId
        {
            get { return _priceId; }
            private set
            {
                if (_priceId != value)
                {
                    _priceId = value;
                    RaisePropertyChanged(() => PriceId);
                }
            }
        }
        public decimal? PriceRate
        {
            get { return _priceRate; }
            private set
            {
                if (_priceRate != value)
                {
                    _priceRate = value;
                    RaisePropertyChanged(() => PriceRate);
                }
            }
        }
        public Arrangement Arrangement
        {
            get { return _arrangement; }
            private set
            {
                if (_arrangement != value)
                {
                    _arrangement = value;
                    RaisePropertyChanged(() => Arrangement);
                }
            }
        }
    }
}
