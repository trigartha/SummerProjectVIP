using DomainLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary
{
    public interface IUnitOfWork
    {
        IClientRepository Clients { get; set; }
        IReservationRepository Reservations { get; set; }

        ICarRepository Cars { get; set; }
        IDiscountRepository Discounts { get; set; }
        int Complete();
        void Dispose();
    }
}
