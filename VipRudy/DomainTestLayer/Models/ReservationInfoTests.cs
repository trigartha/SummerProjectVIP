using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using DomainLibrary.Enums;
using Shouldly;

namespace DomainLibrary.Models.Tests
{
    [TestClass()]
    public class ReservationInfoTests
    {
        [TestMethod()]
        public void WhenCreated_DateTimeGetsSetRight_WhenHourSelected()
        {
            Location startLocaion = Location.Antwerpen;
            Location endLocation = Location.Antwerpen;
            Arrangement arrangement = Arrangement.Airport;
            DateTime startDay = new DateTime(2020, 5, 9);
            DateTime endDay = new DateTime(2020, 5, 9);
            DeliveryAddress deliveryAddress = new DeliveryAddress();
            int startH = 8;
            int endH = 14;
            ReservationInfo r = new ReservationInfo(startLocaion, endLocation, startDay, arrangement, endDay, deliveryAddress, startH, endH);

            r.StartTime.Hour.ShouldBe(startH);
            r.EndTime.Hour.ShouldBe(endH);
        }
    }
}