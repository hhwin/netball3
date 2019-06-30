using PagedList;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models
{
    public class PlayerIndexModel 
    {
        [Display(Name = "Team ID")]
        public int teamID { get; set; }
        [Display(Name = "Team Name")]
        [Required]
        public string teamName { get; set; }
        public IPagedList<PlayerModel> PlayerPagedList { get; set; }
    }
}