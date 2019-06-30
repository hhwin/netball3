using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary.Models
{
    public class TeamPlayerModel
    {
        [Key, Column(Order= 0)]
        [Display(Name ="Team ID")]
        public int teamID { get; set; }
        [Key, Column(Order = 1)]
        [Display(Name = "Player ID")]
        public int playerID { get; set; }
        [Display(Name = "Team Name")]
        public string teamName  { get; set; }
        [Display(Name = "Player Name")]
        public string playerName { get; set; }
        [Display(Name = "Captain Indicator")]
        public bool captainInd { get; set; } = false;
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name ="Mobile")]
        public string mobile { get; set; }
    }
}