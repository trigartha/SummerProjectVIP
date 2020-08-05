using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using DomainLibrary.Enums;
using DomainLibrary.Models;
using DataLayer;
using Moq;

namespace DomainLibrary.Tests
{
    [TestClass()]
    public class ReservationManagerTests
    {
        [TestMethod()]
        public void AddReservationTest_ShouldThrowDomainException_WhenClientDoesntExist()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            Car car = new Car("RabbitHole", "Delux", "Brown", new Price());
                DateTime startTime = new DateTime(2100, 12, 12);
            Arrangement arrangement = Arrangement.Airport;
            int first = 4;
            int night = 2;
            int overtime = 0;

            Assert.ThrowsException<DomainException>(() => rm.AddReservation(client, start, stop, car, startTime, arrangement, first, night, overtime));
        }
        [TestMethod()]
        public void AddReservationTest_ShouldThrowDomainException_WhenCarIsNotAvailable()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContext()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            rm.AddClient(client);
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            Car car = new Car("RabbitHole", "Delux", "Brown", new Price());
            rm.UpdateCarAvailability(car, CarAvailability.NotAvailable);
            DateTime startTime = new DateTime(2100, 12, 12);
            Arrangement arrangement = Arrangement.Airport;
            int first = 4;
            int night = 2;
            int overtime = 0;
            Assert.ThrowsException<DomainException>(() => rm.AddReservation(client, start, stop, car, startTime, arrangement, first, night, overtime));
        }
        [TestMethod()]
        public void AddReservationTest_ShouldThrowDomainException_WhenStartTimeIsInTHePast()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContext()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            rm.AddClient(client);
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            Car car = new Car("RabbitHole", "Delux", "Brown", new Price());
            DateTime startTime = new DateTime(2000, 12, 12);
            Arrangement arrangement = Arrangement.Airport;
            int first = 4;
            int night = 2;
            int overtime = 0;
            Assert.ThrowsException<DomainException>(() => rm.AddReservation(client, start, stop, car, startTime, arrangement, first, night, overtime));
        }
        [TestMethod()]
        public void AddReservationTest_ShouldThrowDomainException_WhenTotalTimeExceedsMaxExceptWellness()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContext()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            rm.AddClient(client);
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            Car car = new Car("RabbitHole", "Delux", "Brown", new Price());
            DateTime startTime = new DateTime(2000, 12, 12);
            Arrangement arrangement = Arrangement.Airport;
            int first = 7;
            int night = 2;
            int overtime = 3;
            Assert.ThrowsException<DomainException>(() => rm.AddReservation(client, start, stop, car, startTime, arrangement, first, night, overtime));
        }
        [TestMethod()]
        public void AddReservationTest_ShouldThrowDomainException_WhenTotalTimeExceedsTenForWellness()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContext()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            rm.AddClient(client);
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            Car car = new Car("RabbitHole", "Delux", "Brown", new Price());
            DateTime startTime = new DateTime(2000, 12, 12);
            Arrangement arrangement = Arrangement.Airport;
            int first = 11;
            int night = 0;
            int overtime = 0;
            Assert.ThrowsException<DomainException>(() => rm.AddReservation(client, start, stop, car, startTime, arrangement, first, night, overtime));
        }
        [TestMethod()]
        public void AddReservationTest_ShouldThrowDomainException_WhenNighthoursAreAddedForWellness()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContext()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            rm.AddClient(client);
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            Car car = new Car("RabbitHole", "Delux", "Brown", new Price());
            DateTime startTime = new DateTime(2000, 12, 12);
            Arrangement arrangement = Arrangement.Airport;
            int first = 9;
            int night = 1;
            int overtime = 0;
            Assert.ThrowsException<DomainException>(() => rm.AddReservation(client, start, stop, car, startTime, arrangement, first, night, overtime));
        }
        [TestMethod()]
        public void AddReservationTest_ShouldThrowDomainException_WhenOverTimehoursAreAddedForWellness()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContext()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            rm.AddClient(client);
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            Car car = new Car("RabbitHole", "Delux", "Brown", new Price());
            DateTime startTime = new DateTime(2000, 12, 12);
            Arrangement arrangement = Arrangement.Airport;
            int first = 9;
            int night = 0;
            int overtime = 1;
            Assert.ThrowsException<DomainException>(() => rm.AddReservation(client, start, stop, car, startTime, arrangement, first, night, overtime));
        }
    }
}