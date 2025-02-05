﻿

using Unity;
using WPFLayer.ViewModels;
using DomainLibrary.Repositories;
using DomainLibrary;
using DataLayer;

namespace WPFLayer.Framework
{
    /// <summary>
    /// Here the DI magic come on.
    /// </summary>
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
           Container.RegisterInstance<ReservationManager>(new ReservationManager(new UnitOfWork(new ReservationContext())));
           //Container.RegisterInstance<ICategoryRepository>(new CategoryRepository("categories"));
            Container.RegisterType<MainViewModel>();
            Container.RegisterType<AddReservationViewModel>();
        }
    }
}
