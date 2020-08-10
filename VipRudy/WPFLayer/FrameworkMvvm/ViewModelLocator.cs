using DomainLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using ServiceLocation;

namespace WPFLayer.FrameworkMvvm
{
    public class ViewModelLocator
    {
        public const string ReservationPageKey = "AddReservationPage";

        private static Bootstrapper _bootStrapper;

        static ViewModelLocator()
        {
            if (_bootStrapper == null)
                _bootStrapper = new Bootstrapper();
        }

        public MainViewModel Main
        {
            get { return _bootStrapper.Container.Resolve<MainViewModel>(); }
        }
        public AddReservationViewModel ReservationViewModel
        {
            get { return _bootStrapper.Container.Resolve<AddReservationViewModel>(); }
        }
        //public INavigationService Navigation
        //{
        //    get { return _bootStrapper.Container.Resolve<INavigationService>(); }
        //}


    }
}
