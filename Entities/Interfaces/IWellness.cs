using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Interfaces
{
    public interface IWellness
    {
        decimal DiscountCalculation(decimal price);
        decimal GetDiscountValue(decimal price);
    }
}
