using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sohi.Web.Models.Leads;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sohi.Web.Controllers.Api
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class LeadsController : Controller
    {

        private readonly ILeadsRepository _leadRepository;

        public LeadsController(ILeadsRepository leadsRepository)
        {
            this._leadRepository = leadsRepository;
        }


        //[HttpGet("{GetAllLeads}/{accountid}")]
        //public ActionResult GetAllLeads(string accountid)
        //{
        //    try
        //    {
        //        return Ok(_leadRepository.GetAllLeads(accountid));
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Error retrieving data from the database");
        //    }
        //}

        [HttpGet("{Lead}/{id:Guid}")]
        public async Task<ActionResult<Lead>> GetLead(Guid id)
        {
            try
            {
                var result = await _leadRepository.GetLeadById(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost("{CreateLead}")]
        public async Task<ActionResult<Lead>> CreateLead(Lead lead)
        {
            try
            {
                if (lead == null)
                {
                    return BadRequest();
                }

                var createdLead = await _leadRepository.CreateLead(lead);

                return StatusCode(StatusCodes.Status200OK, "Success");

                //return CreatedAtAction(nameof(GetLead), new { id = createdLead.LeadId }, createdLead);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new employee record");
            }
        }
    }
}

