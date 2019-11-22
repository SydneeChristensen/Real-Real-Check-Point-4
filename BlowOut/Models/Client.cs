using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    [Table("Client")]
    public class Client
    {
        [Key]
        [Required]
        [Display(Name = "Client ID")]
        public int ClientID { get; set; }

        [Required]
        [Display(Name = "Client First Name")]
        public String ClientFirstName { get; set; }

        [Required]
        [Display(Name = "Client Last Name")]
        public String ClientLastName { get; set; }

        [Required]
        [Display(Name = "Address")]
        public String Address { get; set; }

        [Required]
        [Display(Name = "City")]
        public String City { get; set; }

        [Required]
        [Display(Name = "State")]
        public String State { get; set; }

        [Required]
        [Display(Name = "Zip")]
        [StringLength(5,MinimumLength = 5, ErrorMessage = "Zip ust be 5 digits")]
        public string Zip { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public String Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone")]
        public String Phone { get; set; }
    }
}
