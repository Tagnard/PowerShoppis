using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace PowerShoppis.Models
{
    public class Reservation
    { 
        public int Nr { get; set; }
        public string Cubicle { get; set; }
        public string Customer { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
