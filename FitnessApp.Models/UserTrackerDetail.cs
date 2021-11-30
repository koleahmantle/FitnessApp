using Fitnessapp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Models
{
    public class UserTrackerDetail
    {
        public int UserTrackerId { get; set; }

        public string UserName { get; set; }

        public string TagLine { get; set; }

        public virtual ICollection<Workout> ListOfCompletedWorkouts { get; set; }
        public UserTrackerDetail()
        {
            ListOfCompletedWorkouts = new List<Workout>();
        }
    }
}
