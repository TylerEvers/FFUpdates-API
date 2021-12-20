using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using FFUpdates_API.Models;
using FFUpdates_API.Repositories;

namespace FFUpdates_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        // GET: api/<TeamController>
        [HttpGet]
        public async Task<ActionResult<List<Player>>> Get()
        {
            var players = await _playerRepository.Get();
            return Ok(players);
        }

        // GET api/<TeamController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetById(int id)
        {
            var player = await _playerRepository.GetById(id);
            return Ok(player);
        }

        // POST api/<TeamController>
        [HttpPost("AddPlayer")]
        public async Task<ActionResult<int>> Post([FromBody] Player body)
        {
            var status = await _playerRepository.AddPlayer(body);
            return Ok(status);
        }

        // PUT api/<TeamController>/5
        [HttpPut("UpdatePlayer/{id}")]
        public void Put(int id, [FromBody] Player body)
        {

        }
    }
}
