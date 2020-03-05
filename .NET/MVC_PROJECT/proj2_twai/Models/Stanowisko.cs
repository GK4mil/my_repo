using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proj2_twai.Models
{
    public class Stanowisko
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwe")]
        public String NAZWA { get; set; }

        [Required(ErrorMessage = "Proszę podać skrocona nazwe.")]
        public String SHORT { get; set; }
        
    }
}