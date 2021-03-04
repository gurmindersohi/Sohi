using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sohi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationController ac;
        public AuthenticationController(AuthenticationController ac)
        {
            this.ac = ac;
        }

        [HttpGet]
        public async Task<ActionResult> GetUser()
        {
            try
            {
                return Ok(await ac.GetUser());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

    }
}
