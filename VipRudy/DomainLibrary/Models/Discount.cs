using DomainLibrary.Enums;
using DomainLibrary.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainLibrary.Models
{
    public class Discount : Notifier
    {
        #region Properties
        private int _discountId;
        private string _discountCategory;
        private List<Staffel> _staffelKorting;

        #endregion
        #region Constructor
        public Discount() { }
        #endregion
        public int DiscountId
        {
            get { return _discountId; }
            private set
            {
                if (_discountId != value)
                {
                    _discountId = value;
                    RaisePropertyChanged(() => DiscountId);
                }
            }
        }
        public string DiscountCategory
        {
            get { return _discountCategory; }
            private set
            {
                if (_discountCategory != value)
                {
                    _discountCategory = value;
                    RaisePropertyChanged(() => DiscountCategory);
                }
            }
        }
        public List<Staffel> StaffelKorting
        {
            get { return _staffelKorting; }
            private set
            {
                if (_staffelKorting != value)
                {
                    _staffelKorting = value;
                    RaisePropertyChanged(() => StaffelKorting);
                }
            }
        }
    }
}
