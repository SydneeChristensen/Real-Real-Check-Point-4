using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    [Table("Instrument")]
    public class Instrument
    {
        [Key]
        [Display(Name = "Instrument ID")]
        public int InstrumentID { get; set; }
        
        [Display(Name = "Instrument Description")]
        public String Desription { get; set; }
        
        [Display(Name = "New or Used")]
        public String Type { get; set; }

        [Display(Name = "Instrument Price")]
        public int Price { get; set; }

        [Display(Name = "Client ID")]
        public int? ClientID { get; set; }
    }
}