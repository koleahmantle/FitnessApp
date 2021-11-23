using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Models
{
    public class RecipeCreate
    {
        [MinLength (3, ErrorMessage ="Please enter at least 3 characters.")]
        [Required]
        public string RecipeName { get; set; }
        [Required]
        public string Diet { get; set; }
        [Required]
        public double MealType { get; set; }
        [Required]
        public int Calories { get; set; }
    }
}
