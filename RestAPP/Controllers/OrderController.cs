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
        [Route("oid")]
        public IActionResult OrderByID(int orderID)
        {
            try
            {
                return Ok(model.GetOrderByID(orderID));
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

        [HttpPost]
        [Route("addorder")]
        public IActionResult AddOrder(int resID)
        {
            try
            {
                return Created("", model.AddOrder(resID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("editorder")]
        public IActionResult EditOrder(int orderID, int newResID)
        {
            try
            {
                return Created("", model.EditOrder(orderID, newResID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delorder")]
        public IActionResult DelOrder(int orderID)
        {
            try
            {
                return Accepted(model.DelOrder(orderID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
