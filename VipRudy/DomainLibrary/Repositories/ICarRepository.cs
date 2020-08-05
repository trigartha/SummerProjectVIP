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
        void Save();
    }
}
