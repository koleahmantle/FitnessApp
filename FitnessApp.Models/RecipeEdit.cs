using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Models
{
    class RecipeEdit
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string Diet { get; set; }
        public double MealType { get; set; }
        public int Calories { get; set; }

    }
}
