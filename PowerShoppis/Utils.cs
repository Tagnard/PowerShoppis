using SAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerShoppis
{
    public static class Utils
    {
        public static string StatusFromBool(bool value)
        {
            if (value)
                return "Sold";
            else
                return "New";
        }

        public static float SumFromSales(List<Sale> sales)
        {
            float total = 0;
            foreach (Sale s in sales)
            {
                total += s.Amount;
            }
            return total;
        }
    }
}
