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
    /// Interaction logic for FindReservationView.xaml
    /// </summary>
    public partial class FindReservationView : Window
    {
        public FindReservationView()
        {
            InitializeComponent();
        }
        private void btn_ReservationItem_Click(object sender, RoutedEventArgs e)
        {
            var showOverviewReservation = new OverviewReservationView();
            showOverviewReservation.DataContext = new OverViewReservationViewModel(Vm.CreateNewOverview());
            showOverviewReservation.Show();
        }
        public FindReservationViewModel Vm
        {
            get
            {
                return (FindReservationViewModel)DataContext;
            }
        }
        
    }
}
