using Dapper;
using FFUpdates_API.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FFUpdates_API.Repositories
{
    public class PlayerRepository :BaseRepository, IPlayerRepository
    {
        private IDbConnection db;

        public PlayerRepository(IConfiguration configuration) : base(configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<List<Player>> Get()
        {
            string query = @$"SELECT ID, PlayerName, Position, Team, BirthDate, DraftYear, DraftPick
                            FROM Players";

            return db.Query<Models.Player>(query).ToList();
        }


        public async Task<Models.Player> GetById(int id)
        {
            string query = @$"SELECT ID, PlayerName, Position, Team, BirthDate, DraftYear, DraftPick
                            FROM Players
                            WHERE ID = {id}";

            return db.Query<Models.Player>(query).First();
        }
    }
}
