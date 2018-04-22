using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Interfaces
{
    public interface ITax
    {
        decimal TaxCalculation(decimal price);
        decimal GetTaxValue(decimal price);
    }
}
