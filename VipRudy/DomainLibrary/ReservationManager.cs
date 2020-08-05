using DomainLibrary.Enums;
using DomainLibrary.Models;
using System;

namespace DomainLibrary
{
    public class ReservationManager : IReservationManager
    {
        #region Properties

        #endregion
        #region Fields
        private IUnitOfWork _uow;
        #endregion
        #region Constructor
        public ReservationManager(IUnitOfWork uow)
        {
            this._uow = uow;
        }
        #endregion
        #region Methods
        public void AddClient(Client client)
        {
            _uow.Clients.AddClient(client);
            _uow.Complete();
        }
        public void AddCar(Car car)
        {
            _uow.Cars.AddCar(car);
            _uow.Complete();
        }
        public void AddReservation(Client client, Location start, Location stop, Car car, DateTime startTime, Arrangement arrangement, int first, int night, int overtime)
        {
            Client thisC = _uow.Clients.Find(client.ClientNumber);
            if (thisC == null) throw new DomainException("Client doesn't exist");
            if (car.Availability != CarAvailability.Available) throw new DomainException("Car is not available");
            if (startTime < DateTime.Now) throw new DomainException("StartTime is in the past");
            if (arrangement == Arrangement.NightLife || arrangement == Arrangement.Wedding) if (overtime > 4) throw new DomainException("The overtime hours exceed the maximum");
            if (arrangement == Arrangement.Wellness) if (first > 10 || night > 0 || overtime > 0) throw new DomainException("Wellness Arrangement doens't allow overtime");
            if (arrangement != Arrangement.Wellness) if (first + overtime > 11 || first + night > 11 || night + overtime > 11) throw new DomainException("Reservation exceeds maximum time");
            _uow.Reservations.AddReservation(new Reservation(_uow.Clients.Find(client.ClientNumber), new ReservationInfo(start, stop, car, startTime, arrangement, first, night, overtime)));
            _uow.Complete();
            UpdateCarAvailability(car, CarAvailability.NotAvailable);
        }
        public void UpdateCarAvailability(Car car, CarAvailability availability)
        {
            _uow.Cars.UpdateCarAvailability(car, availability);
            _uow.Complete();
        }
        public void DeleteAllClients()
        {
            _uow.Clients.DeleteAll();
            _uow.Complete();
        }
        public void DeleteAllCars()
        {
            _uow.Cars.DeleteAll();
            _uow.Complete();
        }
        #endregion
    }
}
