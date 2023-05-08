using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Flights.DataAccess
{
    public class FlightContext : DbContext
    {
        protected FlightContext()
        {
        }

        public DbSet<Flight> Flights { get; set; }
    }
}
