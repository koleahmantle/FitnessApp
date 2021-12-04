using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessapp.Data.Models
{
   public class Recipe
    {
        [Key]
        public int RecipeId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string RecipeName { get; set; }
        [Required]
        public string Diet { get; set; }
        [Required]
        public double MealType { get; set; }
        [Required]
        public int Calories { get; set; }

        public virtual ICollection<UserTracker> ListOfTrackers { get; set; }
        public Recipe()
        {
            ListOfTrackers = new List<UserTracker>();
        }
    }
}
