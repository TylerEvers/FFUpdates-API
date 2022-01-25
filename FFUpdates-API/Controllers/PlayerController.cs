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

        // GET: api/<PlayerController>
        [HttpGet]
        public async Task<ActionResult<List<Player>>> Get()
        {
            var players = await _playerRepository.Get();
            return Ok(players);
        }

        // GET: api/<PlayerController>
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetById(int id)
        {
            var player = await _playerRepository.GetById(id);
            return Ok(player);
        }
    }
}
