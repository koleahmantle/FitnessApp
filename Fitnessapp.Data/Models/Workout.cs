using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessapp.Data.Models
{
    public class Workout
    {
        [Key]
        public int WorkoutId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public double Duration { get; set; }
        [Required]
        public string Intensity { get; set; }

        public virtual ICollection<UserTracker> ListOfTrackers { get; set; }
        public Workout()
        {
            ListOfTrackers = new List<UserTracker>();
        }

    }
}
