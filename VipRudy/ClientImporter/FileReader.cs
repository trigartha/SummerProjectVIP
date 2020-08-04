using DataLayer;
using DomainLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientImporter
{
    public class FileReader
    {
        #region Fields
        public static string ClientFile = @"C:\Users\Triga\Documents\GitHub\SummerProjectVIP\klanten.txt";
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
        public static void AddClients()
        {
            ReservationManager RM = new ReservationManager(new UnitOfWork(new ReservationContext("Reservation")));
            List<Client> clients = ReadClients();
            foreach(Client c in clients)
            {
                RM.AddClient(c);
            }
        }
        #endregion
    }
}
