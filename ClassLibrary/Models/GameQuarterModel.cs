using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models
{
    public class GameQuarterModel
    {
        [Key]
        public int gameQuarterID { get; set; }
        public int gameID { get; set; }
        public int courtID { get; set; }
        public string courtName { get; set; }
        public int? tournamentID { get; set; }
        public string tournamentName { get; set; }
        public string matchNo { get; set; }
        public string venue { get; set; }
        public string datePlayed { get; set; }
        public int? primaryUmpireID { get; set; }
        public string primaryUmpire { get; set; }
        public int? secondaryUmpireID { get; set; }
        public string secondaryUmpire { get; set; }
        public int? reserveUmpireID { get; set; }
        public string reserveUmpire { get; set; }
        public string teamName { get; set; }
        public int quarterTypeID { get; set; }
        public string quarterType { get; set; }
        public string ctrPass { get; set; }
        public string teamGS { get; set; }
        public string teamGA { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Goal score attempt must be a positive number")]
        public int goalScoreAttempt { get; set; } = 0;
        [Range(0, int.MaxValue, ErrorMessage = "Goal score must be a positive number")]
        public int goalScored { get; set; } = 0;
        [Range(0, int.MaxValue, ErrorMessage = "Quarter score must be a positive number")]
        public int quarterScore { get; set; } = 0;
        [Range(0, int.MaxValue, ErrorMessage = "Progressive score must be a positive number")]
        public int progressiveScore { get; set; } = 0;
    }
}