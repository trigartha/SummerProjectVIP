using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
using DomainLibrary.Enums;
using DomainLibrary.Models;
using System.Linq;
using Shouldly;

namespace DomainLibrary.ViewModels.Tests
{
    [TestClass()]
    public class AddReservationViewModelTests
    {
        [TestMethod()]
        public void AddReservationTest()
        {
            ReservationManager rm = new ReservationManager(new UnitOfWork(new ReservationContextTest()));
            AddReservationViewModel mockViewModel = new AddReservationViewModel(rm);

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

            var reservationInfo =new ReservationInfo( start, stop, startTime, arrangement, endTime, address);
            mockViewModel.CurrentClient = client;
            mockViewModel.ReservationInfo = reservationInfo;
            mockViewModel.CurrentCar = car;
            var reservation = new Reservation(client, car, reservationInfo);

            mockViewModel.AddReservationCommand.Execute(null);
            
            Assert.AreEqual(reservation.Client, mockViewModel.Reservations.Last().Client);
        }
       
    }
}