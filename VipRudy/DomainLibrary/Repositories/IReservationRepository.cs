using DomainLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Repositories
{
    public interface IReservationRepository
    {
        void AddReservation(Reservation reservation);
    }
}
