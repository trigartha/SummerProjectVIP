
using DomainLibrary;

using DomainLibrary.Models;
using DomainLibrary.Repositories;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using WPFLayer.Views;

namespace WPFLayer.ViewModels
{
    public class MainViewModel:VipRudyViewModelBase
    {

        #region Properties
        public RelayCommand NewReservationViewCommand { get; set; }
        #endregion
        #region Fields
        
        #endregion
        #region Constructor
        public MainViewModel()
        {
            NewReservationViewCommand = new RelayCommand(OpenNewReservationView);
        }
        #endregion
        #region Methods
        private void OpenNewReservationView()
        {
            var newResView = new Views.AddReservationView();
            newResView.ShowDialog();
        }
        #endregion
    }
}
