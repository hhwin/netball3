using ClassLibrary.Database;
using ClassLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace ClassLibrary.Logic.CoachModelLogic1
{
    public class GetCoachModelListByEmailLogic : IGetCoachModelListByEmailLogic
    {
        public IList<CoachModel> GetCoachModelListByEmail(string email)
        {
            IList<CoachModel> coachModelList = new List<CoachModel>();

            using (NetballEntities context = new NetballEntities())
            {
                coachModelList = context.Teams
                    .Include(t => t.Person)
                    .Where(t => t.Person.Email.ToLower().Contains(email.ToLower()))
                    .Select(t => new CoachModel
                    {
                        captainID = t.CaptainID,
                        coachName = t.Person.FirstName + " " + t.Person.LastName,
                        divisionID = t.DivisionID,
                        email = t.Person.Email,
                        emergencyContact = t.Person.EmergencyContact,
                        emergencyContactNo = t.Person.EmergencyContactNo,
                        firstName = t.Person.FirstName,
                        lastName = t.Person.LastName,
                        middleName = t.Person.MiddleName,
                        mobile = t.Person.Mobile,
                        personID = t.Person.PersonID,
                        teamID = t.TeamID,
                        teamName = t.TeamName
                    })
                    .ToList();
            }
            return coachModelList;
        }
    }
}
