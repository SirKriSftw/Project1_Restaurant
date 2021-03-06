using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using RestAPP.Models;
using Microsoft.Extensions.Logging;

namespace RestAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        ReservationModel model = new ReservationModel();
        private readonly ILogger<ReservationController> _logger;
        public ReservationController(ILogger<ReservationController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("reslist")]
        public IActionResult ReservationList()
        {
            _logger.LogInformation("Getting ALL reservations");
            try
            {
                return Ok(model.GetReservations());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Failed to get any reservations");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("resid")]
        public IActionResult GetReservation(int resID)
        {
            _logger.LogInformation("Getting reservation: " + resID);
            try
            {
                return Ok(model.GetReservation(resID));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Failed to get reservation: " + resID);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("userres")]
        public IActionResult GetUserReservations(int userID)
        {
            _logger.LogInformation("Getting reservations by user: " + userID);
            try
            {
                return Ok(model.GetUserReservations(userID));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Failed to get reservations by user: " + userID);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("addres")]
        public IActionResult AddReservation(int userID, DateTime resDateTime, int numOfGuests)
        {
            _logger.LogInformation("Adding reservation for user: " + userID + " at " + resDateTime + " with " + numOfGuests + " guests");
            try
            {
                return Created("", model.AddReservation(userID, resDateTime, numOfGuests));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Failed to add reservation for user: " + userID + " at " + resDateTime + " with " + numOfGuests + " guests");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("editres")]
        public IActionResult EditReservation(int resID, DateTime resDateTime, int numOfGuests)
        {
            _logger.LogInformation("Editing reservation: " + resID + " to " + resDateTime + " with " + numOfGuests + " guests");
            try
            {
                return Created("", model.EditReservation(resID, resDateTime, numOfGuests));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Failed to edit reservation: " + resID + " to " + resDateTime + " with " + numOfGuests + " guests");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delres")]
        public IActionResult DelReservation(int resID)
        {
            _logger.LogInformation("Deleting reservation: " + resID);
            try
            {
                return Accepted(model.DelReservation(resID));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Failed to delete reservation: " + resID);
                return BadRequest(ex.Message);
            }
        }
    }
}
