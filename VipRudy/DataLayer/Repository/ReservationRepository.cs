using DomainLibrary.Models;
using DomainLibrary.Repositories;
using System;

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
        #endregion
    }
}
