using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Repositories
{
    public interface IClientRepository
    {
        void AddClient(Client client);
        void DeleteAll();
    }
}
