using FFUpdates_API.Repositories.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFUpdates_API.Models
{
    public class Team
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string TeamType { get; set; }
        public string DynamoID { get; set; }
    }
}
