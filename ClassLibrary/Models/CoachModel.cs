using ClassLibrary.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary.Models
{
    public class CoachModel : AbstractPersonModel, IPersonModel
    {
        [Key, Column(Order=0)]
        [Display(Name = "Person ID")]
        public int personID { get; set; }
        [Key, Column(Order = 1)]
        [Display(Name = "Team ID")]
        public int teamID { get; set; } 
        [Required]
        [Display(Name ="First Name")]
        public string firstName { get; set; }
        [Display(Name = "Middle Name")]
        public string middleName { get; set; }
        [Required]
        [Display(Name ="Last Name")]
        public string lastName { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        [Display(Name = "Emergency Contact")]
        public string emergencyContact { get; set; }
        [Display(Name = "Emergency Contact No")]
        public string emergencyContactNo { get; set; }
        [Display(Name = "Coach for Team")]
        [Required]
        public string teamName { get; set; }
        [Display(Name = "Coach Name")]
        public string coachName { get; set; }
        [Display(Name = "Active Coach")]
        public bool? activeInd { get; set; }
        [Display(Name = "Person Name")]
        public override string GetPersonName(string firstName,
            string lastName)
        {
            return firstName + " " + lastName;
        }
        [Display(Name = "Captain ID")]
        public int? captainID { get; set; }
        [Display(Name = "Division ID")]
        public int? divisionID { get; set; }
        public string division { get; set; }
    }
}