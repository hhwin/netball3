using System;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models
{
    public class AwardPersonModel
    {
        [Required]
        [Key]
        [Range(1, int.MaxValue, ErrorMessage = "AwardPersonID must be 1 or greater")]
        public int AwardPersonID { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "AwardID must be 1 or greater")]
        public int AwardID { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Award name must be at least 3 characters and at most 100 characters.")]
        public string AwardName { get; set; }
        [Required]
        public int PersonID { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage ="First name must be at least 2 characters and at most 100 characters.")]
        public string FirstName { get; set; }
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Last name must be at least 2 characters and at most 100 characters.")]
        public string LastName { get; set; }
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Maiden name must be at least 2 characters and at most 100 characters.")]
        public string MaidenName { get; set; }
        [Required]
        [Range(1980, 2025, ErrorMessage ="Year must be between 1980 to 2025 inclusive")]
        public int YearOfAward { get; set; }
        public DateTime? DateOfAward { get; set; }
        [StringLength(8000, ErrorMessage = "Comments must be 8,000 characters or less")]
        public string Comments { get; set; }
    }
}
