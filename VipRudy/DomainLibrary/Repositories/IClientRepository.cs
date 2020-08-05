using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Repositories
{
    public interface IClientRepository
    {
        void AddClient(Client client);
        Client Find(int id);
        IEnumerable<Client> FindAll();
        void DeleteAll();
        void Save();
    }
}
