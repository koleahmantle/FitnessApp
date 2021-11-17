using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Models
{
    public class WorkoutEdit
    {
        public int WorkoutId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Duration { get; set; }
        public string Intensity { get; set; }
    }
}
