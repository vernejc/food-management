using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Classes
{
    public class Ingredient : IWellness, ITax, ITotal
    {
        public int ID { get; set; }
        public Food Item { get; set; }
        public decimal Quantity { get; set; }
        public string QuantityExpression { get; set; }

        /// <summary>
        /// Applies a wellness discount to the submitted price.
        /// </summary>
        /// <param name="price">The value that will be passed to calculate and substract wellness discount.</param>
        /// <returns>The price that results from applying a wellness discount.</returns>
        public decimal DiscountCalculation(decimal price)
        {
            return price - GetDiscountValue(price);
        }

        /// <summary>
        /// Calculates the wellness discount of a given price.
        /// </summary>
        /// <param name="price">The value that will be passed to calculate the wellness discount value.</param>
        /// <returns>The value of the wellness discount that is going to be applied to the price of an ingredient.</returns>
        /// <remarks>Wellness Discount (-%5 of the total price rounded up to the nearest cent, applies only to organic items)</remarks>
        public decimal GetDiscountValue(decimal price)
        {
            decimal discount = 0;
            // Wellness Discount: applies only to organic items.
            if (Item.IsOrganic)
            {
                discount = price * Constants.WellnessDiscount;
                return Math.Round(discount, 2, MidpointRounding.AwayFromZero);
            }
            else {
                return discount;
            }
        }

        /// <summary>
        /// Calculates the tax value of a given price.
        /// </summary>
        /// <param name="price">The value that will be passed to calculate the price value.</param>
        /// <returns>The value of the tax value that is going to be applied to the price of an ingredient.</returns>
        /// <remarks>Sale Tax (%8.6 of the total price rounded up to the nearest 7 cents, applies to everything except produce)</remarks>
        public decimal GetTaxValue(decimal price)
        {
            decimal taxValue = 0;
            if (Item.Category.ID != (int)Constants.FoodTypeID.Produce)
            {
                taxValue = price * Constants.Tax;
                taxValue = Math.Round((taxValue / 7), 2, MidpointRounding.AwayFromZero) * 7;
                return taxValue;
            }
            else {
                return taxValue;
            }
        }

        /// <summary>
        /// Calculates the total price of the ingredient before taxes and/or wellness discount.
        /// </summary>
        /// <returns>The raw total price of the ingredient.</returns>
        public decimal RawTotalCalculation()
        {
            if (Item != null)
            {
                return Item.UnitaryCost * Quantity;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Applies a tax to the submitted price.
        /// </summary>
        /// <param name="price"></param>
        /// <returns>The price that results from applying taxes.</returns>
        public decimal TaxCalculation(decimal price)
        {
            return price + GetTaxValue(price);
        }

        /// <summary>
        /// Calculates the total price of an ingredient taking into consideration wellness discount(if applies) and tax.
        /// </summary>
        /// <returns>The total price of an ingredient taking into consideration wellness discount(if applies) and tax.</returns>
        public decimal TotalCalculation()
        {
            decimal Total = 0;
            if (Item != null)
            {
                // Total before wellness discount and before taxes.
                Total = RawTotalCalculation();
                // Wellness discount calculation.
                Total = DiscountCalculation(Total);
                // Tax Calculation: applies to everything except produce.
                Total = TaxCalculation(Total);                
            }
            return Total;
        }

        /// <summary>
        /// Method that calculates the sum of all the taxes applied to the ingredient.
        /// </summary>
        /// <returns>The sum of all the taxes applied to the ingredient.</returns>
        public decimal TotalTax()
        {
            decimal totalTax = GetTaxValue(DiscountCalculation(RawTotalCalculation()));
            return totalTax;
        }

        /// <summary>
        /// Method that calculates the sum of all the wellness discounts applied to the ingredient.
        /// </summary>
        /// <returns>The sum of all the wellness discounts applied to the ingredient.</returns>
        public decimal TotalWellnessDiscount()
        {
            // Currently there is only one wellness discount that is applied to the ingredient.
            decimal totalWellnessDiscount = GetDiscountValue(RawTotalCalculation());
            return totalWellnessDiscount;
        }
    }
}
