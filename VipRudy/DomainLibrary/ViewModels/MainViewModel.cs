using DomainLibrary.Framework;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using GalaSoft.MvvmLight.Command;

namespace DomainLibrary.ViewModels
{
    public class MainViewModel : VipRudyViewModelBase
    {

        #region Properties
        
       
        #endregion
        #region Fields
        
        private ReservationManager _reservationManager;
        //private RelayCommand<AddReservationViewModel> _newReservationViewCommand;
        #endregion
        #region Constructor
        public MainViewModel( ReservationManager reservationManager)
        { 
            
            _reservationManager = reservationManager;
            //WireCommands();
        }
        #endregion
        #region Methods
       
      
       
        #endregion
    }
}
