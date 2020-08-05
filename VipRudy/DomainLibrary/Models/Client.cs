using DomainLibrary.Enums;
using DomainLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary
{
    public class Client
    {
        #region Properties
        public int ClientNumber { get; set; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public ClientCategory ClientCategory { get; set; }
        public Address Address { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        #endregion
        #region Constructor
        public Client() { }
        public Client(int clientNumber, string name, string taxNumber, ClientCategory clientCategory, Address address)
        {
            this.ClientNumber = clientNumber;
            this.Name = name;
            this.TaxNumber = taxNumber;
            this.ClientCategory = clientCategory;
            this.Address = address;
        }
        #endregion
        #region Methods
        public static ClientCategory GetClientCategory(string cat)
        {
            ClientCategory clientCategory = ClientCategory.Particulier;
            switch (cat)
            {
                case "particulier":
                    clientCategory = ClientCategory.Particulier;
                    break;
                case "organisatie":
                    clientCategory = ClientCategory.Organisation;
                    break;
                case "vip":
                    clientCategory = ClientCategory.Vip;
                    break;
                case "concertpromotor":
                    clientCategory = ClientCategory.ConcertPromotor;
                    break;
                case "huwelijksplanner":
                    clientCategory = ClientCategory.WeddingPlanner;
                    break;
                case "evenementenbureau <":
                    clientCategory = ClientCategory.EventBureau;
                    break;
            }
            return clientCategory;
        }
        #endregion
    }
}
