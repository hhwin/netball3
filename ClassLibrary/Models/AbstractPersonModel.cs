using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Model
{
    public abstract class AbstractPersonModel
    {
        /// <summary>
        /// This is used purely to demonstrate abstract class.
        /// </summary>
        [Key]
        public int personID { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string firstName { get; set; }

        [Display(Name = "Middle Name")]
        public string middleName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string lastName { get; set; }

        [Display(Name = "Mobile No")]
        public string mobile { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Emergency Contact")]
        public string emergencyContact { get; set; }

        [Display(Name = "Emerg. Contact No,")]
        public string emergencyContactNo { get; set; }

        public string GetInitialAndName(string firstName,
            string lastName)
        {
            return firstName.Substring(0, 1) + " " + lastName;
        }
        public abstract string GetPersonName(string firstName,
            string lastName);
        // Not allowed to implement code in abstract class.
        //{
        //    return firstName + " " + lastName;
        //}
    }  
}