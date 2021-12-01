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
    public class TeamRepository :BaseRepository, ITeamRepository
    {
        private IDbConnection db;

        public TeamRepository(IConfiguration configuration) : base(configuration)
        {
            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<List<Models.Team>> Get()
        {

            string query = @$"SELECT ID, Name, TeamType, DynamoID
                            FROM Teams";

            return db.Query<Models.Team>(query).ToList();
        }

        public async Task<Models.Team> GetById(int id)
        {
            string query = @$"SELECT ID, Name, TeamType, DynamoID
                            FROM Teams
                            WHERE ID = {id}";

            return db.Query<Models.Team>(query).First();
        }

        public async Task<List<Models.Team>> GetFantasyTeams()
        {
            string query = @$"SELECT ID, Name, TeamType, DynamoID
                            FROM Teams
                            WHERE TeamType = 0";

            return db.Query<Models.Team>(query).ToList();
        }

        public async Task<List<Models.Team>> GetNFLTeams()
        {
            string query = @$"SELECT ID, Name, TeamType, DynamoID
                            FROM Teams
                            WHERE TeamType = 1";

            return db.Query<Models.Team>(query).ToList();
        }
    }
}
