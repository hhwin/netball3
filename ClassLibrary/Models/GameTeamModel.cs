using System;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models
{
    public class GameTeamModel
    {
        [Key]
        public int gameTeamID { get; set; }
        public int gameID { get; set; }
        public int courtID { get; set; }
        [Display(Name="Court Name")]
        public string courtName { get; set; }
        public int? tournamentID { get; set; }
        [Display(Name = "Tournament Name")]
        public string tournamentName { get; set; }
        [Display(Name = "Match No")]
        public string matchNo { get; set; }
        public string venue { get; set; }
        [Display(Name = "Date Played")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime datePlayed { get; set; }
        public int? primaryUmpireID { get; set; }
        [Display(Name = "Primary Umpire")]
        public string primaryUmpire { get; set; }
        public int? secondaryUmpireID { get; set; }
        [Display(Name = "Secondary Umpire")]
        public string secondaryUmpire { get; set; }
        public int? reserveUmpireID { get; set; }
        [Display(Name = "Reserve Umpire")]
        public string reserveUmpire { get; set; }
        public int teamID { get; set; }
        [Display(Name = "Team Name")]
        public string teamName { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Final score must be a positive number")]
        public int finalScore { get; set; } = 0;
    }
}