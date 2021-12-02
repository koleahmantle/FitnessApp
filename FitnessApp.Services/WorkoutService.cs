using Fitnessapp.Data;
using Fitnessapp.Data.Models;
using FitnessApp.Models;
using FitnessApp.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Services
{
    public class WorkoutService
    {
        private readonly Guid _userId;

        public WorkoutService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateWorkout(WorkoutCreate model)
        {
            var entity = new Workout()
            {
                OwnerId = _userId,
                Name = model.Name,
                Category = model.Category,
                Duration = model.Duration,
                Intensity = model.Intensity,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Workouts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<WorkoutListItem> GetWorkouts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Workouts
                    .Where(e => e.OwnerId == _userId)
                    .Select(e =>
                    new WorkoutListItem
                    {
                        WorkoutId = e.WorkoutId,
                        Name = e.Name,
                        Category = e.Category,
                        Duration = e.Duration,
                        Intensity = e.Intensity

                    }
                    );
                return query.ToArray();
            }
        }
    }
}
