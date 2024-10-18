using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CDBApi.Entities;
using CDBApi.Models;
using CDBApi.Services;
using CDBApi.Validators;

namespace CdbApi.Services
{
    public class CdbService(IValidator<CdbInvestmentRequest> validator) : ICdbService
    {

        private readonly IValidator<CdbInvestmentRequest> _validator = validator;

        public CdbInvestmentResponse Calculate(CdbInvestmentRequest request)
        {
            _validator.Validate(request);

            Cdb cdb = new((double)request.InvestedAmount!, (int)request.TermInMonths!);
            cdb.Calculate();

            return new CdbInvestmentResponse(cdb.Gross, cdb.GrossYield, cdb.Tax, cdb.NetYield, cdb.FinalValue);
        }
    }
}