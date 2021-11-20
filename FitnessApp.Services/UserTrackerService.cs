using Fitnessapp.Data;
using Fitnessapp.Data.Models;
using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Services
{
    public class UserTrackerService
    {
        private readonly Guid _userId;

        public UserTrackerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateUserTracker(UserTrackerCreate model)
        {
            var entity = new UserTracker()
            {
                UserTrackerId = model.UserTrackerId,
                UserId = model.UserId,

            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.UserTrackers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserTrackerListItem> GetAllUserTrackers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .UserTrackers
                    .Where(e => e.UserId == _userId)
                    .Select(e =>
                    new UserTrackerListItem
                    {
                        UserTrackerId = e.UserTrackerId,
                        UserId = e.UserId,
                        ListOfCompletedWorkouts = e.ListOfCompletedWorkouts
                    });
                return query.ToArray();
            }
        }




    }
}
