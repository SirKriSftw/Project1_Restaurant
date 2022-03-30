using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using RestAPP.Models;

namespace RestAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderModel model = new OrderModel();

        [HttpGet]
        [Route("olist")]
        public IActionResult OrderList()
        {
            try
            {
                return Ok(model.GetOrders());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("oRlist")]
        public IActionResult OrderByRes(int resID)
        {
            try
            {
                return Ok(model.GetReservationOrders(resID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("oUlist")]
        public IActionResult OrderByUser(int userID)
        {
            try
            {
                return Ok(model.GetUserOrders(userID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
