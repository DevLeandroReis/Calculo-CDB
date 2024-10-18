using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDBApi.Models
{
    public class CdbInvestmentResponse(double? gross = null, double? grossYield = null, double? tax = null, double? netYield = null, double? finalValue = null)
    {
        public double? Gross { get; set; } = gross;
        public double? Tax { get; set; } = tax;
        public double? GrossYield { get; set; } = grossYield;
        public double? NetYield  { get; set; } = netYield;
        public double? FinalValue { get; set; } = finalValue;
    }
}