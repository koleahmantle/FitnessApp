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
        public WorkoutDetail GetWorkoutById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Workouts
                    .Single(e => e.WorkoutId == id && e.OwnerId == _userId);
                return new WorkoutDetail
                {
                    WorkoutId = entity.WorkoutId,
                    Name = entity.Name,
                    Category = entity.Category,
                    Duration = entity.Duration,
                    Intensity = entity.Intensity,
                };
            }
        }
        public bool UpdateWorkout(WorkoutEdit model)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity = context
                    .Workouts
                    .Single(e => e.WorkoutId == model.WorkoutId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.Category = model.Category;
                entity.Duration = model.Duration;
                entity.Intensity = model.Intensity;

                return context.SaveChanges() == 1;
            }
        }
    }
}
