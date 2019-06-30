using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models
{
    public class DivisionModel
    {
        [Required]
        public int divisionID { get; set; }
        [Required]
        public string division { get; set; }
        [Required]
        public int teamID { get; set; }
        [Required]
        [Display(Name="Team Name")]
        public string teamName { get; set; }
        public int? coachID { get; set; }
        [Display(Name="Coach Name")]
        public string coach { get; set; }
        public int? captainID { get; set; }
        [Display(Name="Captain Name")]
        public string captain { get; set; }
    }
}
