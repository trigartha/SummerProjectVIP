using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using DomainLibrary.Models;
using DataLayer;
using DomainLibrary.Enums;
using Shouldly;

namespace DomainLibrary.ViewModels.Tests
{
    [TestClass()]
    public class FindReservationViewModelTests
    {
        [TestMethod()]
        public void CreateNewOverviewTest_CreatesOverViewAndCalculatesRight()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            FindReservationViewModel mockViewModel = new FindReservationViewModel(rm);
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
        public void ShowReservationsCommand_NothingSelected()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            FindReservationViewModel mockViewModel = new FindReservationViewModel(rm);

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
            DateTime startTime2 = new DateTime(2020, 12, 13, 21, 0, 0);
            Arrangement arrangement2 = Arrangement.Airport;
            DateTime endTime2 = new DateTime(2020, 12, 14, 1, 0, 0);

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

            mockViewModel.DateIsChecked = false;
            mockViewModel.ClientIsChecked = false;
            mockViewModel.ShowReservationCommand.Execute(null);

            mockViewModel.Reservations.Count.ShouldBe(3);
        }
        [TestMethod()]
        public void ShowReservationsCommand_ClientSelected()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            FindReservationViewModel mockViewModel = new FindReservationViewModel(rm);

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
            DateTime startTime2 = new DateTime(2020, 12, 13, 21, 0, 0);
            Arrangement arrangement2 = Arrangement.Airport;
            DateTime endTime2 = new DateTime(2020, 12, 14, 1, 0, 0);

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

            mockViewModel.DateIsChecked = false;
            mockViewModel.ClientIsChecked = true;
            mockViewModel.CurrentClient = client2;
            mockViewModel.ShowReservationCommand.Execute(null);

            mockViewModel.Reservations.Count.ShouldBe(2);
        }
        [TestMethod()]
        public void ShowReservationsCommand_DateSelected()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            FindReservationViewModel mockViewModel = new FindReservationViewModel(rm);

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
            DateTime startTime2 = new DateTime(2020, 12, 13, 21, 0, 0);
            Arrangement arrangement2 = Arrangement.Airport;
            DateTime endTime2 = new DateTime(2020, 12, 14, 1, 0, 0);

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

            mockViewModel.DateIsChecked = true;
            mockViewModel.ClientIsChecked = false;
            mockViewModel.PickedTime = DateTime.Today;
            mockViewModel.ShowReservationCommand.Execute(null);

            mockViewModel.Reservations.Count.ShouldBe(3);
        }
        [TestMethod()]
        public void ShowReservationsCommand_DateAndClientSelected()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            FindReservationViewModel mockViewModel = new FindReservationViewModel(rm);

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
            DateTime startTime2 = new DateTime(2020, 12, 13, 21, 0, 0);
            Arrangement arrangement2 = Arrangement.Airport;
            DateTime endTime2 = new DateTime(2020, 12, 14, 1, 0, 0);

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

            mockViewModel.PickedTime = DateTime.Today;
            mockViewModel.CurrentClient = client2;
            mockViewModel.DateIsChecked = true;
            mockViewModel.ClientIsChecked = true;
         
            mockViewModel.ShowReservationCommand.Execute(null);

            mockViewModel.Reservations.Count.ShouldBe(2);
        }
    }
}