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
        public void AddReservation(Client client, Location start, Location stop, Car car, DateTime startTime, Arrangement arrangement, DateTime endTime)
        {

            if (_uow.Clients.Find(client.ClientNumber) == null) throw new DomainException("Client doesn't exist");
            if (car.Availability != CarAvailability.Available) throw new DomainException("Car is not available");
            if (startTime < DateTime.Now) throw new DomainException("StartTime is in the past");
            if (arrangement == Arrangement.Wedding) if (ControlStartTimeWedding(startTime)) throw new DomainException("Wedding Arrangement doesn't allow this startime");
            if (arrangement == Arrangement.Wellness) if (ControlStartTimeWellness(startTime)) throw new DomainException("Wellness Arrangement doesn't allow this startime");
            if (arrangement == Arrangement.NightLife) if (ControlStartTimeNightLife(startTime)) throw new DomainException("NightLife Arrangement doesn't allow this startime");
            if (arrangement == Arrangement.Wellness) if ((endTime.Hour - startTime.Hour) > 10) throw new DomainException("Wellness Arrangement doens't allow overtime");
            if (arrangement != Arrangement.Wellness) if ((endTime.Hour - startTime.Hour) > 11) throw new DomainException("Reservation exceeds maximum time");
            _uow.Reservations.AddReservation(new Reservation(_uow.Clients.Find(client.ClientNumber), car, new ReservationInfo(start, stop, startTime, arrangement, endTime)));
            _uow.Complete();
            UpdateCarAvailability(car, CarAvailability.NotAvailable);
        }
        public ReservationOverview CreateOverview(Reservation reservation)
        {
            ReservationOverview rO = new ReservationOverview();
            rO.Reservation = reservation;
            switch (reservation.ReservationInfo.Arrangement)
            {
                case Arrangement.Airport:
                    rO.TotalHoursNormalPrice = CalculateTotalNormalHours(reservation.ReservationInfo.StartTime, reservation.ReservationInfo.EndTime);
                    rO.TotalHoursNightPrice = CalculateTotalNightHours(reservation.ReservationInfo.StartTime, reservation.ReservationInfo.EndTime);
                    break;
                case Arrangement.Business:
                    rO.TotalHoursNormalPrice = CalculateTotalNormalHours(reservation.ReservationInfo.StartTime, reservation.ReservationInfo.EndTime);
                    rO.TotalHoursNightPrice = CalculateTotalNightHours(reservation.ReservationInfo.StartTime, reservation.ReservationInfo.EndTime);
                    break;
                case Arrangement.Wedding:
                    rO.TotalHoursNormalPrice = 7;
                    
                    break;
                case Arrangement.NightLife:
                    rO.TotalHoursNormalPrice = 7;
                    break;
                case Arrangement.Wellness:
                    rO.TotalHoursNormalPrice = 10;  
                    break;
            }
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
        private int CalculateTotalNormalHours(DateTime startTime, DateTime endTime)
        {
            int total = 0;
            if (startTime.Day == endTime.Day)
            {
                if (endTime.Hour < 22 && startTime.Hour >= 7)
                    total = endTime.Hour - startTime.Hour;
                else if (endTime.Hour > 22) total = endTime.Hour - startTime.Hour - (endTime.Hour - 22);
                else if (startTime.Hour < 7) total = endTime.Hour - startTime.Hour - (7 - startTime.Hour);
            }
            else
            {
                total = 22 - startTime.Hour + endTime.Hour - 7;
            }
            return total;
        }
        private int CalculateTotalNightHours(DateTime startTime, DateTime endTime)
        {
            int total = 0;
            if (endTime.Hour > 22)
                total += endTime.Hour - 22;
            if (startTime.Hour < 7)
                total += startTime.Hour;
            return total;
        }

        private bool ControlStartTimeWedding(DateTime time)
        {
            int start = 7;
            int end = 15;
            int real = time.Hour;
            if (start <= real && real >= end) return true;
            return false;
        }
        private bool ControlStartTimeWellness(DateTime time)
        {
            int start = 7;
            int end = 12;
            int real = time.Hour;
            if (start <= real && real >= end) return true;
            return false;
        }
        private bool ControlStartTimeNightLife(DateTime time)
        {
            int start = 20;
            int end = 24;
            int real = time.Hour;
            if (start <= real && real >= end) return true;
            return false;
        }
        #endregion
    }
}
