using DomainLibrary.Enums;
using DomainLibrary.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DomainLibrary
{
    public class ReservationManager
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
        public void AddReservation(Reservation reservation)
        {
            _uow.Reservations.AddReservation(reservation);
            _uow.Complete();

        }
        public Reservation CreateReservation(Client client, Location start, Location stop, Car car, DateTime startTime, Arrangement arrangement, DateTime endTime, DeliveryAddress address)
        {
            if (_uow.Clients.Find(client.ClientNumber) == null) throw new DomainException("Client doesn't exist");
            //if (car.Availability != CarAvailability.Available) throw new DomainException("Car is not available");
            if (startTime < DateTime.Now) throw new DomainException("StartTime is in the past");
            if (arrangement == Arrangement.Wedding) if (!ControlStartTimeWedding(startTime)) throw new DomainException("Wedding Arrangement doesn't allow this startime");
            if (arrangement == Arrangement.Wellness) if (!ControlStartTimeWellness(startTime)) throw new DomainException("Wellness Arrangement doesn't allow this startime");
            if (arrangement == Arrangement.NightLife) if (!ControlStartTimeNightLife(startTime)) throw new DomainException("NightLife Arrangement doesn't allow this startime");
            if (arrangement == Arrangement.Wellness) if ((endTime.Hour - startTime.Hour) > 10) throw new DomainException("Wellness Arrangement doens't allow overtime");
            if (arrangement != Arrangement.Wellness) if ((endTime.Hour - startTime.Hour) > 11) throw new DomainException("Reservation exceeds maximum time");
            return new Reservation(_uow.Clients.Find(client.ClientNumber), car, new ReservationInfo(start, stop, startTime, arrangement, endTime, address));

        }
        public ReservationOverview CreateOverview(Reservation reservation)/**/
        {
            ReservationOverview rO = new ReservationOverview();
            rO.Reservation = reservation;
            switch (reservation.ReservationInfo.Arrangement)
            {
                case Arrangement.Airport:
                    rO.TotalHoursNormalPrice = CalculateTotalNormalHours(reservation.ReservationInfo.StartTime, reservation.ReservationInfo.EndTime);
                    rO.TotalHoursNightPrice = CalculateTotalNightHours(reservation.ReservationInfo.StartTime, reservation.ReservationInfo.EndTime);
                    var normalAirportprice = (decimal)reservation.Car.Price.Where(p => p.Arrangement == Arrangement.Airport).Select(p => p.PriceRate).FirstOrDefault();
                    rO.HourPriceNormalPrice = normalAirportprice;
                    rO.TotalNormal = CalculateTotalNormalAmount(rO.TotalHoursNormalPrice, rO.HourPriceNormalPrice);
                    rO.HourPriceNightPrice = Math.Round(((rO.HourPriceNormalPrice * 1.4m) / 5) ,0) * 5; 
                    rO.TotalNight = CalculateTotalNightAmount(rO.TotalHoursNightPrice, rO.HourPriceNormalPrice);
                    rO.TotalOverTime = 0;
                    break;
                case Arrangement.Business:
                    rO.TotalHoursNormalPrice = CalculateTotalNormalHours(reservation.ReservationInfo.StartTime, reservation.ReservationInfo.EndTime);
                    rO.TotalHoursNightPrice = CalculateTotalNightHours(reservation.ReservationInfo.StartTime, reservation.ReservationInfo.EndTime);
                    var normalBussinessprice = (decimal)reservation.Car.Price.Where(p => p.Arrangement == Arrangement.Business).Select(p => p.PriceRate).FirstOrDefault();
                    rO.HourPriceNormalPrice = normalBussinessprice;
                    rO.HourPriceNightPrice = Math.Round(((rO.HourPriceNormalPrice * 1.4m) / 5), 0) * 5;
                    rO.TotalNormal = Math.Round(CalculateTotalNormalAmount(rO.TotalHoursNormalPrice, rO.HourPriceNormalPrice), 0);
                    rO.TotalNight = CalculateTotalNightAmount(rO.TotalHoursNightPrice, rO.HourPriceNormalPrice);
                    rO.TotalOverTime = 0;
                    break;
                case Arrangement.Wedding:
                    rO.TotalHoursNormalPrice = 7;
                    rO.TotalHoursOverTimePrice = CalculateTotalOverTimeHours(reservation.ReservationInfo.StartTime, reservation.ReservationInfo.EndTime);
                    var normalWeddingprice = (decimal)reservation.Car.Price.Where(p => p.Arrangement == Arrangement.Wedding).Select(p => p.PriceRate).FirstOrDefault();
                    rO.HourPriceNormalPrice = normalWeddingprice;
                    rO.TotalNormal = rO.HourPriceNormalPrice;
                    var baseOvertimeWeddingprice = (decimal)reservation.Car.Price.Where(p => p.Arrangement == Arrangement.Airport).Select(p => p.PriceRate).FirstOrDefault();
                    rO.HourPriceOverTimePrice = Math.Round(((baseOvertimeWeddingprice * 0.65m) / 5), 0) * 5;
                    rO.TotalOverTime = Math.Round(CalculateTotalOverTimeAmount(rO.TotalHoursOverTimePrice, baseOvertimeWeddingprice),0);
                    rO.TotalNight = CalculateTotalNightAmount(CalculateTotalNightHours(reservation.ReservationInfo.StartTime, reservation.ReservationInfo.EndTime), baseOvertimeWeddingprice);
                   
                    break;
                case Arrangement.NightLife:
                    rO.TotalHoursNormalPrice = 7;
                    rO.TotalHoursOverTimePrice = CalculateTotalOverTimeHours(reservation.ReservationInfo.StartTime, reservation.ReservationInfo.EndTime);
                    rO.TotalHoursNightPrice = rO.TotalHoursOverTimePrice;
                    var normalNightLifeprice = (decimal)reservation.Car.Price.Where(p => p.Arrangement == Arrangement.NightLife).Select(p => p.PriceRate).FirstOrDefault();
                    rO.HourPriceNormalPrice = (decimal)reservation.Car.Price.Where(p => p.Arrangement == Arrangement.Airport).Select(p => p.PriceRate).FirstOrDefault();
                    rO.TotalNormal = normalNightLifeprice;
                    rO.HourPriceOverTimePrice = Math.Round(((rO.HourPriceNormalPrice * 1.4m) / 5), 0) * 5;
                    rO.TotalOverTime = Math.Round(CalculateTotalNightAmount(rO.TotalHoursNightPrice, rO.HourPriceNormalPrice),0);
                    
                    break;
                case Arrangement.Wellness:
                    rO.TotalHoursNormalPrice = 10;
                    var normalWellnessprice = (decimal)reservation.Car.Price.Where(p => p.Arrangement == Arrangement.Wellness).Select(p => p.PriceRate).FirstOrDefault();
                    rO.HourPriceNormalPrice = normalWellnessprice;
                    rO.TotalNormal = Math.Round(rO.HourPriceNormalPrice,0);
                    rO.TotalOverTime = 0;
                    rO.TotalNight = 0;
                    break;
            }
            rO.TotalBeforeDiscount = rO.TotalNormal + rO.TotalNight + rO.TotalOverTime;
            rO.Discount = CalculateDiscount(reservation.Client);
            rO.TotalBeforeTaxAfterDiscount = Math.Round((rO.TotalBeforeTaxAfterDiscount - rO.Discount),0);
            rO.Tax = Math.Round(rO.TotalBeforeTaxAfterDiscount * 0.06m,0);
            rO.TotalToPay = Math.Round(rO.TotalBeforeTaxAfterDiscount + rO.Tax,0);
            return rO;
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
        public IEnumerable<Reservation> FindAllReservations()
        {
            return _uow.Reservations.FindAll();
        }
        public IEnumerable<Reservation> FindAllReservationsOnClient(Client client)
        {
            return _uow.Reservations.FindOnClient(client);
        }
        public IEnumerable<Reservation> FindAllReservationsOnDate(DateTime date)
        {
            return _uow.Reservations.FindOnDate(date);
        }
        public IEnumerable<Reservation> FindAllReservationsOnDateAndClient(DateTime date, Client client)
        {
            return _uow.Reservations.FindOnDateAndClient(date, client);
        }
        public IEnumerable<Car> FindAllCars()
        {
            return _uow.Cars.FindAll();
        }
        public IEnumerable<Client> FindAllClients()
        {
            return _uow.Clients.FindAll();
        }
        public IEnumerable<Car> FindAllBrands()
        {
            return _uow.Cars.FindAllBrands();
        }
        public IEnumerable<Car> FindAllCarsOnArrangement(Arrangement arrangement)
        {
            return _uow.Cars.FindAllOnArrangement(arrangement);
        }
        public IEnumerable<Car> FindAllOnBrand(string brand)
        {
            return _uow.Cars.FindAllOnBrand(brand);
        }
        public IEnumerable<Car> FindAllOnColour(string colour)
        {
            return _uow.Cars.FindAllOnColour(colour);
        }
        IEnumerable<Car> FindAllOnModel(string model)
        {
            return _uow.Cars.FindAllOnModel(model);
        }

        private decimal CalculateDiscount(Client client)
        {
            //TODO Figure out what the base is for discountcategory if not clientcategory 
            decimal total = 0m;
            return total;
        }
        private decimal CalculateTotalBeforeDiscount(decimal normal, decimal night, decimal overtime)
        {
            decimal total = normal + night + overtime;
            return total;
        }
        private decimal CalculateTotalNormalAmount(int totalHours, decimal price)
        {
            decimal total = 0m;
            if (totalHours > 0) { total = price + ((totalHours - 1) * (Math.Round((price * 0.65m) / 5) * 5)); }
           
            return total;
        }
        private decimal CalculateTotalNightAmount(int totalHours, decimal price)
        {
            decimal total = 0m;
            if (totalHours > 0)
            {
                total = totalHours * Math.Round((price * 1.4m), 5);
            }
            return total;
        }
        private decimal CalculateTotalOverTimeAmount(int totalHours, decimal price)
        {
            decimal total = totalHours * Math.Round((price * 0.65m), 5);
            return total;
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
            if (endTime.Hour > 22 )
                total += endTime.Hour - 22;
            if(endTime.Hour == 0)
                total += 24 - 22;
            if (startTime.Hour < 7)
                total += 7 - startTime.Hour;
            return total;
        }
        private int CalculateTotalOverTimeHours(DateTime startTime, DateTime endTime)
        {
            int total = 0;
            if (endTime.Hour == 0 || endTime.Hour == 23) total = 22 - startTime.Hour - 7;
            else total =  endTime.Hour - startTime.Hour - 7;

            return total;
        }
        private bool ControlStartTimeWedding(DateTime time)
        {
            int start = 7;
            int end = 15;
            int real = time.Hour;
            if (start <= real && real <= end) return true;
            return false;
        }
        private bool ControlStartTimeWellness(DateTime time)
        {
            int start = 7;
            int end = 12;
            int real = time.Hour;
            if (start <= real && real <= end) return true;
            return false;
        }
        private bool ControlStartTimeNightLife(DateTime time)
        {
            int start = 20;
            int end = 24;
            int midnight = 0;
            int real = time.Hour;
            if(real == midnight) return true;
            else if (start <= real && real <= end) return true;
            return false;
        }
        #endregion
    }
}
