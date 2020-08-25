using DataLayer;
using DomainLibrary;
using DomainLibrary.Enums;
using DomainLibrary.Models;
using System;
using System.Collections.Generic;

namespace ClientImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

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

            // FileReader.AddClients();
            // FileReader.AddCars();
            Console.ReadKey();
        }
    }
}
