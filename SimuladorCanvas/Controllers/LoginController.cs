using SimuladorCanvas.Data;
using SimuladorCanvas.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimuladorCanvas.Controllers
{
    public class LoginController : ApiController
    {
        private readonly LoginData loginData;

        public LoginController()
        {
            this.loginData = new LoginData();
        }

        [HttpPost]
        [Route("api/login")]
        public IHttpActionResult Login(Login model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool success = loginData.Login(model.Username, model.Password, model.UserType);

            if (success)
            {
                return Ok(new { message = "Login successful", userType = model.UserType });
            }
            else
            {
                return BadRequest("Login failed");
            }
        }
    }
}