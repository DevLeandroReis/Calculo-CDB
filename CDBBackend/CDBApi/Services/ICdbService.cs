using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CDBApi.Models;

namespace CDBApi.Services
{
    public interface ICdbService
    {
        public CdbInvestmentResponse Calculate(CdbInvestmentRequest request);
    }
}