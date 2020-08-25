using DomainLibrary.Framework;
using DomainLibrary.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;

namespace DomainLibrary.ViewModels
{
    public class FindReservationViewModel : VipRudyViewModelBase
    {
        #region Properties
        public RelayCommand ShowReservationCommand { get; private set; }
        #endregion
        #region Fields
        private ReservationManager _reservationManager;
        private ObservableCollection<Reservation> _reservations;
        private ObservableCollection<Client> _clients;
        private ReservationOverview _reservationOverview;
        private Reservation _currentReservation;
        private Client _currentClient;
        private DateTime _pickedTime;
        private bool _clientIsChecked;
        private bool _dateIsChecked;
        #endregion
        #region Constructor
        public FindReservationViewModel(ReservationManager reservationManager)
        {
            this._reservationManager = reservationManager;

            Clients = new ObservableCollection<Client>(_reservationManager.FindAllClients());
            Reservations = new ObservableCollection<Reservation>(_reservationManager.FindAllReservations());

            ShowReservationCommand = new RelayCommand(GetReservations);
        }
        #endregion
        #region Methods

        #endregion
        /// <summary>
        /// Gets or sets the Reservations.
        /// </summary>
        /// <value>The reservations.</value>
        public ObservableCollection<Reservation> Reservations
        {
            get
            {
                return _reservations;
            }
            set
            {
                if (_reservations != value)
                {
                    _reservations = value;
                    RaisePropertyChanged(() => Reservations);
                }
            }
        }
        /// <summary>
        /// Gets or sets the Clients.
        /// </summary>
        /// <value>The clients.</value>
        public ObservableCollection<Client> Clients
        {
            get
            {
                return _clients;
            }
            set
            {
                if (_clients != value)
                {
                    _clients = value;
                    RaisePropertyChanged(() => Clients);
                }
            }
        }
        public Client CurrentClient
        {
            get
            {
                return _currentClient;
            }
            set
            {
                if (_currentClient != value)
                {
                    _currentClient = value;
                    RaisePropertyChanged(() => CurrentClient);
                }
            }
        }
        public Reservation CurrentReservation
        {
            get
            {
                return _currentReservation;
            }
            set
            {
                if (_currentReservation != value)
                {
                    _currentReservation = value;
                    RaisePropertyChanged(() => CurrentReservation);
                }
            }
        }
        public DateTime PickedTime
        {
            get { return _pickedTime; }
            set
            {
                if (_pickedTime != value)
                {
                    _pickedTime = value;
                    RaisePropertyChanged(() => PickedTime);
                }
            }
        }
        public bool ClientIsChecked
        {
            get { return _clientIsChecked; }
            set
            {
                if (_clientIsChecked == value) return;
                _clientIsChecked = value;
                RaisePropertyChanged(() => ClientIsChecked);
            }
        }
        public bool DateIsChecked
        {
            get { return _dateIsChecked; }
            set
            {
                if (_dateIsChecked == value) return;
                _dateIsChecked = value;
                RaisePropertyChanged(() => DateIsChecked);
            }
        }
        /*public string Name
        {
            get { return _currentReservation.Client.Name; }
            set
            {
                if (_currentReservation.Client.Name != value)
                {
                    _currentReservation.Client.Name = value;
                    RaisePropertyChanged(() => Name);
                }
            }
        }*/
        public DateTime ReservationDate
        {
            get { return _currentReservation.ReservationDate; }
            set
            {
                if (_currentReservation.ReservationDate != value)
                {
                    _currentReservation.ReservationDate = value;
                    RaisePropertyChanged(() => ReservationDate);
                }
            }
        }
        public ReservationOverview CurrentReservationOverview
        {
            get
            {
                return _reservationOverview;
            }
            set
            {
                if (_reservationOverview != value)
                {
                    _reservationOverview = value;
                    RaisePropertyChanged(() => CurrentReservationOverview);

                }
            }
        }
        private void GetReservations()
        {
            if(_clientIsChecked && _dateIsChecked)
            {
                this.Reservations = new ObservableCollection<Reservation>(_reservationManager.FindAllReservationsOnDateAndClient(_pickedTime, _currentClient));
            }
            else if (_clientIsChecked && !_dateIsChecked)
            {
                this.Reservations = new ObservableCollection<Reservation>(_reservationManager.FindAllReservationsOnClient(_currentClient));
            }
            else if (!_clientIsChecked && _dateIsChecked)
            {
                this.Reservations = new ObservableCollection<Reservation>(_reservationManager.FindAllReservationsOnDate(_pickedTime));
            }
            else if (!_clientIsChecked && !_dateIsChecked)
            {
                this.Reservations = new ObservableCollection<Reservation>(_reservationManager.FindAllReservations());
            }

        }
        public ReservationOverview CreateNewOverview()
        {
            CreateOverview();
            return CurrentReservationOverview;
        }
        private void CreateOverview()
        {
            
            this.CurrentReservationOverview = _reservationManager.CreateOverview(CurrentReservation);
        }
    }
}
