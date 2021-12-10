
using Fitnessapp.Data;
using Fitnessapp.Data.Models;
using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace FitnessApp.Services
{
   public class RecipeService
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

        public RecipeDetail GetRecipeById (int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipes
                        .Single(e => e.RecipeId == id && e.OwnerId == _userId);
                return new RecipeDetail
                {
                    RecipeId = entity.RecipeId,
                    RecipeName = entity.RecipeName,
                    Diet = entity.Diet,
                    MealType = entity.MealType,
                    Calories = entity.Calories,
                };
            }
        }

        public bool UpdateRecipe(RecipeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipes
                        .Single(e => e.RecipeId == model.RecipeId && e.OwnerId == _userId);

                entity.RecipeId = model.RecipeId;
                entity.RecipeName = model.RecipeName;
                entity.Diet = model.Diet;
                entity.MealType = model.MealType;
                entity.Calories = model.Calories;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRecipe(int recipeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipes
                        .Single(e => e.RecipeId == recipeId && e.OwnerId == _userId);
                ctx.Recipes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
