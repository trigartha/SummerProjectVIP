using DomainLibrary.Enums;
using DomainLibrary.Framework;
using DomainLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DomainLibrary
{
    public class Client : Notifier
    {
        #region Fields
        private int _clientNumber;
        private string _name;
        private string _taxNumber;
        private ClientCategory _clientCategory;
        private Address _address;
       // private ICollection<Reservation> _reservations;
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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClientNumber
        {
            get { return _clientNumber; }
             set
            {
                if (_clientNumber != value)
                {
                    _clientNumber = value;
                    RaisePropertyChanged(() => ClientNumber);
                }
            }
        }
        public string Name
        {
            get { return _name; }
             set
            {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged(() => Name);
                }
            }
        }
        public string TaxNumber
        {
            get { return _taxNumber; }
             set
            {
                if (_taxNumber != value)
                {
                    _taxNumber = value;
                    RaisePropertyChanged(() => TaxNumber);
                }
            }
        }
        public ClientCategory ClientCategory
        {
            get { return _clientCategory; }
             set
            {
                if (_clientCategory != value)
                {
                    _clientCategory = value;
                    RaisePropertyChanged(() => ClientCategory);
                }
            }
        }
        public Address Address
        {
            get { return _address; }
             set
            {
                if (_address != value)
                {
                    _address = value;
                    RaisePropertyChanged(() => Address);
                }
            }
        }
        /*
        public ICollection<Reservation> Reservations
        {
            get { return _reservations; }
             set
            {
                if (_reservations != value)
                {
                    _reservations = value;
                    RaisePropertyChanged(() => Reservations);
                }
            }
        }*/
    }
}
