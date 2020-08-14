using DomainLibrary;
using DomainLibrary.Models;
using DomainLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Repository
{
    

    public class ReservationRepository : IReservationRepository
    {
        #region Properties

        #endregion
        #region Fields
        private ReservationContext _context;
        #endregion
        #region Constructor
        public ReservationRepository(ReservationContext context)
        {
            this._context = context;
        }
        #endregion
        #region Methods
        public void AddReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
        }
        public Reservation Find(int id)
        {
            return _context.Reservations.Find(id);
        }
        public IEnumerable<Reservation> FindAll()
        {
            return _context.Reservations.OrderBy(r => r.ReservationInfo.StartTime).AsEnumerable<Reservation>();
        }
        public IEnumerable<Reservation> FindOnDate(DateTime date)
        {
            return _context.Reservations.Where(r => r.ReservationDate == date).OrderBy(r => r.ReservationDate).AsEnumerable<Reservation>();
        }
        public IEnumerable<Reservation> FindOnClient(Client client)
        {
            return _context.Reservations.Where(r => r.Client.ClientNumber == client.ClientNumber).OrderBy(r => r.ReservationDate).AsEnumerable<Reservation>();
        }
        public IEnumerable<Reservation> FindOnDateAndClient(DateTime date, Client client)
        {
            return _context.Reservations.Where(r => r.Client.ClientNumber == client.ClientNumber&&r.ReservationDate==date).OrderBy(r => r.ReservationDate).AsEnumerable<Reservation>();
        }
        public void DeleteAll()
        {
            _context.Reservations.RemoveRange(_context.Reservations);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        #endregion
    }
}
