using ClassLibrary.Database;
using ClassLibrary.Logic.Team;
using ClassLibrary.Models;
using System.Linq;

namespace ClassLibrary.Logic.CoachModelLogic
{
    public class CoachModelSelectLogic : ICoachModelSelectLogic
    {
        /// <summary>
        /// Get coach model for a given personID even if the person is not a coach.
        /// </summary>
        /// <param name="personID"></param>
        /// <returns></returns>
        private ITeamSelectLogic _teamSelectLogic;

        public CoachModelSelectLogic(ITeamSelectLogic teamSelectLogic)
        {
            _teamSelectLogic = teamSelectLogic;
        }
        public CoachModel CoachModelSelect(int personID)
        {
            CoachModel coachModel = new CoachModel();
            Database.Team team = new Database.Team();

            using (NetballEntities context = new NetballEntities())
            {
                coachModel = (from p in context.People
                              where p.PersonID == personID
                              from t in context.Teams.Where(t => t.CoachID == p.PersonID).DefaultIfEmpty()
                              select new CoachModel
                              {
                                  personID = p.PersonID,
                                  //teamID = t.TeamID,
                                  firstName = p.FirstName,
                                  middleName = p.MiddleName,
                                  lastName = p.LastName,
                                  mobile = p.Mobile,
                                  email = p.Email,
                                  emergencyContact = p.EmergencyContact,
                                  emergencyContactNo = p.EmergencyContactNo,
                                  teamName = t.TeamName,
                                  coachName = p.FirstName + " " + p.LastName,
                                  captainID = t.CaptainID,
                                  divisionID = t.DivisionID
                              })
                              .FirstOrDefault();
            }

            if (!string.IsNullOrEmpty(coachModel.teamName))
            {
                team = _teamSelectLogic.GetTeam(coachModel.teamName);

                if (team != null)
                {
                    coachModel.teamID = team.TeamID;
                }
            }
            return coachModel;
        }
    }
}