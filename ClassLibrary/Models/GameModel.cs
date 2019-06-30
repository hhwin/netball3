using System;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models
{
    public class GameModel
    {
        [Key]
        [Display(Name ="Game ID")]
        public int gameID { get; set; }
        [Display(Name = "Court ID")]
        [Range(1, int.MaxValue, ErrorMessage = "Court must be selected.")]
        public int courtID { get; set; }
        [Display(Name = "Court Name")]
        public string courtName { get; set; }
        [Display(Name = "Tournament ID")]
        public int? tournamentID { get; set; }
        [Display(Name = "Tournament")]
        public string tournamentName { get; set; }
        [Display(Name = "Match")]
        public string matchNo { get; set; }
        [Display(Name="Venue")]
        public string venue { get; set; }
        [Required]
        [Display(Name = "Date Played")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime datePlayed { get; set; }
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
        [Display(Name = "Start Time")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [Required]
        public TimeSpan startTime { get; set; }
        [Display(Name ="Start Time")]
        public string startTimeString {
            get
            {
                return startTime.ToString();
            }
        }
        [Display(Name = "Full Time")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [Required]
        public TimeSpan fullTime { get; set; }
        public string fullTimeString
        {
            get
            {
                return fullTime.ToString();
            }
        }
        [Display(Name = "Extra Time")]
        [Range(0, 30, ErrorMessage = "Extra time must be a positive number less than or equal to 30 minutes.")]
        public int? extraTimeEnd { get; set; }
        [Display(Name = "Scorer 1 ID")]
        public int? scorer1ID { get; set; }
        [Display(Name = "Scorer 1")]
        public string scorer1 { get; set; }
        [Display(Name = "Scorer 2 ID")]
        public int? scorer2ID { get; set; }
        [Display(Name = "Scorer 2")]
        public string scorer2 { get; set; }
        [Display(Name = "Time Keeper 1 ID")]
        public int? timeKeeper1ID { get; set; }
        [Display(Name = "Time Keeper 1")]
        public string timeKeeper1 { get; set; }
        [Display(Name = "Time Keeper 2 ID")]
        public int? timeKeeper2ID { get; set; }
        [Display(Name = "Time Keeper 2")]
        public string timeKeeper2 { get; set; }
        [Display(Name = "Division ID")]
        public int? divisionID { get; set; }
        [Display(Name = "Division")]
        public string division { get; set; }
        [Display(Name = "Team 1 ID")]
        [Range(1, int.MaxValue, ErrorMessage = "Team must be selected.")]
        public int team1ID { get; set; }
        [Display(Name = "Team 1")]
        public string team1Name { get; set; }
        [Display(Name = "Team 2 ID")]
        [Range(1, int.MaxValue, ErrorMessage = "Team must be selected.")]
        public int team2ID { get; set; }
        [Display(Name = "Team 2")]
        public string team2Name { get; set; }
        //[Display(Name = "Score")]
        //[Range(0, int.MaxValue, ErrorMessage = "Score must be a positive number")]
        //public int team1Score { get; set; }
        //[Display(Name = "Score")]
        //[Range(0, int.MaxValue, ErrorMessage = "Score must be a positive number")]
        //public int team2Score { get; set; }
        [Display(Name = "Score Final")]
        [Range(0, int.MaxValue, ErrorMessage = "Final score must be a positive number")]
        public int team1ScoreFinal { get; set; }
        [Display(Name = "Score Final")]
        [Range(0, int.MaxValue, ErrorMessage = "Final score must be a positive number")]
        public int team2ScoreFinal { get; set; }
        public int? captain1ID { get; set; }
        [Display(Name = "Captain")]
        public string captain1 { get; set; }
        public int? coach1ID { get; set; }
        [Display(Name = "Coach")]
        public string coach1 { get; set; }
        public int? captain2ID { get; set; }
        [Display(Name = "Captain")]
        public string captain2 { get; set; }
        public int? coach2ID { get; set; }
        [Display(Name = "Coach")]
        public string coach2 { get; set; }
        [Display(Name = "Game Team 1 ID")]
        [Required]
        public int gameTeam1ID { get; set; }
        [Display(Name = "Game Team 2 ID")]
        [Required]
        public int gameTeam2ID { get; set; }
    }
}