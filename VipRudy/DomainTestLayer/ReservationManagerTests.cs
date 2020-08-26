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
using Shouldly;

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
        public void AddReservationTest_DidNotAddCarAgain()
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
            int amountCars = rm.FindAllCars().ToList().Count;

            rm.AddReservation(rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));
            Assert.IsTrue(rm.FindAllCars().ToList().Count == amountCars);
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

        [TestMethod()]
        public void FindAllReservationsTest_ReturnsRightAmount()
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


            rm.AddReservation(rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));

            Client client2 = new Client(777, "MaddHatter", "Tea", ClientCategory.Vip, new Address());
            rm.AddClient(client2);
            Location start2 = Location.Antwerpen;
            Location stop2 = Location.Brussel;
            List<Price> prices2 = new List<Price>();
            prices2.Add(new Price(Arrangement.Airport, 150m));
            prices2.Add(new Price(Arrangement.Business, 110m));
            prices2.Add(new Price(Arrangement.NightLife, 400m));
            prices2.Add(new Price(Arrangement.Wedding, 500m));
            prices2.Add(new Price(Arrangement.Wellness, 650m));
            Car car2 = new Car("Teacup", "Extra Fragile", "White", prices2);
            DeliveryAddress address2 = new DeliveryAddress("RabbitHole", "3", "Wonderland");
            rm.AddCar(car2);
            DateTime startTime2 = new DateTime(2020, 12, 12, 21, 0, 0);
            Arrangement arrangement2 = Arrangement.Airport;
            DateTime endTime2 = new DateTime(2020, 12, 13, 1, 0, 0);

            rm.AddReservation(rm.CreateReservation(client2, start2, stop2, car2, startTime2, arrangement2, endTime2, address2));

            Assert.IsTrue(rm.FindAllReservations().ToList().Count == 2);
        }
        [TestMethod()]
        public void FindAllReservationsTest_LoadsClient()
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


            rm.AddReservation(rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));
            ReservationManager rmNew = new ReservationManager(new UnitOfWork(new ReservationContextTest(true)));
            Reservation r = rmNew.FindAllReservations().FirstOrDefault();
            Assert.IsTrue(r.Client != null);
            Assert.IsTrue(r.Client.Name == client.Name);
        }
        [TestMethod()]
        public void FindAllReservationsTest_LoadsCar()
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


            rm.AddReservation(rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));
            ReservationManager rmNew = new ReservationManager(new UnitOfWork(new ReservationContextTest(true)));
            Reservation r = rmNew.FindAllReservations().FirstOrDefault();
            Assert.IsTrue(r.Car != null);
            Assert.IsTrue(r.Car.Model == car.Model);
        }
        [TestMethod()]
        public void FindAllReservationsTest_LoadsReservationInfo()
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


            rm.AddReservation(rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));
            ReservationManager rmNew = new ReservationManager(new UnitOfWork(new ReservationContextTest(true)));
            Reservation r = rmNew.FindAllReservations().FirstOrDefault();
            Assert.IsTrue(r.ReservationInfo != null);
            Assert.IsTrue(r.ReservationInfo.Address.City == address.City);
        }

        [TestMethod()]
        public void FindAllReservationsOnClientTest_GivesRghtAmountResBack()
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


            rm.AddReservation(rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));

            Client client2 = new Client(777, "MaddHatter", "Tea", ClientCategory.Vip, new Address());
            rm.AddClient(client2);
            Location start2 = Location.Antwerpen;
            Location stop2 = Location.Brussel;
            List<Price> prices2 = new List<Price>();
            prices2.Add(new Price(Arrangement.Airport, 150m));
            prices2.Add(new Price(Arrangement.Business, 110m));
            prices2.Add(new Price(Arrangement.NightLife, 400m));
            prices2.Add(new Price(Arrangement.Wedding, 500m));
            prices2.Add(new Price(Arrangement.Wellness, 650m));
            Car car2 = new Car("Teacup", "Extra Fragile", "White", prices2);
            DeliveryAddress address2 = new DeliveryAddress("RabbitHole", "3", "Wonderland");
            rm.AddCar(car2);
            DateTime startTime2 = new DateTime(2020, 12, 12, 21, 0, 0);
            Arrangement arrangement2 = Arrangement.Airport;
            DateTime endTime2 = new DateTime(2020, 12, 13, 1, 0, 0);

            rm.AddReservation(rm.CreateReservation(client2, start2, stop2, car2, startTime2, arrangement2, endTime2, address2));


            Location start3 = Location.Antwerpen;
            Location stop3 = Location.Brussel;
            List<Price> prices3 = new List<Price>();
            prices3.Add(new Price(Arrangement.Airport, 150m));
            prices3.Add(new Price(Arrangement.Business, 110m));
            prices3.Add(new Price(Arrangement.NightLife, 400m));
            prices3.Add(new Price(Arrangement.Wedding, 500m));
            prices3.Add(new Price(Arrangement.Wellness, 650m));

            DeliveryAddress address3 = new DeliveryAddress("RedQueensCastle", "3", "Wonderland");

            DateTime startTime3 = new DateTime(2020, 12, 12, 21, 0, 0);
            Arrangement arrangement3 = Arrangement.Airport;
            DateTime endTime3 = new DateTime(2020, 12, 13, 1, 0, 0);

            rm.AddReservation(rm.CreateReservation(client2, start3, stop3, car2, startTime3, arrangement3, endTime3, address3));

            Assert.IsTrue(rm.FindAllReservationsOnClient(client2).ToList().Count == 2);
        }

        [TestMethod()]
        public void FindAllReservationsOnDateTest_GivesRghtAmountResBack()
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


            rm.AddReservation(rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));

            Client client2 = new Client(777, "MaddHatter", "Tea", ClientCategory.Vip, new Address());
            rm.AddClient(client2);
            Location start2 = Location.Antwerpen;
            Location stop2 = Location.Brussel;
            List<Price> prices2 = new List<Price>();
            prices2.Add(new Price(Arrangement.Airport, 150m));
            prices2.Add(new Price(Arrangement.Business, 110m));
            prices2.Add(new Price(Arrangement.NightLife, 400m));
            prices2.Add(new Price(Arrangement.Wedding, 500m));
            prices2.Add(new Price(Arrangement.Wellness, 650m));
            Car car2 = new Car("Teacup", "Extra Fragile", "White", prices2);
            DeliveryAddress address2 = new DeliveryAddress("RabbitHole", "3", "Wonderland");
            rm.AddCar(car2);
            DateTime startTime2 = new DateTime(2020, 12, 12, 21, 0, 0);
            Arrangement arrangement2 = Arrangement.Airport;
            DateTime endTime2 = new DateTime(2020, 12, 13, 1, 0, 0);

            rm.AddReservation(rm.CreateReservation(client2, start2, stop2, car2, startTime2, arrangement2, endTime2, address2));


            Location start3 = Location.Antwerpen;
            Location stop3 = Location.Brussel;
            List<Price> prices3 = new List<Price>();
            prices3.Add(new Price(Arrangement.Airport, 150m));
            prices3.Add(new Price(Arrangement.Business, 110m));
            prices3.Add(new Price(Arrangement.NightLife, 400m));
            prices3.Add(new Price(Arrangement.Wedding, 500m));
            prices3.Add(new Price(Arrangement.Wellness, 650m));

            DeliveryAddress address3 = new DeliveryAddress("RedQueensCastle", "3", "Wonderland");

            DateTime startTime3 = new DateTime(2020, 12, 12, 21, 0, 0);
            Arrangement arrangement3 = Arrangement.Airport;
            DateTime endTime3 = new DateTime(2020, 12, 13, 1, 0, 0);

            rm.AddReservation(rm.CreateReservation(client2, start3, stop3, car2, startTime3, arrangement3, endTime3, address3));

            Assert.IsTrue(rm.FindAllReservationsOnDate(DateTime.Now).ToList().Count == 3);
        }

        [TestMethod()]
        public void FindAllCarsTest_ReturnsRightAmount()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            List<Price> prices = new List<Price>();
            prices.Add(new Price(Arrangement.Airport, 100m));
            prices.Add(new Price(Arrangement.Business, 100m));
            prices.Add(new Price(Arrangement.NightLife, 900m));
            prices.Add(new Price(Arrangement.Wedding, 800m));
            prices.Add(new Price(Arrangement.Wellness, 750m));
            List<Price> prices2 = new List<Price>();
            prices2.Add(new Price(Arrangement.Airport, 150m));
            prices2.Add(new Price(Arrangement.Business, 110m));
            prices2.Add(new Price(Arrangement.NightLife, 400m));
            prices2.Add(new Price(Arrangement.Wedding, 500m));
            prices2.Add(new Price(Arrangement.Wellness, 650m));
            Car car = new Car("RabbitHole", "Delux", "Brown", prices);
            Car car2 = new Car("Teacup", "Extra Fragile", "White", prices2);
            rm.AddCar(car);
            rm.AddCar(car2);
            Assert.IsTrue(rm.FindAllCars().ToList().Count == 2);
        }

        [TestMethod()]
        public void FindAllClientsTest_ReturnsRightAmount()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            Client client = new Client(999, "Alice", "Cards", ClientCategory.Vip, new Address());
            Client client2 = new Client(777, "MaddHatter", "Tea", ClientCategory.Vip, new Address());
            Client client3 = new Client(666, "RedQueen", "Heads", ClientCategory.Vip, new Address());
            rm.AddClient(client);
            rm.AddClient(client2);
            rm.AddClient(client3);
            Assert.IsTrue(rm.FindAllClients().ToList().Count == 3);
        }
       
        [TestMethod()]
        public void FindAllCarsOnArrangementTest_WhenNoPriceExist()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            List<Price> prices = new List<Price>();
            prices.Add(new Price(Arrangement.Airport, 100m));
            prices.Add(new Price(Arrangement.Business, 100m));
            prices.Add(new Price(Arrangement.NightLife, 900m));
            prices.Add(new Price(Arrangement.Wedding, null));
            prices.Add(new Price(Arrangement.Wellness, 750m));
            List<Price> prices2 = new List<Price>();
            prices2.Add(new Price(Arrangement.Airport, 150m));
            prices2.Add(new Price(Arrangement.Business, 110m));
            prices2.Add(new Price(Arrangement.NightLife, 400m));
            prices2.Add(new Price(Arrangement.Wedding, 500m));
            prices2.Add(new Price(Arrangement.Wellness, 650m));
            Car car = new Car("RabbitHole", "Delux", "Brown", prices);
            Car car2 = new Car("Teacup", "Extra Fragile", "White", prices2);
            rm.AddCar(car);
            rm.AddCar(car2);
            Assert.IsTrue(rm.FindAllCarsOnArrangement(Arrangement.Wedding).ToList().Count == 1);
        }

        [TestMethod()]
        public void FindAllOnBrandTest_ReturnsRightAmount()
        {

            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            List<Price> prices = new List<Price>();
            prices.Add(new Price(Arrangement.Airport, 100m));
            prices.Add(new Price(Arrangement.Business, 100m));
            prices.Add(new Price(Arrangement.NightLife, 900m));
            prices.Add(new Price(Arrangement.Wedding, null));
            prices.Add(new Price(Arrangement.Wellness, 750m));
            List<Price> prices2 = new List<Price>();
            prices2.Add(new Price(Arrangement.Airport, 150m));
            prices2.Add(new Price(Arrangement.Business, 110m));
            prices2.Add(new Price(Arrangement.NightLife, 400m));
            prices2.Add(new Price(Arrangement.Wedding, 500m));
            prices2.Add(new Price(Arrangement.Wellness, 650m));
            Car car = new Car("RabbitHole", "Delux", "Brown", prices);
            Car car2 = new Car("Teacup", "Extra Fragile", "White", prices2);
            rm.AddCar(car);
            rm.AddCar(car2);
            Assert.IsTrue(rm.FindAllOnBrand("RabbitHole").ToList().Count == 1);
        }

        [TestMethod()]
        public void FindAllOnColourTest()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            List<Price> prices = new List<Price>();
            prices.Add(new Price(Arrangement.Airport, 100m));
            prices.Add(new Price(Arrangement.Business, 100m));
            prices.Add(new Price(Arrangement.NightLife, 900m));
            prices.Add(new Price(Arrangement.Wedding, null));
            prices.Add(new Price(Arrangement.Wellness, 750m));
            List<Price> prices2 = new List<Price>();
            prices2.Add(new Price(Arrangement.Airport, 150m));
            prices2.Add(new Price(Arrangement.Business, 110m));
            prices2.Add(new Price(Arrangement.NightLife, 400m));
            prices2.Add(new Price(Arrangement.Wedding, 500m));
            prices2.Add(new Price(Arrangement.Wellness, 650m));
            Car car = new Car("RabbitHole", "Delux", "Brown", prices);
            Car car2 = new Car("Teacup", "Extra Fragile", "White", prices2);
            rm.AddCar(car);
            rm.AddCar(car2);
            Assert.IsTrue(rm.FindAllOnColour("White").ToList().Count == 1);
        }
        #region CreateOverViewTests
        [TestMethod()]
        public void CreateOverviewTest_AirportArrangement_CalculatesRightPricesNoOverTime()
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
            DateTime startTime = new DateTime(2020, 12, 12, 8, 0, 0);
            Arrangement arrangement = Arrangement.Airport;
            DateTime endTime = new DateTime(2020, 12, 12, 12, 0, 0);


            ReservationOverview reservationOverview = rm.CreateOverview(rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));
            reservationOverview.TotalNormal.ShouldBe(295m);
            reservationOverview.TotalBeforeDiscount.ShouldBe(295m);
            reservationOverview.Tax.ShouldBe(18m);
            reservationOverview.TotalToPay.ShouldBe(313m);
        }
        [TestMethod()]
        public void CreateOverviewTest_AirportArrangement_CalculatesRightPricesWithNightTime()
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
            Arrangement arrangement = Arrangement.Airport;
            DateTime endTime = new DateTime(2020, 12, 12, 12, 0, 0);


            ReservationOverview reservationOverview = rm.CreateOverview(rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));
            reservationOverview.TotalNormal.ShouldBe(360);
            reservationOverview.TotalNight.ShouldBe(280);
            reservationOverview.TotalBeforeDiscount.ShouldBe(640);
            reservationOverview.Tax.ShouldBe(38m);
            reservationOverview.TotalToPay.ShouldBe(678m);
        }
        [TestMethod()]
        public void CreateOverviewTest_BusinessArrangement_CalculatesRightPricesNoOverTime()
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
            DateTime startTime = new DateTime(2020, 12, 12, 8, 0, 0);
            Arrangement arrangement = Arrangement.Business;
            DateTime endTime = new DateTime(2020, 12, 12, 12, 0, 0);


            ReservationOverview reservationOverview = rm.CreateOverview(rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));
            reservationOverview.TotalNormal.ShouldBe(295m);
            reservationOverview.TotalBeforeDiscount.ShouldBe(295m);
            reservationOverview.Tax.ShouldBe(18m);
            reservationOverview.TotalToPay.ShouldBe(313m);
        }
        [TestMethod()]
        public void CreateOverviewTest_BusinesArrangement_CalculatesRightPricesWithNightTime()
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
            Arrangement arrangement = Arrangement.Business;
            DateTime endTime = new DateTime(2020, 12, 12, 12, 0, 0);


            ReservationOverview reservationOverview = rm.CreateOverview(rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));
            reservationOverview.TotalNormal.ShouldBe(360);
            reservationOverview.TotalNight.ShouldBe(280);
            reservationOverview.TotalBeforeDiscount.ShouldBe(640);
            reservationOverview.Tax.ShouldBe(38m);
            reservationOverview.TotalToPay.ShouldBe(678m);
        }
        [TestMethod()]
        public void CreateOverviewTest_NightLifeArrangement_CalculatesRightPricesNoOverTime()
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
            DateTime startTime = new DateTime(2020, 12, 12, 0, 0, 0);
            Arrangement arrangement = Arrangement.NightLife;
            DateTime endTime = new DateTime(2020, 12, 12, 7, 0, 0);


            ReservationOverview reservationOverview = rm.CreateOverview(rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));
            reservationOverview.TotalNormal.ShouldBe(900);
            reservationOverview.TotalBeforeDiscount.ShouldBe(900m);
            reservationOverview.Tax.ShouldBe(54m);
            reservationOverview.TotalToPay.ShouldBe(954m);
        }
        [TestMethod()]
        public void CreateOverviewTest_NightLifeArrangement_CalculatesRightPricesWithOverTime()
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
            DateTime startTime = new DateTime(2020, 12, 12, 0, 0, 0);
            Arrangement arrangement = Arrangement.NightLife;
            DateTime endTime = new DateTime(2020, 12, 12, 8, 0, 0);

            ReservationOverview reservationOverview = rm.CreateOverview(rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));

            reservationOverview.TotalNormal.ShouldBe(900);
            reservationOverview.TotalOverTime.ShouldBe(140);
            reservationOverview.TotalBeforeDiscount.ShouldBe(1040m);
            reservationOverview.Tax.ShouldBe(62m);
            reservationOverview.TotalToPay.ShouldBe(1102m);
        }
        [TestMethod()]
        public void CreateOverviewTest_WeddingArrangement_CalculatesRightPricesNoOverTime()
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
            DateTime startTime = new DateTime(2020, 12, 12, 8, 0, 0);
            Arrangement arrangement = Arrangement.Wedding;
            DateTime endTime = new DateTime(2020, 12, 12, 15, 0, 0);


            ReservationOverview reservationOverview = rm.CreateOverview(rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));
            reservationOverview.TotalNormal.ShouldBe(800);
            reservationOverview.TotalBeforeDiscount.ShouldBe(800m);
            reservationOverview.Tax.ShouldBe(48m);
            reservationOverview.TotalToPay.ShouldBe(848m);
        }
        [TestMethod()]
        public void CreateOverviewTest_WeddingArrangement_CalculatesRightPricesWithOverTime()
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
            DateTime startTime = new DateTime(2020, 12, 12, 8, 0, 0);
            Arrangement arrangement = Arrangement.Wedding;
            DateTime endTime = new DateTime(2020, 12, 12, 19, 0, 0);

            ReservationOverview reservationOverview = rm.CreateOverview(rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));

            reservationOverview.TotalNormal.ShouldBe(800);
            reservationOverview.TotalOverTime.ShouldBe(260);
            reservationOverview.TotalBeforeDiscount.ShouldBe(1060m);
            reservationOverview.Tax.ShouldBe(64m);
            reservationOverview.TotalToPay.ShouldBe(1124m);
        }
        [TestMethod()]
        public void CreateOverviewTest_WeddingArrangement_CalculatesRightPricesWithNightTime()
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
            DateTime startTime = new DateTime(2020, 12, 12, 13, 0, 0);
            Arrangement arrangement = Arrangement.Wedding;
            DateTime endTime = new DateTime(2020, 12, 13, 0, 0, 0);

            ReservationOverview reservationOverview = rm.CreateOverview(rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));

            reservationOverview.TotalNormal.ShouldBe(800);
            reservationOverview.TotalOverTime.ShouldBe(130);
            reservationOverview.TotalNight.ShouldBe(280);
            reservationOverview.TotalBeforeDiscount.ShouldBe(1210m);
            reservationOverview.Tax.ShouldBe(73m);
            reservationOverview.TotalToPay.ShouldBe(1283m);
        }
        [TestMethod()]
        public void CreateOverviewTest_WellnessArrangement_CalculatesRightPrices()
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
            DateTime startTime = new DateTime(2020, 12, 12, 8, 0, 0);
            Arrangement arrangement = Arrangement.Wellness;
            DateTime endTime = new DateTime(2020, 12, 12, 18, 0, 0);


            ReservationOverview reservationOverview = rm.CreateOverview(rm.CreateReservation(client, start, stop, car, startTime, arrangement, endTime, address));
            reservationOverview.TotalNormal.ShouldBe(750);
            reservationOverview.TotalBeforeDiscount.ShouldBe(750);
            reservationOverview.Tax.ShouldBe(45m);
            reservationOverview.TotalToPay.ShouldBe(795m);
        }
        #endregion
        
    }
}

