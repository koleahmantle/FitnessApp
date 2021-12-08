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

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Workout/{id}")]
        public IHttpActionResult Get(int id)
        {
            WorkoutService workoutService = CreateWorkoutService();
            var workout = workoutService.GetWorkoutById(id);
            return Ok(workout);
        }

        //Get workouts by UserTrackerId 
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Workout/ByTrackerId{trackerId}")]
        public IHttpActionResult GetWOsByTId(int trackerId)
        {
            WorkoutService workoutService = CreateWorkoutService();
            var workouts = workoutService.GetAllWorkoutsByTrackerId(trackerId);
            return Ok(workouts);
        }

        //Get CaloriesBurned by UserTrackerId
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Workout/CaloriesBurned/")]
        public IHttpActionResult GetCalsBurnedByTId(int trackerId)
        {
            WorkoutService workoutService = CreateWorkoutService();
            var calories = workoutService.GetCaloriesBurnedByTrackerId(trackerId);
            return Ok(calories);
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

        public IHttpActionResult Put(WorkoutEdit workout)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateWorkoutService();

            if (!service.UpdateWorkout(workout))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateWorkoutService();
            if (!service.DeleteWorkout(id))
                return InternalServerError();

            return Ok();
        }
    }
}