using System;

namespace CDBApi.Entities
{
    public class Cdb(double investedAmount, int termInMonths)
    {
        private const double DefaultCDI = 0.009;  // 0,9%
        private const double DefaultTB = 1.08;    // 108%

        public double CDI { get; set; } = DefaultCDI;
        public double TB { get; set; } = DefaultTB;
        public double InvestedAmount { get; set; } = investedAmount;
        public int TermInMonths { get; set; } = termInMonths;

        public double Gross { get; private set; }
        public double GrossYield { get; set; }
        public double Tax { get; private set; }
        public double NetYield { get; set; }
        public double FinalValue { get; private set; }

        public void Calculate()
        {
            Gross = InvestedAmount * Math.Pow(1 + (CDI * TB), TermInMonths);
            Tax = GetTax(TermInMonths);
            GrossYield = Gross - InvestedAmount;
            NetYield = GrossYield * (1 - Tax);
            FinalValue = InvestedAmount + NetYield;
        }

        private static double GetTax(int termInMonths)
        {
            double tax = termInMonths switch
            {
                <= 6 => 0.225,
                <= 12 => 0.20,
                <= 24 => 0.175,
                _ => 0.15
            };

            return tax;
        }
    }
}