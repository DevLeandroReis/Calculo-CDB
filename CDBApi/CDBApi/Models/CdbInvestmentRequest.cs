using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CDBApi.Models
{
    public class CdbInvestmentRequest
    {
        public double? InvestedAmount { get; set; }
        public int? TermInMonths  { get; set; }
    }
}