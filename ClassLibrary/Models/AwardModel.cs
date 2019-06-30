using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models
{
    public class AwardModel
    {
        [Key]
        [Required]
        public int AwardID { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Award name must be at least 3 characters and at most 100 characters")]
        public string AwardName { get; set; }
        public bool? ActiveInd { get; set; }
        public string Comments { get; set; }
    }
}
