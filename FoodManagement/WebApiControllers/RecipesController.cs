using Entities.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodManagement.WebApiControllers
{
    public class RecipesController : ApiController
    {
        // GET api/<controller>
        public object Get()
        {
            return new { data = new { Constants.Recipes } };
        }

        // GET api/<controller>/5
        public object Get(int id)
        {
            return new { data = new { Recipe = Constants.Recipes[id] } };
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public object Computations(int id) {
            Recipe recipe = Constants.Recipes.Where(item => item.ID == id).Single();
            return new { data = new { TotalWellnessDiscount = recipe.TotalWellnessDiscount(), TotalTax = recipe.TotalTax(), TotalCalculation = recipe.TotalCalculation() } };
        }
    }
}