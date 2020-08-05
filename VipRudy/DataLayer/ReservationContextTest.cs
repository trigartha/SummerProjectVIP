using DomainLibrary;
using DomainLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataLayer
{
    public class ReservationContextTest : ReservationContext
    {
        #region Properties
        public DbSet<Reservation> ReservationsTest { get; set; }
        public DbSet<Client> ClientsTest { get; set; }
        public DbSet<Car> CasrTest { get; set; }
        #endregion
        #region Fields
        #endregion
        #region Constructor
        public ReservationContextTest(bool keepExisting = false) : base("Test")
        {
            if (keepExisting)
            {
                Database.EnsureCreated();
            }
            else
            {
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }
        #endregion
        #region Methods

        #endregion
    }
}
