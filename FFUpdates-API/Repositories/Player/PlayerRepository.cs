using Dapper;
using Microsoft.Extensions.Configuration;
using System;
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

        public async Task<List<Models.Player>> Get()
        {

            string query = @$"SELECT ID, PlayerName, Number, Team, Watched, capSpace, contractThrough, Position, PlayerStatus, TeamID, RookieYear, BirthDate, CollegeId, DraftPick, PlayerImage
                            FROM Player";

            return db.Query<Models.Player>(query).ToList();
        }
    }
}
