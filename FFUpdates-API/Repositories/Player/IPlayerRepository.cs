using System.Collections.Generic;
using System.Threading.Tasks;
using FFUpdates_API.Models;

namespace FFUpdates_API.Repositories
{
    public interface IPlayerRepository
    {
        Task<List<Player>> Get();

    }
}
