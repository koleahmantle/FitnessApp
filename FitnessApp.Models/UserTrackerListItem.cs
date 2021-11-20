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

        public Guid UserId { get; set; }

        [Display(Name = "Completed Workouts")]
        public virtual ICollection<Workout> ListOfCompletedWorkouts { get; set; }

        //public virtual ICollection<Recipe> ListOfMealsEaten { get; set; }
    }
}
