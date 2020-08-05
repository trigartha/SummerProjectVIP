using DomainLibrary;
using DomainLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public Client Find(int id)
        {
            return _context.Clients.Find(id);
        }
        public IEnumerable<Client> FindAll()
        {
            return _context.Clients.OrderBy(c => c.ClientNumber).AsEnumerable<Client>();
        }
        public void DeleteAll()
        {
            _context.Clients.RemoveRange(_context.Clients);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        #endregion
    }
}
