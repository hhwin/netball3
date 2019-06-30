using System;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models
{
    public class GameTeamPlayerModel
    {
        [Key]
        [Display(Name = "Game Team Player ID")]
        public int gamePlayerID { get; set; }
        [Display(Name = "Game Team ID")]
        [Required]
        public int gameTeamID { get; set; }
        [Display(Name = "Team ID")]
        public int teamID { get; set; }
        [Display(Name = "Team Name")]
        public string teamName { get; set; }
        [Display(Name = "Game ID")]
        public int gameID { get; set; }
        [Display(Name = "Court ID")]
        public int courtID { get; set; }
        [Display(Name = "Court Name")]
        public string courtName { get; set; }
        [Display(Name = "Tournament ID")]
        public int? tournamentID { get; set; }
        [Display(Name = "Tournament Name")]
        public string tournamentName { get; set; }
        [Display(Name = "Match No")]
        public string matchNo { get; set; }
        [Display(Name = "Venue")]
        public string venue { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Played")]
        public DateTime datePlayed { get; set; }
        [Display(Name = "Date Played")]
        public string datePlayedString
        {
            get
            {
                return datePlayed.ToString("dd/MM/yyyy");
            }
        }
        [Display(Name = "Primary Umpire ID")]
        public int? primaryUmpireID { get; set; }
        [Display(Name = "Primary Umpire")]
        public string primaryUmpire { get; set; }
        [Display(Name = "Secondary Umpire ID")]
        public int? secondaryUmpireID { get; set; }
        [Display(Name = "Secondary Umpire")]
        public string secondaryUmpire { get; set; }
        [Display(Name = "Reserve Umpire ID")]
        public int? reserveUmpireID { get; set; }
        [Display(Name = "Reserve Umpire")]
        public string reserveUmpire { get; set; }
        [Display(Name = "Player ID")]
        [Required]
        public int playerID { get; set; }
        [Display(Name = "Player Name")]
        public string playerName { get; set; }
        [Display(Name = "1st Quarter")]
        public bool firstQuarterInd { get; set; }
        [Display(Name = "2nd Quarter")]
        public bool secondQuarterInd { get; set; }
        [Display(Name = "3rd Quarter")]
        public bool thirdQuarterInd { get; set; }
        [Display(Name = "4th Quarter")]
        public bool fourthQuarterInd { get; set; }
    }
}