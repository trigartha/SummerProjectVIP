using DomainLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Repositories
{
    public interface IReservationRepository
    {
        void AddReservation(Reservation reservation);
        Reservation Find(int id);
        IEnumerable<Reservation> FindAll();
        IEnumerable<Reservation> FindOnDate(DateTime date);
        IEnumerable<Reservation> FindOnClient(Client client);

        void DeleteAll();
        void Save();
    }
}
