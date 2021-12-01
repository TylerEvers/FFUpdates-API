using Microsoft.Extensions.Configuration;

namespace FFUpdates_API.Repositories
{
    public abstract class BaseRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        protected BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
    }
}
