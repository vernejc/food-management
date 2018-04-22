using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Classes
{
    public class Recipe : ITotal
    {
        public int ID { get; set; }
        public List<Ingredient> Items { get; set; }

        /// <summary>
        /// Calculates the total price of all the ingredients before taxes and/or wellness discount.
        /// </summary>
        /// <returns>The total price of all the ingredients before taxes and/or wellness discount.</returns>
        public decimal RawTotalCalculation()
        {
            decimal Total = 0;
            foreach (Ingredient Item in Items)
            {
                Total = Total + Item.RawTotalCalculation();
            }
            return Math.Round((Total / 7), 2, MidpointRounding.AwayFromZero) * 7; ;
        }

        /// <summary>
        /// Calculates the total price of all the ingredients taking into consideration wellness discount(if applies) and tax.
        /// </summary>
        /// <returns>The total price of all the ingredients taking into consideration wellness discount(if applies) and tax.</returns>
        public decimal TotalCalculation()
        {
            decimal Total = 0;
            foreach (Ingredient Item in Items)
            {
                Total = Total + Item.TotalCalculation();
            }
            return Math.Round((Total / 7), 2, MidpointRounding.AwayFromZero) * 7;
        }

        /// <summary>
        /// Method that calculates the sum of all the taxes applied to all the ingredients.
        /// </summary>
        /// <returns>The sum of all the taxes applied to all the ingredients.</returns>
        public decimal TotalTax()
        {
            decimal Total = 0;
            foreach (Ingredient Item in Items)
            {
                // Because tax value is calculated after wellness discount, if it applies.
                Total = Total + Item.GetTaxValue(Item.DiscountCalculation(Item.RawTotalCalculation()));
            }
            return Total;
        }

        /// <summary>
        /// Method that calculates the sum of all the wellness discounts applied to all the ingredient.
        /// </summary>
        /// <returns>The sum of all the wellness discounts applied to all the ingredients.</returns>
        public decimal TotalWellnessDiscount()
        {
            decimal Total = 0;
            foreach (Ingredient Item in Items)
            {
                Total = Total + Item.GetDiscountValue(Item.RawTotalCalculation());
            }
            return Total;
        }
    }
}
