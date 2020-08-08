using DomainLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace DomainLibrary.Framework
{
    public class ViewModelLocator
    {
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


    }
}
