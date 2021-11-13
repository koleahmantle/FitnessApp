using FitnessApp.Models;
using FitnessApp.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FitnessApp.WebAPI.Controllers
{
    [System.Web.Http.Authorize]
    public class WorkoutController : ApiController
    {
        public IHttpActionResult Get()
        {
            WorkoutService workoutService = CreateWorkoutService();
            var workouts = workoutService.GetWorkouts();
            return Ok(workouts);
        }
        public IHttpActionResult Post(WorkoutCreate workout)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateWorkoutService();

            if (!service.CreateWorkout(workout))
                return InternalServerError();

            return Ok();
        }
        private WorkoutService CreateWorkoutService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var workoutService = new WorkoutService(userId);
            return workoutService;
        }

    }
}