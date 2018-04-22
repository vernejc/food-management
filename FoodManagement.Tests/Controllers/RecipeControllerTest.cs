using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodManagement;
using FoodManagement.Controllers;
using Entities.Classes;
using FoodManagement.Tests.Models;

namespace FoodManagement.Tests.Controllers
{
    [TestClass]
    public class RecipeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            RecipeController controller = new RecipeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PrintFoodCount() {
            Console.Write($"Number of food elements: {(Constants.Foods).Count()}");
        }

        [TestMethod]
        public void PrintFoodInformation() {
            foreach (Food food in Constants.Foods)
            {
                Console.WriteLine($"Food {food.ID}: {food.DisplayName} costs ${food.UnitaryCost.ToString()}");
            }
        }

        [TestMethod]
        public void PrintRawTotal()
        {
            foreach (Recipe recipe in Constants.Recipes)
            {
                Console.WriteLine($"Recipe {recipe.ID} raw total cost is ${recipe.RawTotalCalculation().ToString()}");
            }
        }

        [TestMethod]
        public void PrintTotal()
        {
            foreach (Recipe recipe in Constants.Recipes)
            {
                Console.WriteLine($"Recipe {recipe.ID} total cost(after wellness discount and tax) is ${recipe.TotalCalculation().ToString()}");
            }
        }

        [TestMethod]
        public void PrintTotalWellnessDiscount()
        {
            foreach (Recipe recipe in Constants.Recipes)
            {
                Console.WriteLine($"Recipe {recipe.ID} total wellness discount is ${recipe.TotalWellnessDiscount().ToString()}");
            }
        }

        [TestMethod]
        public void PrintEachWellnessDiscount()
        {
            foreach (Recipe recipe in Constants.Recipes)
            {
                Console.WriteLine($"Recipe {recipe.ID} total wellness discount is ${recipe.TotalWellnessDiscount().ToString()}");
                foreach (Ingredient ingredient in recipe.Items)
                {
                    Console.WriteLine($"Ingredient {ingredient.ID} wellness discount is ${ingredient.GetDiscountValue(ingredient.RawTotalCalculation()).ToString()} for total ${ingredient.RawTotalCalculation().ToString()}");
                }
                Console.WriteLine("");
            }
        }

        [TestMethod]
        public void PrintTotalTax()
        {
            foreach (Recipe recipe in Constants.Recipes)
            {
                Console.WriteLine($"Recipe {recipe.ID} total tax is ${recipe.TotalTax().ToString()}");
            }
        }

        [TestMethod]
        public void PrintEachTax()
        {
            foreach (Recipe recipe in Constants.Recipes)
            {
                Console.WriteLine($"Recipe {recipe.ID} total tax is ${recipe.TotalTax().ToString()}");
                foreach (Ingredient ingredient in recipe.Items)
                {
                    Console.WriteLine($"Ingredient {ingredient.ID} tax is ${ingredient.GetTaxValue(ingredient.DiscountCalculation(ingredient.RawTotalCalculation())).ToString()} for total ${ingredient.DiscountCalculation(ingredient.RawTotalCalculation()).ToString()} (wellness discount included)");
                }
                Console.WriteLine("");
            }
        }
    }
}
