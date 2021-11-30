using Fitnessapp.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Models
{
    public class UserTrackerListItem
    {
        public int UserTrackerId { get; set; }

        public string UserName { get; set; }

        public string TagLine { get; set; }

        //[Display(Name = "Completed Workouts")]
        //public virtual ICollection<Workout> ListOfCompletedWorkouts { get; set; }

        //[Display(Name = "MealsEaten")]
        //public virtual ICollection<Recipe> ListOfMealsEaten { get; set; }
    }
}
