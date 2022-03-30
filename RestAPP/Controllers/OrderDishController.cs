using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using RestAPP.Models;

namespace RestAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDishController : ControllerBase
    {
        OrderDishModel model = new OrderDishModel();

        [HttpGet]
        [Route("odlist")]
        public IActionResult OrderedDishesList()
        {
            try
            {
                return Ok(model.GetOrderedDishes());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("uodlist")]
        public IActionResult UsersOrderedDishes(int userID)
        {
            try
            {
                return Ok(model.GetUserDishes(userID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("rodlist")]
        public IActionResult ReservationOrderedDishes(int resID)
        {
            try
            {
                return Ok(model.GetResDishes(resID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("oodlist")]
        public IActionResult OrdersDishes(int orderID)
        {
            try
            {
                return Ok(model.GetOrdersDishes(orderID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("addordereddish")]
        public IActionResult AddOrderedDish(OrderDishModel newOrderDish)
        {
            try
            {
                return Created("", model.AddOrderedDish(newOrderDish));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("editordereddish")]
        public IActionResult EditOrderedDish(OrderDishModel editOrderDish)
        {
            try
            {
                return Created("", model.EditOrderedDish(editOrderDish));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delordereddish")]
        public IActionResult DelUser(int orderID, int dishID)
        {
            try
            {
                return Accepted(model.DelOrderedDish(orderID, dishID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
