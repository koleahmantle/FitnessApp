using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Models
{
    public class WorkoutCreate
    {
        [Required]
        [MinLength(3, ErrorMessage = "Please Enter at least 3 characters.")]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public double Duration { get; set; }
        [Required]
        public string Intensity { get; set; }
        [Required]
        public int CaloriesBurned { get; set; }
    }
}
