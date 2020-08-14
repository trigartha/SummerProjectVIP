using DataLayer;
using DomainLibrary;
using DomainLibrary.Framework;
using DomainLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFLayer.Views;

namespace WPFLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ReservationManager _reservationManager;
        public MainWindow()
        {
            _reservationManager = new ReservationManager(new UnitOfWork(new ReservationContext("Reservation")));
            InitializeComponent();
           
        }

        private void BtnAddReservation_Click(object sender, RoutedEventArgs e)
        {
           
            var showAddReservation = new AddReservationView();
            showAddReservation.DataContext = new AddReservationViewModel(_reservationManager);
            showAddReservation.Show();
        }

        private void BtnFindReservation_Click(object sender, RoutedEventArgs e)
        {

            var showFindReservation = new FindReservationView();
            showFindReservation.DataContext = new FindReservationViewModel(_reservationManager);
            showFindReservation.Show();
        }
    }
}
