using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using RestAPP.Models;

namespace RestAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        DishModel model = new DishModel();

        [HttpGet]
        [Route("dlist")]
        public IActionResult DishList()
        {
            try
            {
                return Ok(model.GetDishes());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("did")]
        public IActionResult GetDishByID(int dishID)
        {
            try
            {
                return Ok(model.GetDishByID(dishID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("adddish")]
        public IActionResult AddDish(string name, double price)
        {
            try
            {
                return Created("", model.AddDish(name, price));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("editdish")]
        public IActionResult EditDish(DishModel editDish)
        {
            try
            {
                return Created("", model.EditDish(editDish));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deldish")]
        public IActionResult DelDish(int dishID)
        {
            try
            {
                return Accepted(model.DelDish(dishID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
