using DomainLibrary.Framework;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.ViewModels
{
    public class MainViewModel : VipRudyViewModelBase
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
            //var newResView = new Views.AddReservationView();
            //newResView.ShowDialog();
        }

        #endregion
    }
}
