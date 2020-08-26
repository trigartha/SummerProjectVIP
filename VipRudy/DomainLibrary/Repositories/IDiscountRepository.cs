using DomainLibrary.Models;
using System;
using System.Collections.Generic;

namespace DomainLibrary.Repositories
{
    public interface IDiscountRepository
    {
        void AddDiscount(Discount discount);
        void DeleteAll();
        Discount Find(int id);
        Discount FindOnCategory(string category);
        IEnumerable<Discount> FindAll();
        void Save();
    }
}
