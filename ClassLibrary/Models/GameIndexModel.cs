using PagedList;
using System;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models
{
    public class GameIndexModel
    {
        [Display(Name = "Team ID")]
        public int teamID { get; set; }
        [Display(Name = "Team Name")]
        [Required]
        public string teamName { get; set; }
        [Display(Name="Division ID")]
        public int divisionID { get; set; }
        [Display(Name ="Division")]
        public string division { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Played")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? datePlayed { get; set; }
        public IPagedList<GameModel> GamePagedList { get; set; }
    }
}