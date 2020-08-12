using DomainLibrary.Enums;
using DomainLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Repositories
{
    public interface ICarRepository
    {
        void AddCar(Car car);
        void DeleteAll();
        Car Find(int id);
        IEnumerable<Car> FindAll();
        IEnumerable<Car> FindAllBrands();
        IEnumerable<Car> FindAllOnArrangement(Arrangement arrangement);
        IEnumerable<Car> FindAllOnBrand(string brand);
        IEnumerable<Car> FindAllOnColour(string colour);
        IEnumerable<Car> FindAllOnModel(string model);
        void Save();
        void UpdateCarAvailability(Car car, CarAvailability availability);
    }
}
