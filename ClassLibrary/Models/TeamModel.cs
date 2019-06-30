using ClassLibrary.Logic.Team;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ClassLibrary.Models
{
    public class TeamModel
    {
        [Key, Column(Order = 0)]
        [Display(Name = "Team ID")]
        [Required]
        public int teamID { get; set; }
        [Key, Column(Order =1)]
        [Required]
        [Display(Name = "Team Name")]
        public string teamName { get; set; }
        [Display(Name = "Coach Person ID")]
        public int coachPersonID { get; set; }
        [Display(Name = "Coach Name")]
        public string coachName { get; set; } 
        [Display(Name ="Division ID")]
        public int divisionID { get; set; }
        [Display(Name = "Division Name")]
        public string divisionName { get; set; }
        [Display(Name ="Captain ID")]
        public int captainID { get; set; }
        [Display(Name = "Captain Name")]
        public string captainName { get; set; }
        public TeamSelectList teamSelectList { get; set; }
    }
}