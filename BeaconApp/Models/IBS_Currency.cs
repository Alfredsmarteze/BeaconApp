using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeaconApp.Models
{
    public class IBS_Currency
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Please fill this field"), DisplayName("Currency ID")]
        public string ID_Currency { get; set; }
        [Required(ErrorMessage = "Please fill this field")]
        public string Currency { get; set; }
        [Required]
        public string Unit { get; set; }
    }
}
