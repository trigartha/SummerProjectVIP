using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using DomainLibrary.Enums;
using DomainLibrary.Models;
using DataLayer;
using Moq;
using System.Linq;

namespace DomainLibrary.Tests
{
    [TestClass()]
    public class ReservationManagerTests
    {
        #region CreateReservation
        [TestMethod()]
        public void CreateReservationTest_ShouldThrowDomainException_WhenClientDoesntExist()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            List<Price> prices = new List<Price>();
            prices.Add(new Price(Arrangement.Airport, 100m));
            prices.Add(new Price(Arrangement.Business, 100m));
            prices.Add(new Price(Arrangement.NightLife, 900m));
            prices.Add(new Price(Arrangement.Wedding, 800m));
            prices.Add(new Price(Arrangement.Wellness, 750m));
            Car car = new Car("RabbitHole", "Delux", "Brown", prices);
            DeliveryAddress address = new DeliveryAddress("Teaparty", "1", "Wonderland");
            rm.AddCar(car);
            DateTime startTime = new DateTime(2100, 12, 12, 12, 0, 0);
            Arrangement arrangement = Arrangement.Airport;
            DateTime endTime = new DateTime(2100, 12, 12, 15, 0, 0);

            Assert.ThrowsException<DomainException>(() => rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));
        }
        [TestMethod()]
        public void CreateReservationTest_ShouldThrowDomainException_WhenCarIsNotAvailable()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            rm.AddClient(client);
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            List<Price> prices = new List<Price>();
            prices.Add(new Price(Arrangement.Airport, 100m));
            prices.Add(new Price(Arrangement.Business, 100m));
            prices.Add(new Price(Arrangement.NightLife, 900m));
            prices.Add(new Price(Arrangement.Wedding, 800m));
            prices.Add(new Price(Arrangement.Wellness, 750m));
            Car car = new Car("RabbitHole", "Delux", "Brown", prices);
            DeliveryAddress address = new DeliveryAddress("Teaparty", "1", "Wonderland");
            rm.AddCar(car);
            rm.UpdateCarAvailability(car, CarAvailability.NotAvailable);
            DateTime startTime = new DateTime(2100, 12, 12, 12, 0, 0);
            Arrangement arrangement = Arrangement.Airport;
            DateTime endTime = new DateTime(2100, 12, 12, 15, 0, 0);

            Assert.ThrowsException<DomainException>(() => rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));
        }
        [TestMethod()]
        public void CreateReservationTest_ShouldThrowDomainException_WhenStartTimeIsInTHePast()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            rm.AddClient(client);
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            List<Price> prices = new List<Price>();
            prices.Add(new Price(Arrangement.Airport, 100m));
            prices.Add(new Price(Arrangement.Business, 100m));
            prices.Add(new Price(Arrangement.NightLife, 900m));
            prices.Add(new Price(Arrangement.Wedding, 800m));
            prices.Add(new Price(Arrangement.Wellness, 750m));
            Car car = new Car("RabbitHole", "Delux", "Brown", prices);
            DeliveryAddress address = new DeliveryAddress("Teaparty", "1", "Wonderland");
            rm.AddCar(car);
            DateTime startTime = new DateTime(2019, 12, 12, 12, 0, 0);
            Arrangement arrangement = Arrangement.Airport;
            DateTime endTime = new DateTime(2019, 12, 12, 15, 0, 0);

            Assert.ThrowsException<DomainException>(() => rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));
        }
        [TestMethod()]
        public void CreateReservationTest_ShouldThrowDomainException_WhenTotalTimeExceedsMaxExceptWellness()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            rm.AddClient(client);
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            List<Price> prices = new List<Price>();
            prices.Add(new Price(Arrangement.Airport, 100m));
            prices.Add(new Price(Arrangement.Business, 100m));
            prices.Add(new Price(Arrangement.NightLife, 900m));
            prices.Add(new Price(Arrangement.Wedding, 800m));
            prices.Add(new Price(Arrangement.Wellness, 750m));
            Car car = new Car("RabbitHole", "Delux", "Brown", prices);
            DeliveryAddress address = new DeliveryAddress("Teaparty", "1", "Wonderland");
            rm.AddCar(car);
            DateTime startTime = new DateTime(2020, 12, 12, 11, 0, 0);
            Arrangement arrangement = Arrangement.Airport;
            DateTime endTime = new DateTime(2020, 12, 12, 23, 0, 0);

            Assert.ThrowsException<DomainException>(() => rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));
        }
        [TestMethod()]
        public void CreateReservationTest_ShouldThrowDomainException_WhenTotalTimeExceedsTenForWellness()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            rm.AddClient(client);
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            List<Price> prices = new List<Price>();
            prices.Add(new Price(Arrangement.Airport, 100m));
            prices.Add(new Price(Arrangement.Business, 100m));
            prices.Add(new Price(Arrangement.NightLife, 900m));
            prices.Add(new Price(Arrangement.Wedding, 800m));
            prices.Add(new Price(Arrangement.Wellness, 750m));
            Car car = new Car("RabbitHole", "Delux", "Brown", prices);
            DeliveryAddress address = new DeliveryAddress("Teaparty", "1", "Wonderland");
            rm.AddCar(car);
            DateTime startTime = new DateTime(2020, 12, 12, 11, 0, 0);
            Arrangement arrangement = Arrangement.Wellness;
            DateTime endTime = new DateTime(2020, 12, 12, 23, 0, 0);

            Assert.ThrowsException<DomainException>(() => rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));
        }
        [TestMethod()]
        public void CreateReservationTest_ShouldThrowDomainException_WhenStartTimeBeforeArrangementConditionsWedding()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            rm.AddClient(client);
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            List<Price> prices = new List<Price>();
            prices.Add(new Price(Arrangement.Airport, 100m));
            prices.Add(new Price(Arrangement.Business, 100m));
            prices.Add(new Price(Arrangement.NightLife, 900m));
            prices.Add(new Price(Arrangement.Wedding, 800m));
            prices.Add(new Price(Arrangement.Wellness, 750m));
            Car car = new Car("RabbitHole", "Delux", "Brown", prices);
            DeliveryAddress address = new DeliveryAddress("Teaparty", "1", "Wonderland");
            rm.AddCar(car);
            DateTime startTime = new DateTime(2020, 12, 12, 5, 0, 0);
            Arrangement arrangement = Arrangement.Wedding;
            DateTime endTime = new DateTime(2020, 12, 12, 15, 0, 0);

            Assert.ThrowsException<DomainException>(() => rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));
        }
        [TestMethod()]
        public void CreateReservationTest_ShouldThrowDomainException_WhenStartTimeAfterArrangementConditionsWedding()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            rm.AddClient(client);
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            List<Price> prices = new List<Price>();
            prices.Add(new Price(Arrangement.Airport, 100m));
            prices.Add(new Price(Arrangement.Business, 100m));
            prices.Add(new Price(Arrangement.NightLife, 900m));
            prices.Add(new Price(Arrangement.Wedding, 800m));
            prices.Add(new Price(Arrangement.Wellness, 750m));
            Car car = new Car("RabbitHole", "Delux", "Brown", prices);
            DeliveryAddress address = new DeliveryAddress("Teaparty", "1", "Wonderland");
            rm.AddCar(car);
            DateTime startTime = new DateTime(2020, 12, 12, 17, 0, 0);
            Arrangement arrangement = Arrangement.Wedding;
            DateTime endTime = new DateTime(2020, 12, 12, 23, 0, 0);

            Assert.ThrowsException<DomainException>(() => rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));
        }
        [TestMethod()]
        public void CreateReservationTest_ShouldThrowDomainException_WhenStartTimeBeforeArrangementConditionsWellness()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            rm.AddClient(client);
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            List<Price> prices = new List<Price>();
            prices.Add(new Price(Arrangement.Airport, 100m));
            prices.Add(new Price(Arrangement.Business, 100m));
            prices.Add(new Price(Arrangement.NightLife, 900m));
            prices.Add(new Price(Arrangement.Wedding, 800m));
            prices.Add(new Price(Arrangement.Wellness, 750m));
            Car car = new Car("RabbitHole", "Delux", "Brown", prices);
            DeliveryAddress address = new DeliveryAddress("Teaparty", "1", "Wonderland");
            rm.AddCar(car);
            DateTime startTime = new DateTime(2020, 12, 12, 5, 0, 0);
            Arrangement arrangement = Arrangement.Wellness;
            DateTime endTime = new DateTime(2020, 12, 12, 15, 0, 0);

            Assert.ThrowsException<DomainException>(() => rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));
        }
        [TestMethod()]
        public void CreateReservationTest_ShouldThrowDomainException_WhenStartTimeAfterArrangementConditionsWellness()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            rm.AddClient(client);
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            List<Price> prices = new List<Price>();
            prices.Add(new Price(Arrangement.Airport, 100m));
            prices.Add(new Price(Arrangement.Business, 100m));
            prices.Add(new Price(Arrangement.NightLife, 900m));
            prices.Add(new Price(Arrangement.Wedding, 800m));
            prices.Add(new Price(Arrangement.Wellness, 750m));
            Car car = new Car("RabbitHole", "Delux", "Brown", prices);
            DeliveryAddress address = new DeliveryAddress("Teaparty", "1", "Wonderland");
            rm.AddCar(car);
            DateTime startTime = new DateTime(2020, 12, 12, 17, 0, 0);
            Arrangement arrangement = Arrangement.Wellness;
            DateTime endTime = new DateTime(2020, 12, 12, 15, 0, 0);

            Assert.ThrowsException<DomainException>(() => rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));
        }
        [TestMethod()]
        public void CreateReservationTest_ShouldThrowDomainException_WhenStartTimeBeforeArrangementConditionsNightLife()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            rm.AddClient(client);
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            List<Price> prices = new List<Price>();
            prices.Add(new Price(Arrangement.Airport, 100m));
            prices.Add(new Price(Arrangement.Business, 100m));
            prices.Add(new Price(Arrangement.NightLife, 900m));
            prices.Add(new Price(Arrangement.Wedding, 800m));
            prices.Add(new Price(Arrangement.Wellness, 750m));
            Car car = new Car("RabbitHole", "Delux", "Brown", prices);
            DeliveryAddress address = new DeliveryAddress("Teaparty", "1", "Wonderland");
            rm.AddCar(car);
            DateTime startTime = new DateTime(2020, 12, 12, 17, 0, 0);
            Arrangement arrangement = Arrangement.NightLife;
            DateTime endTime = new DateTime(2020, 12, 12, 23, 0, 0);

            Assert.ThrowsException<DomainException>(() => rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));
        }
        [TestMethod()]
        public void CreateReservationTest_ShouldThrowDomainException_WhenStartTimeAfterArrangementConditionsNightLife()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            rm.AddClient(client);
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            List<Price> prices = new List<Price>();
            prices.Add(new Price(Arrangement.Airport, 100m));
            prices.Add(new Price(Arrangement.Business, 100m));
            prices.Add(new Price(Arrangement.NightLife, 900m));
            prices.Add(new Price(Arrangement.Wedding, 800m));
            prices.Add(new Price(Arrangement.Wellness, 750m));
            Car car = new Car("RabbitHole", "Delux", "Brown", prices);
            DeliveryAddress address = new DeliveryAddress("Teaparty", "1", "Wonderland");
            rm.AddCar(car);
            DateTime startTime = new DateTime(2020, 12, 12, 2, 0, 0);
            Arrangement arrangement = Arrangement.NightLife;
            DateTime endTime = new DateTime(2020, 12, 12, 15, 0, 0);

            Assert.ThrowsException<DomainException>(() => rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));
        }

        #endregion
        #region Add Functions
        [TestMethod()]
        public void AddReservationTest_DidAddReservation()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            rm.AddClient(client);
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            List<Price> prices = new List<Price>();
            prices.Add(new Price(Arrangement.Airport, 100m));
            prices.Add(new Price(Arrangement.Business, 100m));
            prices.Add(new Price(Arrangement.NightLife, 900m));
            prices.Add(new Price(Arrangement.Wedding, 800m));
            prices.Add(new Price(Arrangement.Wellness, 750m));
            Car car = new Car("RabbitHole", "Delux", "Brown", prices);
            DeliveryAddress address = new DeliveryAddress("Teaparty", "1", "Wonderland");
            rm.AddCar(car);
            DateTime startTime = new DateTime(2020, 12, 12, 21, 0, 0);
            Arrangement arrangement = Arrangement.NightLife;
            DateTime endTime = new DateTime(2020, 12, 13, 1, 0, 0);
            int amountReservations = rm.FindAllReservations().ToList().Count;

            rm.AddReservation(rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));
            Assert.IsTrue(rm.FindAllReservations().ToList().Count == amountReservations + 1);
        }
        [TestMethod()]
        public void AddReservationTest_DidNotAddClientAgain()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            rm.AddClient(client);
            Location start = Location.Antwerpen;
            Location stop = Location.Brussel;
            List<Price> prices = new List<Price>();
            prices.Add(new Price(Arrangement.Airport, 100m));
            prices.Add(new Price(Arrangement.Business, 100m));
            prices.Add(new Price(Arrangement.NightLife, 900m));
            prices.Add(new Price(Arrangement.Wedding, 800m));
            prices.Add(new Price(Arrangement.Wellness, 750m));
            Car car = new Car("RabbitHole", "Delux", "Brown", prices);
            DeliveryAddress address = new DeliveryAddress("Teaparty", "1", "Wonderland");
            rm.AddCar(car);
            DateTime startTime = new DateTime(2020, 12, 12, 21, 0, 0);
            Arrangement arrangement = Arrangement.NightLife;
            DateTime endTime = new DateTime(2020, 12, 13, 1, 0, 0);
            int amountClients = rm.FindAllClients().ToList().Count;

            rm.AddReservation(rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));
            Assert.IsTrue(rm.FindAllClients().ToList().Count == amountClients);
        }
        [TestMethod()]
        public void AddClientTest_DidAddClient()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
           
            int amountClients = rm.FindAllClients().ToList().Count;
            rm.AddClient(client);

            Assert.IsTrue(rm.FindAllClients().ToList().Count == amountClients + 1);
        }
        [TestMethod()]
        public void AddCarTest_DidAddCar()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            List<Price> prices = new List<Price>();
            prices.Add(new Price(Arrangement.Airport, 100m));
            prices.Add(new Price(Arrangement.Business, 100m));
            prices.Add(new Price(Arrangement.NightLife, 900m));
            prices.Add(new Price(Arrangement.Wedding, 800m));
            prices.Add(new Price(Arrangement.Wellness, 750m));
            Car car = new Car("RabbitHole", "Delux", "Brown", prices);
            
           

            int amountCars = rm.FindAllCars().ToList().Count;
            rm.AddCar(car);

            Assert.IsTrue(rm.FindAllCars().ToList().Count == amountCars + 1);
        }
        #endregion
    }
}

