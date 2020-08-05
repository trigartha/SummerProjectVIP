using System;

namespace DomainLibrary
{
    public class ReservationManager
    {
        #region Properties

        #endregion
        #region Fields
        private IUnitOfWork _uow;
        #endregion
        #region Constructor
        public ReservationManager(IUnitOfWork uow)
        {
            this._uow = uow;
        }
        #endregion
        #region Methods
        public void AddClient(Client client)
        {
            _uow.Clients.AddClient(client);
            _uow.Complete();
        }
        public void DeleteAllClients()
        {
            _uow.Clients.DeleteAll();
            _uow.Complete();
        }
        #endregion
    }
}
