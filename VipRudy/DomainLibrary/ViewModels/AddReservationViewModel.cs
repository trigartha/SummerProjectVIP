using DomainLibrary.Framework;
using DomainLibrary.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DomainLibrary.ViewModels
{
    public class AddReservationViewModel : VipRudyViewModelBase
    {
        #region Properties
        public RelayCommand AddReservationCommand { get; set; }
        #endregion
        #region Fields
        /* private readonly IReservationRepository _reservationRepository;
         private readonly ICarRepository _carRepository;
         private readonly IClientRepository _clientRepository;*/
        private ReservationManager _reservationManager;
        private ObservableCollection<Car> _cars;
        private ObservableCollection<Reservation> _reservations;
        private ObservableCollection<Client> _clients;

        private Reservation _currentReservation;
        #endregion
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public AddReservationViewModel(ReservationManager reservationManager)
        {
            //since we work with Unit of work + Repo pattern we can use our Manager :)
            /* this._reservationRepository = reservationRepository;
             this._carRepository = carRepository;
             this._clientRepository = clientRepository;*/
            this._reservationManager = reservationManager;

            //To have the objects ready so we can bind and we can be notified on changes
            Cars = new ObservableCollection<Car>(_reservationManager.FindAllCars());
            Clients = new ObservableCollection<Client>(_reservationManager.FindAllClients());
            Reservations = new ObservableCollection<Reservation>(_reservationManager.FindAllReservations());

            //To manage event handling in the viewmodel
            AddReservationCommand = new RelayCommand(AddReservation, CanAddReservation);
        }
        #endregion
        #region Methods
        /// <summary>
        /// Gets or sets the Cars.
        /// </summary>
        /// <value>The cars.</value>
        public ObservableCollection<Car> Cars
        {
            get
            {
                return _cars;
            }
            set
            {
                if (_cars != value)
                {
                    _cars = value;
                    RaisePropertyChanged(() => Cars);
                }
            }
        }
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
        /// <summary>
        /// Gets or sets the temporary Reservation.
        /// </summary>
        /// <value>The Reservation.</value>
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
        /// <summary>
        /// Adds a Reservation to the list and repo.
        /// </summary>
        private void AddReservation()
        {
            if (CurrentReservation.Client != null) return; // We don't want an empty reservation :)

            if (!Reservations.Contains(CurrentReservation))
                Reservations.Add(CurrentReservation);
            _reservationManager.AddReservation(CurrentReservation);

            CurrentReservation = new Reservation();
        }
        /// <summary>
        /// Check if Reservation was made and can be added
        /// </summary>
        /// <returns>true if created, false if not</returns>
        private bool CanAddReservation()
        {
            return CurrentReservation.Client != null;
        }
        #endregion
    }
}
