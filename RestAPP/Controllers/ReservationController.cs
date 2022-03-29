using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using RestAPP.Models;

namespace RestAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        ReservationModel model = new ReservationModel();

        [HttpGet]
        [Route("reslist")]
        public IActionResult ReservationList()
        {
            try
            {
                return Ok(model.GetReservations());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("resid")]
        public IActionResult GetReservation(int resID)
        {
            try
            {
                return Ok(model.GetReservation(resID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("userres")]
        public IActionResult GetUserReservations(int userID)
        {
            try
            {
                return Ok(model.GetUserReservations(userID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("addres")]
        public IActionResult AddReservation(int userID, DateTime resDateTime)
        {
            try
            {
                return Created("", model.AddReservation(userID, resDateTime));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
