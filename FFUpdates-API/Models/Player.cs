using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFUpdates_API.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string PlayerName { get; set; }
        public int? Number { get; set; }
        public int Team { get; set; }
        public int Watched { get; set; }
        public int? CapSpace { get; set; }
        public int? ContractThrough { get; set; }
        public string Position { get; set; }
        public int PlayerStatus { get; set; }
        public int TeamID { get; set; }
        public int RookieYear { get; set; }
        public DateTime Birthdate { get; set; }
        public int CollegeID { get; set; }
        public string DraftPick { get; set; }
        public string PlayerImage { get; set; }
    }
}
