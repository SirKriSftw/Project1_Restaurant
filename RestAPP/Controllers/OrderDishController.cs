using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using RestAPP.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace RestAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDishController : ControllerBase
    {
        OrderDishModel model = new OrderDishModel();
        private readonly ILogger<OrderDishController> _logger;
        public OrderDishController(ILogger<OrderDishController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [Route("odlist")]
        public IActionResult OrderedDishesList()
        {
            _logger.LogInformation("Getting ALL ordered dishes");
            try
            {
                return Ok(model.GetOrderedDishes());
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get any ordered dishes");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("uodlist")]
        public IActionResult UsersOrderedDishes(int userID)
        {
            _logger.LogInformation("Getting ordered dishes by user: " + userID);
            try
            {
                return Ok(model.GetUserDishes(userID));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get ordered dishes by user: " + userID);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("rodlist")]
        public IActionResult ReservationOrderedDishes(int resID)
        {
            _logger.LogInformation("Getting ordered dishes for reservation: " + resID);
            try
            {
                return Ok(model.GetResDishes(resID));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get ordered dishes for reservation: " + resID);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("oodlist")]
        public IActionResult OrdersDishes(int orderID)
        {
            _logger.LogInformation("Getting ordered dishes for order: " + orderID);
            try
            {
                return Ok(model.GetOrdersDishes(orderID));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get ordered dishes for order: " + orderID);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("addordereddish")]
        public IActionResult AddOrderedDish(OrderDishModel newOrderDish)
        {
            _logger.LogInformation("Adding new ordered dish: " + newOrderDish.dishID + " x" + newOrderDish.quantity + " for order " + newOrderDish.orderID);
            try
            {
                return Created("", model.AddOrderedDish(newOrderDish));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to add ordered dish for order: " + newOrderDish.orderID);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("addordereddishes")]
        public IActionResult AddOrderedDishes(List<OrderDishModel> newOrderDish)
        {
            _logger.LogInformation("Adding " + newOrderDish.Count + " ordered dishes" );
            try
            {
                return Created("", model.AddMultipleOrderedDishes(newOrderDish));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to add ordered dishes");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("editordereddish")]
        public IActionResult EditOrderedDish(OrderDishModel editOrderDish)
        {
            _logger.LogInformation("Editing ordered dishes: " + editOrderDish.dishID + " to x" + editOrderDish.quantity + " for order " + editOrderDish.orderID);
            try
            {
                return Created("", model.EditOrderedDish(editOrderDish));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to edit ordered dish for order: " + editOrderDish.orderID);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delordereddish")]
        public IActionResult DelOrderedDish(int orderID, int dishID)
        {
            _logger.LogInformation("Deleting ordered dish: " + dishID + " from order " + orderID);
            try
            {
                return Accepted(model.DelOrderedDish(orderID, dishID));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to delete ordered dish: " + dishID + " from order " + orderID);
                return BadRequest(ex.Message);
            }
        }
    }
}
