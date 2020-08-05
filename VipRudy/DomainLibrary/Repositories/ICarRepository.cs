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
        void UpdateCarAvailability(Car car, CarAvailability availability);
        void DeleteAll();
        Car Find(int id);
        IEnumerable<Car> FindAll();
        void Save();
    }
}
