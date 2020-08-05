using DomainLibrary.Models;
using DomainLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repository
{
    public class CarRepository : ICarRepository
    {
        #region Properties

        #endregion
        #region Fields
        private ReservationContext _context;
        #endregion
        #region Constructor
        public CarRepository(ReservationContext context)
        {
            this._context = context;
        }
        #endregion
        #region Methods
        public void AddCar(Car car)
        {
            _context.Cars.Add(car);
        }
        public Car Find(int id)
        {
            return _context.Cars.Find(id);
        }
        public IEnumerable<Car> FindAll()
        {
            return _context.Cars.OrderBy(c => c.CarId).AsEnumerable<Car>();
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
