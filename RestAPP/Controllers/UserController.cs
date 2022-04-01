using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using RestAPP.Models;
using Microsoft.Extensions.Logging;

namespace RestAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserModel model = new UserModel();
        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger)
        { 
            _logger = logger;
        }

        [HttpGet]
        [Route("ulist")]
        public IActionResult UserList()
        {
            _logger.LogInformation("Getting ALL users");
            try
            {
                return Ok(model.GetUsers());                
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get any users");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("uid")]
        public IActionResult UserByID(int userID)
        {
            _logger.LogInformation("Getting user: " + userID);
            try
            {
                return Ok(model.GetUser(userID));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get user: " + userID);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("adduser")]
        public IActionResult AddUser(UserModel newUser)
        {
            _logger.LogInformation("Adding new user: " + newUser.username);
            try
            {
                return Created("",model.AddUser(newUser));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to add user: " + newUser.username);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("edituser")]
        public IActionResult EditUser(UserModel editUser, string newPassword)
        {
            _logger.LogInformation("Editing user: " + editUser.username);
            try
            {
                return Created("", model.EditUser(editUser, newPassword));
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Failed to edit user: " + editUser.username);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deluser")]
        public IActionResult DelUser(int userID)
        {
            _logger.LogInformation("Deleting user: " + userID);
            try
            {
                return Accepted(model.DelUser(userID));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to delete user: " + userID);
                return BadRequest(ex.Message);
            }
        }
    }
}
