using System;

namespace FFUpdates_API.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string PlayerName { get; set; }
        public string Position { get; set; }
        public string Team { get; set; }
        public DateTime Birthdate { get; set; }
        public int DraftYear { get; set; }
        public string DraftPick { get; set; }
    }
}
