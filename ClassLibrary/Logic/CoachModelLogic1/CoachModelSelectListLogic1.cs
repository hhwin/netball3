using ClassLibrary.Database;
using ClassLibrary.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary.Logic.CoachModelLogic1
{
    public class CoachModelSelectListLogic1 : ICoachModelSelectListLogic1
    {
        public IList<CoachModel> GetCoachModelSelectList()
        {
            IList<CoachModel> coachModelList = new List<CoachModel>();

            using (NetballEntities context = new NetballEntities())
            {
                coachModelList = context.Teams
                    .Include(c => c.Person)
                    .Include(c => c.Division)
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
                        divisionID = c.DivisionID,
                        division = c.Division.Division1
                    })
                    .OrderBy(c => c.coachName)
                    .ToList();
            }
            return coachModelList;
        }
    }
}
