using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sohi.Web.Models.Leads;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sohi.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly ILeadsRepository _leadRepository;

        public LeadsController(ILeadsRepository leadsRepository)
        {
            this._leadRepository = leadsRepository;
        }

        [HttpGet("{accountid:Guid}")]
        public ActionResult GetEmployees(string accountid)
        {
            try
            {
                return Ok( _leadRepository.GetAllLeads(accountid));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Lead>> GetLead(Guid id)
        {
            try
            {
                var result = await _leadRepository.GetLeadById(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Lead>> CreateLead(Lead lead)
        {
            try
            {
                if (lead == null)
                { 
                    return BadRequest();
                }

                var createdLead = await _leadRepository.CreateLead(lead);

                return CreatedAtAction(nameof(GetLead), new { id = createdLead.LeadId }, createdLead);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new employee record");
            }
        }
    }
}
