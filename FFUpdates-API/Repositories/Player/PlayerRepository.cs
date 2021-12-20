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

            string query = @$"SELECT ID, PlayerName, Number, Team, Watched, capSpace, contractThrough, Position, PlayerStatus, TeamID, RookieYear, BirthDate, CollegeId, DraftPick, PlayerImage
                            FROM Players";

            return db.Query<Models.Player>(query).ToList();
        }

        public async Task<Player> GetById(int id)
        {
            string query = @$"SELECT ID, PlayerName, Number, Team, Watched, capSpace, contractThrough, Position, PlayerStatus, TeamID, RookieYear, BirthDate, CollegeId, DraftPick, PlayerImage
                            FROM Players
                            WHERE ID = {id}";

            return db.Query<Player>(query).First();
        }

        public async Task<int> AddPlayer(Player newPlayer)
        {
            string query = @$"INSERT INTO Players
                            VALUES('{newPlayer.PlayerName}',
                                    {newPlayer.Number},
                                    {newPlayer.Team},
                                    {newPlayer.Watched},
                                    {newPlayer.CapSpace},
                                    {newPlayer.ContractThrough},
                                    {newPlayer.Position},
                                    {newPlayer.PlayerStatus},
                                    {newPlayer.TeamID},
                                    {newPlayer.RookieYear},
                                    {newPlayer.Birthdate},
                                    {newPlayer.CollegeID},
                                    {newPlayer.DraftPick},
                                    {newPlayer.PlayerImage})";

            return db.Execute(query);
        }

        public async Task<int> DeletePlayer(int id)
        {
            string query = @$"DELETE
                            FROM Players 
                            WHERE ID = {id}";

            return db.Execute(query);
        }
    }
}
