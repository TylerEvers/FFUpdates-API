using System.Collections.Generic;
using System.Threading.Tasks;
using FFUpdates_API.Models;

namespace FFUpdates_API.Repositories
{
    public interface IPlayerRepository
    {
        Task<List<Player>> Get();

        Task<Player> GetById(int id);

        Task<int> AddPlayer(Player newPlayer);

        Task<int> DeletePlayer(int id);
    }
}
