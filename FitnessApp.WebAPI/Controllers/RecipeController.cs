
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
        public IHttpActionResult Get (int id)
        {
            RecipeService noteService = CreateRecipeService();
            var recipe = noteService.GetRecipeById(id);
            return Ok(recipe);
        }
        public IHttpActionResult Put(RecipeEdit workout)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRecipeService();

            if (!service.UpdateRecipe(workout))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateRecipeService();
            if (!service.DeleteRecipe(id))
                return InternalServerError();

            return Ok();
        }
    }

}
