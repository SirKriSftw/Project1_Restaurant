using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using RestAPP.Models;
using Microsoft.Extensions.Logging;

namespace RestAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderModel model = new OrderModel();
        private readonly ILogger<OrderController> _logger;
        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("olist")]
        public IActionResult OrderList()
        {
            _logger.LogInformation("Getting ALL orders");
            try
            {
                return Ok(model.GetOrders());
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get any order");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("oid")]
        public IActionResult OrderByID(int orderID)
        {
            _logger.LogInformation("Getting order: " + orderID);
            try
            {
                return Ok(model.GetOrderByID(orderID));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get order: " + orderID);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("oRlist")]
        public IActionResult OrderByRes(int resID)
        {
            _logger.LogInformation("Getting order for reservation: " + resID);
            try
            {
                return Ok(model.GetReservationOrders(resID));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get order for reservation: " + resID);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("oUlist")]
        public IActionResult OrderByUser(int userID)
        {
            _logger.LogInformation("Getting order for user: " + userID);
            try
            {
                return Ok(model.GetUserOrders(userID));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get order for user: " + userID);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("addorder")]
        public IActionResult AddOrder(int resID)
        {
            _logger.LogInformation("Adding order for reservation: " + resID);
            try
            {
                return Created("", model.AddOrder(resID));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to add order for reservation: " + resID);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("editorder")]
        public IActionResult EditOrder(int orderID, int newResID)
        {
            _logger.LogInformation("Changing order: " + orderID + " to reservation " + newResID);
            try
            {
                return Created("", model.EditOrder(orderID, newResID));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to edit order: " + orderID);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delorder")]
        public IActionResult DelOrder(int orderID)
        {
            _logger.LogInformation("Deleting order: " + orderID);
            try
            {
                return Accepted(model.DelOrder(orderID));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to delete order: " + orderID);
                return BadRequest(ex.Message);
            }
        }

    }
}
