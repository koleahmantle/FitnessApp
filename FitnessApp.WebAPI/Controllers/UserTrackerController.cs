using FitnessApp.Models;
using FitnessApp.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FitnessApp.WebAPI.Controllers
{
    [System.Web.Http.Authorize]
    public class UserTrackerController : ApiController
    {
        private UserTrackerService CreateUserTrackerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var userTrackerService = new UserTrackerService(userId);
            return userTrackerService;
        }

        public IHttpActionResult Post(UserTrackerCreate userTracker)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserTrackerService();

            if (!service.CreateUserTracker(userTracker))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Post(int userTrackerId, int workoutId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserTrackerService();

            if (service != null)
            {
                service.AddWorkOutToTracker(workoutId, userTrackerId);
            }
            //return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get()
        {
            UserTrackerService userTrackerService = CreateUserTrackerService();
            var userTrackers = userTrackerService.GetAllUserTrackers();
            return Ok(userTrackers);
        }

        public IHttpActionResult Get(int id)
        {
            UserTrackerService userTrackerService = CreateUserTrackerService();
            var userTracker = userTrackerService.GetUserTrackerById(id);
            return Ok(userTracker);
        }

        public IHttpActionResult Put (UserTrackerEdit userTracker)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserTrackerService();

            if (!service.UpdateUserTracker(userTracker))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateUserTrackerService();
            if (!service.DeleteUserTracker(id))
                return InternalServerError();
            return Ok();
        }
    }
}
