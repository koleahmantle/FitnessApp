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
                UserId = _userId,
                UserName = model.UserName,
                TagLine = model.TagLine

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
                        UserName = e.UserName,
                        TagLine = e.TagLine
                    });
                return query.ToArray();
            }
        }

        public UserTrackerDetail GetUserTrackerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .UserTrackers
                    .SingleOrDefault(e => e.UserTrackerId == id && e.UserId == _userId);
                return new UserTrackerDetail
                {
                    UserTrackerId = entity.UserTrackerId,
                    UserName = entity.UserName,
                    TagLine = entity.TagLine
                };
            }
        }

        public bool UpdateUserTracker(UserTrackerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .UserTrackers
                    .Single(e => e.UserTrackerId == model.UserTrackerId && e.UserId == _userId);

                
                entity.UserName = model.UserName;
                entity.TagLine = model.TagLine;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteUserTracker(int usetTrackerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .UserTrackers
                    .Single(e => e.UserTrackerId == usetTrackerId && e.UserId == _userId);

                ctx.UserTrackers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
