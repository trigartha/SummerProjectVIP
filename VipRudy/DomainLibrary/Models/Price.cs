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
        private decimal? _firstHourPrice;
        private decimal? _nightLifePrice;
        private decimal? _weddingPrice;
        private decimal? _wellnessPrice;
        public decimal TaxRate = 0.06m;
        #endregion
        #region Constructor
        public Price() { }
        public Price(decimal? firstH, decimal? nightL, decimal? wedding, decimal? wellnes)
        {
            this.FirstHourPrice = firstH;
            this.NightLifePrice = nightL;
            this.WeddingPrice = wedding;
            this.WellnessPrice = wellnes;
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
        public decimal? FirstHourPrice
        {
            get { return _firstHourPrice; }
            private set
            {
                if (_firstHourPrice != value)
                {
                    _firstHourPrice = value;
                    RaisePropertyChanged(() => FirstHourPrice);
                }
            }
        }
        public decimal? NightLifePrice
        {
            get { return _nightLifePrice; }
            private set
            {
                if (_nightLifePrice != value)
                {
                    _nightLifePrice = value;
                    RaisePropertyChanged(() => NightLifePrice);
                }
            }
        }
        public decimal? WeddingPrice
        {
            get { return _weddingPrice; }
            private set
            {
                if (_weddingPrice != value)
                {
                    _weddingPrice = value;
                    RaisePropertyChanged(() => WeddingPrice);
                }
            }
        }
        public decimal? WellnessPrice
        {
            get { return _wellnessPrice; }
            private set
            {
                if (_wellnessPrice != value)
                {
                    _wellnessPrice = value;
                    RaisePropertyChanged(() => WellnessPrice);
                }
            }
        }
    }
}
