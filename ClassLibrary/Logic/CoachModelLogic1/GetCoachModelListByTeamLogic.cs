using ClassLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ClassLibrary.Database;

namespace ClassLibrary.Logic.CoachModelLogic1
{
    public class GetCoachModelListByTeamLogic : IGetCoachModelListByTeamLogic
    {
        public IList<CoachModel>GetCoachModelByTeamName(string teamName)
        {
            IList<CoachModel> coachModelList = new List<CoachModel>();

            using (NetballEntities context = new NetballEntities())
            {
                coachModelList = context.Teams
                    .Include(c => c.Person)
                    .Where(c => c.TeamName == teamName)
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
            return coachModelList;
        }

        public IList<CoachModel>GetCoachModelByTeamID(int teamID)
        {
            IList<CoachModel> coachModelList = new List<CoachModel>();

            using (NetballEntities context = new NetballEntities())
            {
                coachModelList = context.Teams
                    .Include(c => c.Person)
                    .Where(c => c.TeamID == teamID)
                    .Select(c => new CoachModel
                    {
                        captainID = c.CaptainID,
                        coachName = c.Person.FirstName + " " + c.Person.LastName,
                        divisionID = c.DivisionID,
                        email = c.Person.Email,
                        emergencyContact = c.Person.EmergencyContact,
                        emergencyContactNo = c.Person.EmergencyContactNo,
                        firstName = c.Person.FirstName,
                        lastName = c.Person.LastName,
                        middleName = c.Person.MiddleName,
                        mobile = c.Person.Mobile,
                        personID = c.Person.PersonID,
                        teamID = c.TeamID,
                        teamName = c.TeamName
                    })
                    .ToList();
            }
            return coachModelList;
        }
    }
}
