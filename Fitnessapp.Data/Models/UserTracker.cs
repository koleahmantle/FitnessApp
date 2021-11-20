
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

        [ForeignKey(nameof(ApplicationUser))]
        public int MyProperty { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Workout> ListOfWorkouts { get; set; }
        public UserTracker()
        {
            ListOfWorkouts = new List<Workout>();
        }
    }
}
