using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    public class InstrumentClients
    {
        //public IEnumerable<Instrument> Instruments{ get; set; }
        //public IEnumerable<Client> Clients { get; set; }
        public Instrument instrument { get; set; }
        public Client client { get; set; }

    }
}


