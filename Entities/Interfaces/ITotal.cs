using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Interfaces
{
    public interface ITotal
    {
        decimal TotalCalculation();
        decimal RawTotalCalculation();
        decimal TotalWellnessDiscount();
        decimal TotalTax();
    }
}
