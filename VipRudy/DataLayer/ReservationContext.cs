﻿using DomainLibrary;
using DomainLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.IO;
using System.Text;

namespace DataLayer
{
    public class ReservationContext :DbContext
    {
        #region Properties
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Client> Clients { get; set; }
        #endregion
        #region Fields
        private string _connectionString;
        #endregion
        #region Constructor
        public ReservationContext() { }
        public ReservationContext(string db = "Reservation") : base()
        {
            SetConnectionString(db);
        }
        #endregion
        #region Methods
        private void SetConnectionString(string db = "Reservation")
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            var configuration = builder.Build();
            switch (db)
            {
                case "Reservation":
                    _connectionString = configuration.GetConnectionString("ReservationSQLconnection").ToString();
                    break;
                case "Test":
                    _connectionString = configuration.GetConnectionString("TestSQLconnection").ToString();
                    break;
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_connectionString == null)
            {
                SetConnectionString();
            }
            optionsBuilder.UseSqlServer(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasKey(c=> c.ClientNumber)
                .HasName("PrimaryKey_ClientId");
        }
        #endregion
    }
}
