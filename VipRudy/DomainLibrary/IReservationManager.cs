using DomainLibrary.Enums;
using DomainLibrary.Models;
using System;

namespace DomainLibrary
{
    public interface IReservationManager
    {
        void AddCar(Car car);
        void AddClient(Client client);
        void AddReservation(Client client, Location start, Location stop, Car car, DateTime startTime, Arrangement arrangement, DateTime endTime);
        void DeleteAllCars();
        void DeleteAllClients();
        void UpdateCarAvailability(Car car, CarAvailability availability);
    }
}