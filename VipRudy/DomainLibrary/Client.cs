using DomainLibrary.Enums;
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
        #endregion
        #region Constructor
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
                case "Particulier":
                    clientCategory = ClientCategory.Particulier;
                    break;
                case "Organisation":
                    clientCategory = ClientCategory.Organisation;
                    break;
                case "VIP":
                    clientCategory = ClientCategory.Vip;
                    break;
                case "ConcertPromotor":
                    clientCategory = ClientCategory.ConcertPromotor;
                    break;
                case "WeddingPlanner":
                    clientCategory = ClientCategory.WeddingPlanner;
                    break;
                case "EventBureau":
                    clientCategory = ClientCategory.EventBureau;
                    break;
            }
            return clientCategory;
        }
        #endregion
    }
}
