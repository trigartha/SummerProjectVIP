using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Models
{
    public class Car
    {
        #region Properties
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Colour { get; set; }
        public int CarId { get; set; }
        public Price Price { get; set; }
        #endregion
        #region Constructor
        public Car() { }
        public Car(string brand, string model, string colour)
        {
            this.Brand = brand;
            this.Model = model;
            this.Colour = colour;
        }
        #endregion
    }
}
