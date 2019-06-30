using ClassLibrary.Models;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Model
{
    public class PersonModel : AbstractPersonModel, IPersonModel
    {        
         [Display(Name = "Person Name")]
        public override string GetPersonName(string firstName,
            string lastName)
        {
            return firstName + " " + lastName;
        }
    }
}