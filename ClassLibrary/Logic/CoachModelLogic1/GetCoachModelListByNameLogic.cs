using ClassLibrary.Database;
using ClassLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace ClassLibrary.Logic.CoachModelLogic1
{
    public class GetCoachModelListByNameLogic : IGetCoachModelListByNameLogic
    {
        public IList<CoachModel>GetCoachModelListByFirstName(string firstName)
        {
            IList<CoachModel> coachModelList = new List<CoachModel>();

            if (!string.IsNullOrEmpty(firstName))
            {

                using (NetballEntities context = new NetballEntities())
                {
                    coachModelList = context.Teams
                        .Include(c => c.Person)
                        .Where(c => c.Person.FirstName.ToLower().StartsWith(firstName.ToLower()))
                        .Select(c => new CoachModel
                        {
                            personID = c.Person.PersonID,
                            teamID = c.TeamID,
                            firstName = c.Person.FirstName,
                            middleName = c.Person.MiddleName,
                            lastName = c.Person.LastName,
                            email = c.Person.Email,
                            emergencyContact = c.Person.EmergencyContact,
                            emergencyContactNo = c.Person.EmergencyContactNo,
                            coachName = c.Person.FirstName + " " + c.Person.LastName,
                            teamName = c.TeamName,
                            captainID = c.CaptainID,
                            divisionID = c.DivisionID
                        })
                            .ToList();
                }
            }
            return coachModelList;
        }
        public IList<CoachModel> GetCoachModelListByLastName(string lastName)
        {
            IList<CoachModel> coachModelList = new List<CoachModel>();

            if (!string.IsNullOrEmpty(lastName))
            {

                using (NetballEntities context = new NetballEntities())
                {
                    coachModelList = context.Teams
                        .Include(c => c.Person)
                        .Where(c => c.Person.LastName.ToLower().StartsWith(lastName.ToLower()))
                        .Select(c => new CoachModel
                        {
                            personID = c.Person.PersonID,
                            teamID = c.TeamID,
                            firstName = c.Person.FirstName,
                            middleName = c.Person.MiddleName,
                            lastName = c.Person.LastName,
                            email = c.Person.Email,
                            emergencyContact = c.Person.EmergencyContact,
                            emergencyContactNo = c.Person.EmergencyContactNo,
                            coachName = c.Person.FirstName + " " + c.Person.LastName,
                            teamName = c.TeamName,
                            captainID = c.CaptainID,
                            divisionID = c.DivisionID
                        })
                        .ToList();
                }
            }
            return coachModelList;
        }

        public IList<CoachModel> GetCoachModelListByName(string lastName,
        string firstName)
        {
            IList<CoachModel> coachModelList = new List<CoachModel>();

            if (!string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(firstName))
            {
                using (NetballEntities context = new NetballEntities())
            {
                    coachModelList = context.Teams
                        .Include(c => c.Person)
                        .Where(c => c.Person.FirstName == firstName && c.Person.LastName == lastName)
                        .Select(c => new CoachModel
                        {
                            personID = c.Person.PersonID,
                            teamID = c.TeamID,
                            firstName = c.Person.FirstName,
                            middleName = c.Person.MiddleName,
                            lastName = c.Person.LastName,
                            email = c.Person.Email,
                            emergencyContact = c.Person.EmergencyContact,
                            emergencyContactNo = c.Person.EmergencyContactNo,
                            coachName = c.Person.FirstName + " " + c.Person.LastName,
                            teamName = c.TeamName,
                            captainID = c.CaptainID,
                            divisionID = c.DivisionID
                        })
                            .ToList();
                }
            }
            else
            {

            }

            return coachModelList;
        }
    }
}
