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
        public DbSet<Car> Cars { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Discount> Discounts { get; set; }
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
            IConfigurationBuilder builder = new ConfigurationBuilder();
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
            /* modelBuilder.Entity<Reservation>()
              .HasOne(r => r.Client)
              .WithMany(c => c.Reservations);
            */

            /* modelBuilder.Entity<Client>()
                 .Property(c=>c.ClientNumber)
                 .ValueGeneratedNever();
            */
            //modelBuilder.Entity<Car>().HasMany(c => c.Price).WithOne();
            /*modelBuilder.Entity<Car>().OwnsMany(c => c.Price, a =>
              {
                  a.WithOwner().HasForeignKey("CarId");
                  a.Property<int>("Id");
                  a.HasKey("Id");
              });*/
            /*modelBuilder.Entity<Reservation>()
                .HasRequired(r=>r.Car)
                .HasForeignKey(r => r.CarId);
            modelBuilder.Entity<Reservation>()
                .HasKey(r => r.ClientId);
            modelBuilder.Entity<Reservation>()
               .HasKey(r => r.ReservationInfoId);*/
            modelBuilder.Entity<Client>().OwnsOne(c => c.Address);
            modelBuilder.Entity<ReservationInfo>().OwnsOne(c => c.Address);
            modelBuilder.Entity<Client>()
               .HasKey(c => c.ClientNumber)
               .HasName("PrimaryKey_ClientId"); ;
            modelBuilder.Entity<Client>()
                .Property(c => c.ClientCategory)
                .HasConversion<string>();
           /* modelBuilder.Entity<Car>()
               .Property(c => c.Availability)
               .HasConversion<string>();*/
            modelBuilder.Entity<Price>()
               .Property(c => c.Arrangement)
               .HasConversion<string>();
        }
        #endregion
    }
}
