using System.Collections.Generic;
using System.Threading.Tasks;
using FFUpdates_API.Models;

namespace FFUpdates_API.Repositories
{
    public interface ITeamRepository
    {
        Task<List<Team>> Get();

        Task<Team> GetById(int id);

        Task<List<Team>> GetFantasyTeams();

        Task<List<Team>> GetNFLTeams();

        Task<int> AddTeam(Team newTeam);

        Task<int> DeleteTeam(int id);
    }
}
