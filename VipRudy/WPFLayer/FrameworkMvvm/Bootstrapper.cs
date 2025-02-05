﻿using DataLayer;
using DataLayer.Repository;
using DomainLibrary;
using DomainLibrary.Repositories;
using DomainLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace WPFLayer.FrameworkMvvm
{
    public class Bootstrapper
    {

        public IUnityContainer Container { get; set; }

        public Bootstrapper()
        {
            Container = new UnityContainer();

            ConfigureContainer();
        }

        /// <summary>
        /// We register here every service / interface / viewmodel.
        /// </summary>
        private void ConfigureContainer()
        {
            //TODO: How to acces Datalayer? Circular project referencing - can a view create this? 
            //Container.RegisterInstance<ReservationManager>(new ReservationManager(new UnitOfWork(new ReservationContext())));
            Container.RegisterType<IUnitOfWork, UnitOfWork>();
            Container.RegisterType<MainViewModel>();
            Container.RegisterType<AddReservationViewModel>();
            Container.RegisterType<FindReservationViewModel>();
            Container.RegisterType<OverViewReservationViewModel>();
        }
    }
}
