using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using CDBApi.Models;
using CDBApi.Validators;

namespace CDBApi.Validators
{
    public class CdbInvestmentRequestValidator : IValidator<CdbInvestmentRequest>
    {
        public void Validate(CdbInvestmentRequest request)
        {
            var errors = new List<string>();

            if (request.InvestedAmount == null)
            {
                errors.Add("Invested amount is required.");
            }
            else if (request.InvestedAmount <= 0)
            {
                errors.Add("Invested amount must be positive.");
            }

            if (request.TermInMonths == null)
            {
                errors.Add("Term is required.");
            }
            else if (request.TermInMonths <= 1)
            {
                errors.Add("Term must be greater than 1 month.");
            }

            if (errors.Count > 0)
            {
                throw new ArgumentException(string.Join(" | ", errors));
            }
        }
    }
}