using DomainLibrary.Models;
using DomainLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repository
{
   

    public class DiscountRepository : IDiscountRepository
    {
        #region Properties

        #endregion
        #region Fields
        private ReservationContext _context;
        #endregion
        #region Constructor
        public DiscountRepository(ReservationContext context)
        {
            this._context = context;
        }
        #endregion
        #region Methods
        public void AddDiscount(Discount discount)
        {
            _context.Discounts.Add(discount);
        }
        public Discount Find(int id)
        {
            return _context.Discounts.Find(id);
        }
        public Discount FindOnCategory(string category)
        {
            return _context.Discounts.Where(d=>d.DiscountCategory == category).SingleOrDefault();
        }
        public IEnumerable<Discount> FindAll()
        {
            return _context.Discounts.AsEnumerable<Discount>();
        }

        public void DeleteAll()
        {
            _context.Cars.RemoveRange(_context.Cars);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        #endregion
    }
}
