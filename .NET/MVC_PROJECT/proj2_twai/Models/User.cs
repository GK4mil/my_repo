using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace proj2_twai.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Proszę podać swoje imię")]
        public String IMIE { get; set; }

        [Required(ErrorMessage = "Proszę podać swoje nazwisko.")]
        public String NAZWISKO { get; set; }

        [Required(ErrorMessage = "Proszę podać wiek.")]
        [Range(0,200,ErrorMessage="Wiek nie może być wartością ujemna")]
        public int WIEK { get; set; }

       
    }
}