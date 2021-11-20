using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Models
{
    public class UserTrackerCreate
    {
        public int UserTrackerId { get; set; }

        public Guid UserId { get; set; }
    }
}
