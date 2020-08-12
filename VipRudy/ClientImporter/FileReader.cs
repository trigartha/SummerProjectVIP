using DataLayer;
using DomainLibrary;
using DomainLibrary.Enums;
using DomainLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientImporter
{
    public class FileReader
    {
        #region Fields
        public static string ClientFile = @"C:\Users\Triga\Documents\GitHub\SummerProjectVIP\klanten.txt";
        public static string CarFile = @"C:\Users\Triga\Documents\GitHub\SummerProjectVIP\carpark.txt";
        #endregion
        #region Methods
        private static List<Client> ReadClients()
        {
            List<Client> clients = new List<Client>();
            string[] linesData = System.IO.File.ReadAllLines(FileReader.ClientFile);
            for(int index=1; index<linesData.Length;index++)
            {
                string[] fieldsData = linesData[index].Split(',');
                int clientNumber = int.Parse(fieldsData[0]);
                char[] toSplit = { ' ', '-' };
                string[]addressdata = fieldsData[4].Split(toSplit);
                clients.Add(new Client(clientNumber, fieldsData[1], fieldsData[3], Client.GetClientCategory(fieldsData[2]), new Address(addressdata[0], addressdata[1], addressdata[4])));
            }
            return clients;
        }
        private static List<Car> ReadCars()
        {
            List<Car> cars = new List<Car>();
            string[] linesData = System.IO.File.ReadAllLines(FileReader.CarFile);
            for (int index = 0; index < linesData.Length; index++)
            {
                string[] fieldsData = linesData[index].Split(',');
                char[] toTrim = { '€', ' ','-','–' };

                List<Price> prices = new List<Price>();
                
                decimal? firstH = FileReader.DecimalParser(fieldsData[3].Trim(toTrim));
                decimal? nightL = FileReader.DecimalParser(fieldsData[4].Trim(toTrim));
                decimal? wedding = FileReader.DecimalParser(fieldsData[5].Trim(toTrim));
                decimal? wellness = FileReader.DecimalParser(fieldsData[6].Trim(toTrim));
                prices.Add(new Price(Arrangement.Airport, firstH));
                prices.Add(new Price(Arrangement.Business, firstH));
                prices.Add(new Price(Arrangement.NightLife, nightL));
                prices.Add(new Price(Arrangement.Wedding, wedding));
                prices.Add(new Price(Arrangement.Wellness, wellness));
                cars.Add(new Car(fieldsData[0], fieldsData[1].TrimStart(), fieldsData[2].Trim(toTrim), prices));
            }
            return cars;
        }
        public static void AddClients()
        {
            ReservationManager RM = new ReservationManager(new UnitOfWork(new ReservationContext("Reservation")));
            RM.DeleteAllClients();
            List<Client> clients = ReadClients();
            foreach(Client c in clients)
            {
                RM.AddClient(c);
            }
        }
        public static void AddCars()
        {
            ReservationManager RM = new ReservationManager(new UnitOfWork(new ReservationContext("Reservation")));
            RM.DeleteAllCars();
            List<Car> cars = ReadCars();
            foreach (Car c in cars)
            {
                RM.AddCar(c);
            }
        }
        private static decimal? DecimalParser(string value)
        {
            decimal test;
            decimal? result;
            if (decimal.TryParse(value, out test))
                result = decimal.Parse(value);
            else
                result = null;
            return result;
        }
        #endregion
    }
}
