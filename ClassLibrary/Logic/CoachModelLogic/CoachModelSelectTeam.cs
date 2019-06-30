using ClassLibrary.Database;
using ClassLibrary.Models;
using System.Linq;
using System.Data.Entity;

namespace ClassLibrary.Logic.CoachModelLogic
{
    public class CoachModelSelectTeam : ICoachModelSelectTeam
    {
        public CoachModel GetCoachModelSelectTeam(int teamID)
        {
            CoachModel coachModel = new CoachModel();
            using (NetballEntities context = new NetballEntities())
            {
                coachModel = context.Coaches
                    .Include(c => c.Person)
                    .Include(c => c.Team)
                    .Where(c => c.TeamID == teamID)
                    .Select (c => new CoachModel
                    {
                        personID = c.CoachID,
                        teamID = c.TeamID,
                        firstName = c.Person.FirstName,
                        middleName = c.Person.MiddleName,
                        lastName = c.Person.LastName,
                        mobile = c.Person.Mobile,
                        email = c.Person.Email,
                        emergencyContact = c.Person.EmergencyContact,
                        emergencyContactNo = c.Person.EmergencyContactNo,
                        teamName = c.Team.TeamName,
                        coachName = c.Person.FirstName + " " + c.Person.LastName,
                        activeInd = c.ActiveInd
                    })
                .FirstOrDefault();
            }
            return coachModel;
        }
    }
}
