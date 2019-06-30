using ClassLibrary.Database;
using ClassLibrary.Models;
using System.Linq;
using System.Data.Entity;

namespace ClassLibrary.Logic.CoachModelLogic1
{
    public class GetCoachModelLogic1 : IGetCoachModelLogic1
    {
        public CoachModel GetCoach(int coachID)
        {
            CoachModel coachModel = new CoachModel();

            using (NetballEntities context = new NetballEntities())
            {
                coachModel = context.Coaches
                    .Include(c => c.Person)
                    .Include(c => c.Team.Division)
                    .Include(c => c.Team)
                    .Select(c => new CoachModel
                    {
                        coachName = c.Person.FirstName + " " + c.Person.LastName,
                        divisionID = c.Team.DivisionID,
                        division = c.Team.Division.Division1,
                        email = c.Person.Email,
                        //emergencyContact = c.
                        firstName = c.Person.FirstName,
                        lastName = c.Person.LastName,
                        middleName = c.Person.MiddleName,
                        mobile = c.Person.Mobile,
                        personID = c.CoachPersonID,
                        teamID = c.TeamID,
                        teamName = c.Team.TeamName
                    })
                    .FirstOrDefault();
            }
            return coachModel;
        }
    }
}
