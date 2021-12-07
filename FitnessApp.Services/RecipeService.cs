
using Fitnessapp.Data;
using Fitnessapp.Data.Models;
using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace FitnessApp.Services
{
   public  class RecipeService
    {
        private readonly Guid _userId;

        public RecipeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRecipe (RecipeCreate model)
        {
            var entity =
                new Recipe()
                {
                    OwnerId = _userId,
                    RecipeName = model.RecipeName,
                    Diet = model.Diet,
                    MealType = model.MealType,
                    Calories = model.Calories
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Recipes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RecipeListItem> GetRecipes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Recipes
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new RecipeListItem
                                {
                                    RecipeId = e.RecipeId,
                                    RecipeName = e.RecipeName,
                                    Diet = e.Diet,
                                    MealType = e.MealType,
                                    Calories = e.Calories
                                }
                         );
                return query.ToArray();
            }
        }


    }
}
