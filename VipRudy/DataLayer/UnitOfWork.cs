using DataLayer.Repository;
using DomainLibrary;
using DomainLibrary.Repositories;
using System;

namespace DataLayer
{
   

    public class UnitOfWork : IUnitOfWork
    {
        #region Properties
        public IClientRepository Clients { get; set; }
        public IReservationRepository Reservations { get; set; }
        public ICarRepository Cars { get; set; }
        #endregion
        #region Fields
        private ReservationContext _context;
        #endregion
        #region Constructor
        public UnitOfWork(ReservationContext context)
        {
            this._context = context;
            this.Clients = new ClientRepository(context);
            this.Reservations = new ReservationRepository(context);
            this.Cars = new CarRepository(context);
        }
        #endregion
        #region Methods
        public int Complete()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception ex)
            //TODO : SqlExceptions
            {
                throw;
            }
        }

        public void Dispose()
        {
            _context.Dispose(); ;
        }
    }
    #endregion
}

