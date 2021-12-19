using Dapper;
using FFUpdates_API.Models;
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

        public async Task<List<Team>> Get()
        {

            string query = @$"SELECT ID, Name, TeamType, DynamoID
                            FROM Teams";

            return db.Query<Team>(query).ToList();
        }

        public async Task<Team> GetById(int id)
        {
            string query = @$"SELECT ID, Name, TeamType, DynamoID
                            FROM Teams
                            WHERE ID = {id}";

            return db.Query<Team>(query).First();
        }

        public async Task<List<Team>> GetFantasyTeams()
        {
            string query = @$"SELECT ID, Name, TeamType, DynamoID
                            FROM Teams
                            WHERE TeamType = 0";

            return db.Query<Team>(query).ToList();
        }

        public async Task<List<Team>> GetNFLTeams()
        {
            string query = @$"SELECT ID, Name, TeamType, DynamoID
                            FROM Teams
                            WHERE TeamType = 1";

            return db.Query<Team>(query).ToList();
        }

        public async Task<int> AddTeam(Team newTeam)
        {
            string query = @$"INSERT INTO Teams 
                            VALUES('{newTeam.Name}',
                                    {newTeam.TeamType},
                                    {newTeam.DynamoID})";

            return db.Execute(query);
        }

        public async Task<int> DeleteTeam(int id)
        {
            string query = @$"DELETE
                            FROM Teams 
                            WHERE ID = {id}";

            return db.Execute(query);
        }
    }
}
