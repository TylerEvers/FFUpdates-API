using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FFUpdates_API.Models;
using FFUpdates_API.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FFUpdates_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepository _teamRepository;

        public TeamController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        // GET: api/<TeamController>
        [HttpGet]
        public async Task<ActionResult<List<Team>>> Get()
        {
            var teams = await _teamRepository.Get();
            return Ok(teams);
        }

        // GET api/<TeamController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetById(int id)
        {
            var team = await _teamRepository.GetById(id);
            return Ok(team);
        }

        // GET api/<TeamController>/
        [HttpGet("fantasy")]
        public async Task<ActionResult<List<Team>>> GetFantasyTeams()
        {
            var team = await _teamRepository.GetFantasyTeams();
            return Ok(team);
        }

        // GET api/<TeamController>/
        [HttpGet("NFL")]
        public async Task<ActionResult<List<Team>>> GetNFLTeams()
        {
            var team = await _teamRepository.GetNFLTeams();
            return Ok(team);
        }

        // POST api/<TeamController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] Team body)
        {
            var status = await _teamRepository.AddTeam(body);
            return Ok(status);
        }
        
        // PUT api/<TeamController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string json)
        {
            
        }
        
        //Commenting out, don't want functionality in end product currently
        // DELETE api/<TeamController>/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<int>> Delete(int id)
        //{
        //    var status = await _teamRepository.DeleteTeam(id);
        //    return Ok(status);
        //}
    }
}
