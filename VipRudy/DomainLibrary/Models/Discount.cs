using DomainLibrary.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainLibrary.Models
{
    public class Discount
    {
        #region Properties
        public int DiscountId { get; set; }
        public ClientCategory ClientCategory { get; set; }
        public List<Staffel> StaffelKorting { get; set; }

        #endregion
        #region Constructor
        public Discount() { }
        #endregion
    }
}
