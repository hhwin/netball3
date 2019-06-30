using ClassLibrary.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary.Models
{
    public class PlayerModel : AbstractPersonModel, IPersonModel
    {
        //[Key, Column(Order = 0)]
        [Key, Column(Order = 1)]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a team")]
        [Display(Name = "Team ID")]
        public int teamID { get; set; }
        //[Display(Name = "First Name")]
        //[Required]
        //public string firstName { get; set; }
        //[Display(Name = "Middle Name")]
        //public string middleName { get; set; }
        //[Display(Name = "Last Name")]
        //[Required]
        //public string lastName { get; set; }
        //[Display(Name = "Mobile No")]
        //public string mobile { get; set; }
        //[Display(Name = "Email")]
        //public string email { get; set; }
        //[Display(Name = "Emergency Contact")]
        //public string emergencyContact { get; set; }
        //[Display(Name = "Emerg. Contact No,")]
        //public string emergencyContactNo { get; set; }
        //[Display(Name = "Person ID")]
        //public int personID { get; set; }
        [Display(Name = "Team Name")]
        [Required]
        public string teamName { get; set; }
        [Display(Name = "Captain")]
        public bool captain { get; set; } = false;
        [Display(Name = "Player Name")]
        public string playerName { get; set; }
        [Display(Name = "Player Name")]
        public override string GetPersonName(string firstName,
        string lastName)
        {
            return firstName + " " + lastName;
        }
    }
}