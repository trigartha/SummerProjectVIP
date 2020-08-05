using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Models
{
    public class DomainException :Exception
    {
        public DomainException(string message) : base(message)
        {
        }
    }
}
