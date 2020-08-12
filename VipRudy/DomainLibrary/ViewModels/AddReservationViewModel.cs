using DomainLibrary.Enums;
using DomainLibrary.Framework;
using DomainLibrary.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace DomainLibrary.ViewModels
{
    public class AddReservationViewModel : VipRudyViewModelBase
    {
        #region Properties
        public RelayCommand AddReservationCommand { get; private set; }
        public RelayCommand CreateOverviewCommand { get; private set; }
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
        private ReservationOverview _reservationOverview;
        private Client _currentClient;
        private Car _currentCar;
        private ReservationInfo _reservationInfo;
        private Address _currentAddres;
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

            CurrentReservation = new Reservation();
            ReservationInfo = new ReservationInfo();
            CurrentReservationOverview = new ReservationOverview();
            Address = new Address();
            //To manage event handling in the viewmodel
            WireCommands();

        }
        #endregion
        #region Methods
        private void WireCommands()
        {
            AddReservationCommand = new RelayCommand(AddReservation);
            CreateOverviewCommand = new RelayCommand(CreateOverview);
        }
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
        /// Enables add reservation command if reservation is correctly made
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
                    //AddReservationCommand.IsEnabled = CanAddReservation();
                }
            }
        }
        public ReservationInfo ReservationInfo
        {
            get
            {
                return _reservationInfo;
            }
            set
            {
                if (_reservationInfo != value)
                {
                    _reservationInfo = value;
                    RaisePropertyChanged(() => ReservationInfo);
                }
            }
        }
        public Address Address
        {
            get
            {
                return _currentAddres;
            }
            set
            {
                if (_currentAddres != value)
                {
                    _currentAddres = value;
                    RaisePropertyChanged(() => Address);
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
        public Car CurrentCar
        {
            get
            {
                return _currentCar;
            }
            set
            {
                if (_currentCar != value)
                {
                    _currentCar = value;
                    RaisePropertyChanged(() => CurrentCar);

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
        public List<string> Hours
        {
            get
            {
                List<string> hours = new List<string>();
                for (int i = 1; i < 25; i++)
                {
                    hours.Add(i.ToString());
                }
                return hours;
            }

        }
        public string Streetname
        {
            get { return _currentAddres.Streetname; }
            set
            {
                if (_currentAddres.Streetname != value)
                {
                    _currentAddres.Streetname = value;
                    RaisePropertyChanged(() => Streetname);
                }
            }
        }
        public string HouseNumber
        {
            get { return _currentAddres.HouseNumber; }
            set
            {
                if (_currentAddres.HouseNumber != value)
                {
                    _currentAddres.HouseNumber = value;
                    RaisePropertyChanged(() => HouseNumber);
                }
            }
        }
        public string City
        {
            get { return _currentAddres.City; }
            set
            {
                if (_currentAddres.City != value)
                {
                    _currentAddres.City = value;
                    RaisePropertyChanged(() => City);
                }
            }
        }
        public Location StartLocation
        {
            get { return _reservationInfo.StartLocation; }
            set
            {
                if (_reservationInfo.StartLocation != value)
                {
                    _reservationInfo.StartLocation = value;
                    RaisePropertyChanged(() => StartLocation);
                }
            }
        }
        public Location EndLocation
        {
            get { return _reservationInfo.EndLocation; }
            set
            {
                if (_reservationInfo.EndLocation != value)
                {
                    _reservationInfo.EndLocation = value;
                    RaisePropertyChanged(() => EndLocation);
                }
            }
        }
        public Arrangement Arrangement
        {
            get { return _reservationInfo.Arrangement; }
            set
            {
                if (_reservationInfo.Arrangement != value)
                {
                    _reservationInfo.Arrangement = value;
                    RaisePropertyChanged(() => Arrangement);
                   this.Cars = new ObservableCollection<Car>(_reservationManager.FindAllCarsOnArrangement(Arrangement).ToList());
                   RaisePropertyChanged(() => Cars);
                }
            }
        }
        public DateTime StartTime
        {
            get { return _reservationInfo.StartTime; }
            set
            {
                if (_reservationInfo.StartTime != value)
                {
                    _reservationInfo.StartTime = value;
                    RaisePropertyChanged(() => StartTime);
                }
            }
        }
        public DateTime EndTime
        {
            get { return _reservationInfo.EndTime; }
            set
            {
                if (_reservationInfo.EndTime != value)
                {
                    _reservationInfo.EndTime = value;
                    RaisePropertyChanged(() => EndTime);
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
        private void CreateOverview()
        {
            CreateReservationInfo();
            var reservation = new Reservation(CurrentClient, CurrentCar, ReservationInfo);
            this.CurrentReservationOverview = _reservationManager.CreateOverview(reservation);
        }
        private void CreateReservationInfo()
        {
            var reservationInfo = new ReservationInfo(StartLocation, EndLocation, StartTime, Arrangement, EndTime,Address);
            this.ReservationInfo = reservationInfo;
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
