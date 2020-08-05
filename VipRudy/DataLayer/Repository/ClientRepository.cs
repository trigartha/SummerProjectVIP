using DomainLibrary;
using DomainLibrary.Repositories;
using System;

namespace DataLayer.Repository
{
   

    public class ClientRepository : IClientRepository
    {
        #region Properties

        #endregion
        #region Fields
        private ReservationContext _context;
        #endregion
        #region Constructor
        public ClientRepository(ReservationContext context)
        {
            this._context = context;
        }
        #endregion
        #region Methods
        public void AddClient(Client client)
        {
            _context.Clients.Add(client);
        }
        public void DeleteAll()
        {
            _context.Clients.RemoveRange(_context.Clients);
        }
        #endregion
    }
}
