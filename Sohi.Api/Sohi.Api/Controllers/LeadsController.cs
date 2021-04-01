using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sohi.Web.Models.Leads;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sohi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly ILeadsRepository employeeRepository;

        public LeadsController(ILeadsRepository leadsRepository)
        {
            this.employeeRepository = leadsRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Lead>> CreateLead(Lead lead)
        {
            try
            {
                if (lead == null)
                    return BadRequest();

                var createdLead = await employeeRepository.Add(lead);

                return CreatedAtAction(nameof(GetEmployee),
                    new { id = createdEmployee.EmployeeId }, createdEmployee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }
    }
}
