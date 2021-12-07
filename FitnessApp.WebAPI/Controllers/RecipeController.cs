
using FitnessApp.Models;
using FitnessApp.Services;
using Microsoft.AspNet.Identity;
using System;

using System.Web.Http;

namespace FitnessApp.WebAPI.Controllers
{
    [Authorize]
    public class RecipeController : ApiController
    {

        public IHttpActionResult Get()
        {
            RecipeService recipeService = CreateRecipeService();
            var recipes = recipeService.GetRecipes();
            return Ok(recipes);
        }
        public IHttpActionResult Post(RecipeCreate recipe)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRecipeService();

            if (!service.CreateRecipe(recipe))
                return InternalServerError();

            return Ok();
        }
        private RecipeService CreateRecipeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var recipeService = new RecipeService(userId);
            return recipeService;
        }
    }

}
