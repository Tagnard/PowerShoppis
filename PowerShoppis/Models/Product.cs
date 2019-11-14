using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerShoppis.Models
{
    public class Product
    {
        public int ProductNumber { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string ProductCode { get; set; }
        public string Status { get; set; }
        public string Cubicle { get; set; }
        public float Total { get; set; }
    }
}
