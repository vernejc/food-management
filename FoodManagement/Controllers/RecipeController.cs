using FoodManagement.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodManagement.Controllers
{
    [RoutePrefix("Recipe")]
    [Route("{action=Index}")]
    public class RecipeController : BaseController
    {
        public RecipeController()
        {
            Title = "Recipes";
            RelativeURL = "Recipe";
            ControllerSetup();
            ViewBagSetup();
        }

        public ActionResult Index()
        {
            return View();
        }

        [Route("view-recipe")]
        public ActionResult ViewRecipe() {
            return View("Index");
        }
    }
}