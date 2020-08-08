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
            rm.AddCar(car);
            DateTime startTime = new DateTime(2100, 12, 12,12,0,0);
            Arrangement arrangement = Arrangement.Airport;
            DateTime endTime = new DateTime(2100, 12, 12, 15, 0, 0);

            Assert.ThrowsException<DomainException>(() => rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime));
        }
        [TestMethod()]
        public void AddReservationTest_ShouldThrowDomainException_WhenCarIsNotAvailable()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            rm.AddClient(client);
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            Car car = new Car("RabbitHole", "Delux", "Brown", new Price());
            rm.AddCar(car);
            rm.UpdateCarAvailability(car, CarAvailability.NotAvailable);
            DateTime startTime = new DateTime(2100, 12, 12, 12, 0, 0);
            Arrangement arrangement = Arrangement.Airport;
            DateTime endTime = new DateTime(2100, 12, 12, 15, 0, 0);

            Assert.ThrowsException<DomainException>(() => rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime));
        }
        [TestMethod()]
        public void AddReservationTest_ShouldThrowDomainException_WhenStartTimeIsInTHePast()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            rm.AddClient(client);
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            Car car = new Car("RabbitHole", "Delux", "Brown", new Price());
            rm.AddCar(car);
            DateTime startTime = new DateTime(2000, 12, 12, 12, 0, 0);
            Arrangement arrangement = Arrangement.Airport;
            DateTime endTime = new DateTime(2100, 12, 12, 15, 0, 0);

            Assert.ThrowsException<DomainException>(() => rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime));
        }
        [TestMethod()]
        public void AddReservationTest_ShouldThrowDomainException_WhenTotalTimeExceedsMaxExceptWellness()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            rm.AddClient(client);
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            Car car = new Car("RabbitHole", "Delux", "Brown", new Price());
            rm.AddCar(car);
            DateTime startTime = new DateTime(2000, 12, 12, 12, 0, 0);
            Arrangement arrangement = Arrangement.Airport;
            DateTime endTime = new DateTime(2100, 12, 12, 23, 0, 0);

            Assert.ThrowsException<DomainException>(() => rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime));
        }
        [TestMethod()]
        public void AddReservationTest_ShouldThrowDomainException_WhenTotalTimeExceedsTenForWellness()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            rm.AddClient(client);
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            Car car = new Car("RabbitHole", "Delux", "Brown", new Price());
            rm.AddCar(car);
            DateTime startTime = new DateTime(2000, 12, 12, 11, 0, 0);
            Arrangement arrangement = Arrangement.Wellness;
            DateTime endTime = new DateTime(2100, 12, 12, 23, 0, 0);

            Assert.ThrowsException<DomainException>(() => rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime));
        }
      [TestMethod()]
        public void AddReservationTest_ShouldThrowDomainException_WhenStartTimeBeforeArrangementConditionsWedding()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            rm.AddClient(client);
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            Car car = new Car("RabbitHole", "Delux", "Brown", new Price());
            rm.AddCar(car);
            DateTime startTime = new DateTime(2000, 12, 12, 5, 0, 0);
            Arrangement arrangement = Arrangement.Wedding;
            DateTime endTime = new DateTime(2100, 12, 12, 15, 0, 0);

            Assert.ThrowsException<DomainException>(() => rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime));
        }
        [TestMethod()]
        public void AddReservationTest_ShouldThrowDomainException_WhenStartTimeAfterArrangementConditionsWedding()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            rm.AddClient(client);
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            Car car = new Car("RabbitHole", "Delux", "Brown", new Price());
            rm.AddCar(car);
            DateTime startTime = new DateTime(2000, 12, 12, 17, 0, 0);
            Arrangement arrangement = Arrangement.Wedding;
            DateTime endTime = new DateTime(2100, 12, 12, 15, 0, 0);

            Assert.ThrowsException<DomainException>(() => rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime));
        }
        [TestMethod()]
        public void AddReservationTest_ShouldThrowDomainException_WhenStartTimeBeforeArrangementConditionsWellness()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            rm.AddClient(client);
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            Car car = new Car("RabbitHole", "Delux", "Brown", new Price());
            rm.AddCar(car);
            DateTime startTime = new DateTime(2000, 12, 12, 5, 0, 0);
            Arrangement arrangement = Arrangement.Wellness;
            DateTime endTime = new DateTime(2100, 12, 12, 15, 0, 0);

            Assert.ThrowsException<DomainException>(() => rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime));
        }
        [TestMethod()]
        public void AddReservationTest_ShouldThrowDomainException_WhenStartTimeAfterArrangementConditionsWellness()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            rm.AddClient(client);
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            Car car = new Car("RabbitHole", "Delux", "Brown", new Price());
            rm.AddCar(car);
            DateTime startTime = new DateTime(2000, 12, 12, 17, 0, 0);
            Arrangement arrangement = Arrangement.Wellness;
            DateTime endTime = new DateTime(2100, 12, 12, 15, 0, 0);

            Assert.ThrowsException<DomainException>(() => rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime));
        }
        [TestMethod()]
        public void AddReservationTest_ShouldThrowDomainException_WhenStartTimeBeforeArrangementConditionsNightLife()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            rm.AddClient(client);
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            Car car = new Car("RabbitHole", "Delux", "Brown", new Price());
            rm.AddCar(car);
            DateTime startTime = new DateTime(2000, 12, 12, 17, 0, 0);
            Arrangement arrangement = Arrangement.NightLife;
            DateTime endTime = new DateTime(2100, 12, 12, 15, 0, 0);

            Assert.ThrowsException<DomainException>(() => rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime));
        }
        [TestMethod()]
        public void AddReservationTest_ShouldThrowDomainException_WhenStartTimeAfterArrangementConditionsNightLife()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            rm.AddClient(client);
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            Car car = new Car("RabbitHole", "Delux", "Brown", new Price());
            rm.AddCar(car);
            DateTime startTime = new DateTime(2000, 12, 12, 2, 0, 0);
            Arrangement arrangement = Arrangement.NightLife;
            DateTime endTime = new DateTime(2100, 12, 12, 15, 0, 0);

            Assert.ThrowsException<DomainException>(() => rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime));
        }
    }
}