
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessapp.Data.Models
{
    public class UserTracker
    {
        [Key]
        public int UserTrackerId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        
        public string UserName { get; set; }
        
        public string TagLine { get; set; }

        [Display(Name = "Completed Workouts")]
        public virtual ICollection<Workout> ListOfCompletedWorkouts { get; set; }
        public UserTracker()
        {
            ListOfCompletedWorkouts = new List<Workout>();
            //ListOfMealsEaten = new List<Recipe>();
        }

        [Display(Name = "Meals Eaten")]
        public virtual ICollection<Recipe> ListOfMealsEaten { get; set; }
        
        //public UserTracker()
        //{
        //    ListOfMealsEaten = new List<Recipe>();
        //}

        //^^relationship will need to be added to Recipe data and tracker models as well^^

    }
}
