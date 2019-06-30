using PagedList;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models
{
    public class CoachIndexModel
    {
        [Display(Name ="Coach ID")]
        public int coachID { get; set; }
        [Display(Name="First Name")]
        public string firstName { get; set; }
        [Display(Name ="Middle Name")]
        public string middleName { get; set; }
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Display(Name = "Team Name")]
        public int? teamID { get; set; }
        public string teamName { get; set; }
        [Display(Name = "Mobile")]
        public string mobile { get; set; }
        [Display(Name = "Emergency Contact")]
        public string emergencyContact { get; set; }
        [Display(Name = "Emergency Contact ID")]
        public string emergencyContactNo { get; set; }
        [Display(Name = "Coach Name")]
        public string coachName { get; set; }
        [Display(Name = "Division ID")]
        public int? divisionID { get; set; }
        [Display(Name = "Division")]
        public string division { get; set; }
        [Display(Name = "Active Ind")]
        public bool? activeInd { get; set; }

        public IPagedList<CoachModel>coachPagedList { get; set; }
    }
}
