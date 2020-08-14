using DomainLibrary.Enums;
using DomainLibrary.Models;
using DomainLibrary.Repositories;
using Microsoft.EntityFrameworkCore;
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
            return _context.Cars.Include(c=>c.Price).AsEnumerable<Car>();
        }
        public IEnumerable<Car>FindAllBrands()
        {
            return _context.Cars.GroupBy(c => c.Brand).Select(grp => grp.First()).AsEnumerable<Car>();
        }
        public IEnumerable<Car> FindAllOnArrangement(Arrangement arrangement)
        {

            return _context.Cars.Where(car => car.Price.Any(p => p.Arrangement == arrangement && p.PriceRate != null)).AsEnumerable<Car>();
        }
        public IEnumerable<Car> FindAllOnBrand(string brand)
        {
            return _context.Cars.Where(car => car.Brand == brand).AsEnumerable<Car>();
        }
        public IEnumerable<Car> FindAllOnModel(string model)
        {

            return _context.Cars.Where(car => car.Model == model).AsEnumerable<Car>();
        }
        public IEnumerable<Car> FindAllOnColour(string colour)
        {

            return _context.Cars.Where(car => car.Colour == colour).AsEnumerable<Car>();
        }
        public void UpdateCarAvailability(Car car, CarAvailability availability)
        {
            Car tempoCar = _context.Cars.Find(car.CarId);
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
