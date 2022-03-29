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
        public IActionResult userList()
        {
            try
            {
                return Ok(model.getUsers());
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("uid")]
        public IActionResult userByID(int userID)
        {
            try
            {
                return Ok(model.getUser(userID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("adduser")]
        public IActionResult addUser(UserModel newUser)
        {
            try
            {
                return Created("",model.addUser(newUser));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
