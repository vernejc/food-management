using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Classes
{
    public static class Constants
    {
        public const decimal WellnessDiscount = 0.05m;
        public const decimal Tax = 0.086m;

        public enum FoodTypeID
        {
            Produce = 0,
            MeatOrPoultry = 1,
            Pantry = 2
        }

        public enum MeasureID
        {
            Each = 0,
            Cup = 1,
            Slice = 2,
            Ounce = 3,
            Teaspoon = 4
        }

        public enum FoodID {
            OrganicGarlic =  0,
            Lemon = 1,
            Corn = 2,
            ChickenBreast = 3,
            Bacon = 4,
            Pasta = 5,
            OrganicOliveOil = 6,
            Vinegar = 7,
            Salt = 8,
            Pepper = 9
        }

        // ****************************************************************************************************************
        // In a real scenario all this lists come from database and their structure is built and/or calculated in the service layer.
        // ****************************************************************************************************************

        /// <summary>
        /// List of food categories listed in the coding sample.
        /// </summary>
        public static List<FoodType> Category = new List<FoodType>()
        {
            new FoodType()
            {
                ID = (int)FoodTypeID.Produce,
                Description = "Produce",
                DisplayName = "Produce"
            },
            new FoodType()
            {
                ID = (int)FoodTypeID.MeatOrPoultry,
                Description = "Meat and poultry",
                DisplayName = "Meat/poultry"
            },
            new FoodType()
            {
                ID = (int)FoodTypeID.Pantry,
                Description = "Pantry",
                DisplayName = "Pantry"
            }
        };

        /// <summary>
        /// List of food measures listed in the coding sample.
        /// </summary>
        public static List<Measure> Unit = new List<Measure>()
        {
            new Measure()
            {
                ID = (int)MeasureID.Each,
                Description = "Each",
                DisplayName = "",
                Abbreviation = "ea"
            },
            new Measure()
            {
                ID = (int)MeasureID.Cup,
                Description = "Cup",
                DisplayName = "cup(s) of",
                Abbreviation = ""
            },
            new Measure()
            {
                ID = (int)MeasureID.Slice,
                Description = "Slice",
                DisplayName = "slice(s) of",
                Abbreviation = ""
            },
            new Measure()
            {
                ID = (int)MeasureID.Ounce,
                Description = "Ounce",
                DisplayName = "ounce(s) of",
                Abbreviation = "oz"
            },
            new Measure()
            {
                ID = (int)MeasureID.Teaspoon,
                Description = "Teaspoon",
                DisplayName = "teaspoon(s) of",
                Abbreviation = ""
            }
        };

        /// <summary>
        /// List of food listed in the coding sample.
        /// </summary>
        public static List<Food> Foods = new List<Food>()
        {
            new Food()
            {
                ID = 1,
                Category = Category[(int)FoodTypeID.Produce],
                Description = "Organic Garlic",
                DisplayName = "clove of organic garlic",
                IsOrganic = true,
                Unit = Unit[(int)MeasureID.Each],
                UnitaryCost = 0.67m,
            },
            new Food()
            {
                ID = 2,
                Category = Category[(int)FoodTypeID.Produce],
                Description = "Lemon",
                DisplayName = "lemon",
                IsOrganic = false,
                Unit = Unit[(int)MeasureID.Each],
                UnitaryCost = 2.03m,
            },
            new Food()
            {
                ID = 3,
                Category = Category[(int)FoodTypeID.Produce],
                Description = "Corn",
                DisplayName = "corn",
                IsOrganic = false,
                Unit = Unit[(int)MeasureID.Cup],
                UnitaryCost = 0.87m,
            },
            new Food()
            {
                ID = 4,
                Category = Category[(int)FoodTypeID.MeatOrPoultry],
                Description = "Chicken Breast",
                DisplayName = "chicken breast",
                IsOrganic = false,
                Unit = Unit[(int)MeasureID.Each],
                UnitaryCost = 2.19m,
            },
            new Food()
            {
                ID = 5,
                Category = Category[(int)FoodTypeID.MeatOrPoultry],
                Description = "Bacon",
                DisplayName = "bacon",
                IsOrganic = false,
                Unit = Unit[(int)MeasureID.Each],
                UnitaryCost = 0.24m,
            },
            new Food()
            {
                ID = 6,
                Category = Category[(int)FoodTypeID.Pantry],
                Description = "Pasta",
                DisplayName = "pasta",
                IsOrganic = false,
                Unit = Unit[(int)MeasureID.Ounce],
                UnitaryCost = 0.31m,
            },
            new Food()
            {
                ID = 7,
                Category = Category[(int)FoodTypeID.Pantry],
                Description = "Organic Olive Oil",
                DisplayName = "organic olive oil",
                IsOrganic = true,
                Unit = Unit[(int)MeasureID.Cup],
                UnitaryCost = 1.92m,
            },
            new Food()
            {
                ID = 8,
                Category = Category[(int)FoodTypeID.Pantry],
                Description = "Vinegar",
                DisplayName = "vinegar",
                IsOrganic = false,
                Unit = Unit[(int)MeasureID.Cup],
                UnitaryCost = 1.26m,
            },
            new Food()
            {
                ID = 9,
                Category = Category[(int)FoodTypeID.Pantry],
                Description = "Salt",
                DisplayName = "salt",
                IsOrganic = false,
                Unit = Unit[(int)MeasureID.Teaspoon],
                UnitaryCost = 0.16m,
            },
            new Food()
            {
                ID = 10,
                Category = Category[(int)FoodTypeID.Pantry],
                Description = "Pepper",
                DisplayName = "pepper",
                IsOrganic = false,
                Unit = Unit[(int)MeasureID.Teaspoon],
                UnitaryCost = 0.17m,
            }
        };

        public static List<Recipe> Recipes = new List<Recipe>()
        {
            new Recipe()
            {
                ID = 1,
                Items = new List<Ingredient>()
                {
                    new Ingredient()
                    {
                        ID = 1,
                        Item = Foods[(int)FoodID.OrganicGarlic],
                        Quantity = 1,
                        QuantityExpression = "1"
                    },
                    new Ingredient()
                    {
                        ID = 2,
                        Item =Foods[(int)FoodID.Lemon],
                        Quantity = 1,
                        QuantityExpression = "1"
                    },
                    new Ingredient()
                    {
                        ID = 3,
                        Item = Foods[(int)FoodID.OrganicOliveOil],
                        Quantity = (decimal)3/4,
                        QuantityExpression = "3/4"
                    },
                    new Ingredient()
                    {
                        ID = 4,
                        Item = Foods[(int)FoodID.Salt],
                        Quantity = (decimal)3/4,
                        QuantityExpression = "3/4"
                    },
                    new Ingredient()
                    {
                        ID = 5,
                        Item = Foods[(int)FoodID.Pepper],
                        Quantity = (decimal)1/2,
                        QuantityExpression = "1/2"
                    }
                },
            },
            new Recipe()
            {
                ID = 2,
                Items = new List<Ingredient>()
                {
                    new Ingredient()
                    {
                        ID = 1,
                        Item = Foods[(int)FoodID.OrganicGarlic],
                        Quantity = 1,
                        QuantityExpression = "1"
                    },
                    new Ingredient()
                    {
                        ID = 2,
                        Item =Foods[(int)FoodID.ChickenBreast],
                        Quantity = 4,
                        QuantityExpression = "4"
                    },
                    new Ingredient()
                    {
                        ID = 3,
                        Item = Foods[(int)FoodID.OrganicOliveOil],
                        Quantity = (decimal)1/2,
                        QuantityExpression = "1/2"
                    },
                    new Ingredient()
                    {
                        ID = 4,
                        Item = Foods[(int)FoodID.Vinegar],
                        Quantity = (decimal)1/2,
                        QuantityExpression = "1/2"
                    }
                },
            },
            new Recipe()
            {
                ID = 3,
                Items = new List<Ingredient>()
                {
                    new Ingredient()
                    {
                        ID = 1,
                        Item = Foods[(int)FoodID.OrganicGarlic],
                        Quantity = 1,
                        QuantityExpression = "1"
                    },
                    new Ingredient()
                    {
                        ID = 2,
                        Item =Foods[(int)FoodID.Corn],
                        Quantity = 4,
                        QuantityExpression = "4"
                    },
                    new Ingredient()
                    {
                        ID = 3,
                        Item = Foods[(int)FoodID.Bacon],
                        Quantity = 4,
                        QuantityExpression = "4"
                    },
                    new Ingredient()
                    {
                        ID = 4,
                        Item = Foods[(int)FoodID.Pasta],
                        Quantity = 8,
                        QuantityExpression = "8"
                    },
                    new Ingredient()
                    {
                        ID = 5,
                        Item = Foods[(int)FoodID.OrganicOliveOil],
                        Quantity = (decimal)1/3,
                        QuantityExpression = "1/3"
                    },
                    new Ingredient()
                    {
                        ID = 6,
                        Item = Foods[(int)FoodID.Salt],
                        Quantity = 1 + ((decimal)1/4),
                        QuantityExpression = "1 1/4"
                    },
                    new Ingredient()
                    {
                        ID = 7,
                        Item = Foods[(int)FoodID.Pepper],
                        Quantity = (decimal)3/4,
                        QuantityExpression = "3/4"
                    }
                },
            }
        };
    }
}
