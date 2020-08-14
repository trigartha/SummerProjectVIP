using DataLayer;
using DomainLibrary;
using DomainLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFLayer.Views
{
    /// <summary>
    /// Interaction logic for AddReservationView.xaml
    /// </summary>
    public partial class AddReservationView : Window
    {
        private ReservationManager _reservationManager;
        public AddReservationView()
        {
            _reservationManager = new ReservationManager(new UnitOfWork(new ReservationContext("Reservation")));
            InitializeComponent();
        }

        private void btnShowOverview_Click(object sender, RoutedEventArgs e)
        {
            var showOverviewReservation = new OverviewReservationView();
            showOverviewReservation.DataContext = new OverViewReservationViewModel(Vm.CreateNewOverview());
            showOverviewReservation.Show();
        }
        public AddReservationViewModel Vm
        {
            get
            {
                return (AddReservationViewModel)DataContext;
            }
        }

        private void btnAddReservationPage_Click(object sender, RoutedEventArgs e)
        {
            Vm.CreateNewOverview();
            _reservationManager.AddReservation(Vm.CurrentReservation);
        }
    }
}
