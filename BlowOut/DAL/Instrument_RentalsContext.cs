using BlowOut.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlowOut.DAL
{

    public class Instrument_RentalsContext : DbContext
    {
        public Instrument_RentalsContext()
            : base("Instrument_RentalsContext")
        {

        }

        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}