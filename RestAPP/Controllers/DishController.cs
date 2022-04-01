using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using RestAPP.Models;
using Microsoft.Extensions.Logging;

namespace RestAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        DishModel model = new DishModel();
        private readonly ILogger<DishController> _logger;
        public DishController(ILogger<DishController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("dlist")]
        public IActionResult DishList()
        {
            _logger.LogInformation("Getting ALL dishes");
            try
            {
                return Ok(model.GetDishes());
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get any dishes");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("did")]
        public IActionResult GetDishByID(int dishID)
        {
            _logger.LogInformation("Getting dish: " + dishID);
            try
            {
                return Ok(model.GetDishByID(dishID));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get dish: " + dishID);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("adddish")]
        public IActionResult AddDish(string name, double price)
        {
            _logger.LogInformation("Adding dish: " + name);
            try
            {
                return Created("", model.AddDish(name, price));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to add dish: " + name);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("editdish")]
        public IActionResult EditDish(DishModel editDish)
        {
            _logger.LogInformation("Editing dish: " + editDish.dishID + " to " + editDish.name + " at $" + editDish.price);
            try
            {
                return Created("", model.EditDish(editDish));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to edit dish: " + editDish.dishID);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deldish")]
        public IActionResult DelDish(int dishID)
        {
            _logger.LogInformation("Deleting dish: " + dishID);
            try
            {
                return Accepted(model.DelDish(dishID));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to delete dish: " + dishID);
                return BadRequest(ex.Message);
            }
        }
    }
}
