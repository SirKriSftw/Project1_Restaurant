using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using RestAPP.Models;

namespace RestAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserModel model = new UserModel();

        [HttpGet]
        [Route("ulist")]
        public IActionResult UserList()
        {
            try
            {
                return Ok(model.GetUsers());
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("uid")]
        public IActionResult UserByID(int userID)
        {
            try
            {
                return Ok(model.GetUser(userID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("adduser")]
        public IActionResult AddUser(UserModel newUser)
        {
            try
            {
                return Created("",model.AddUser(newUser));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("edituser")]
        public IActionResult EditUser(UserModel editUser, string newPassword)
        {
            try
            {
                return Created("", model.EditUser(editUser, newPassword));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deluser")]
        public IActionResult DelUser(int userID)
        {
            try
            {
                return Accepted(model.DelUser(userID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
