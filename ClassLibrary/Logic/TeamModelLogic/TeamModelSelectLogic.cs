using ClassLibrary.Database;
using ClassLibrary.Models;
using System.Data.Entity;
using System.Linq;

namespace ClassLibrary.Logic.TeamModelLogic
{
    public class TeamModelSelectLogic : ITeamModelSelectLogic
    {
        public TeamModel GetTeamModel(int teamID)
        {
            TeamModel teamModel = new TeamModel();

            using (NetballEntities context = new NetballEntities())
            {
                teamModel = context.Teams
                    .Include(t => t.TeamPlayers)
                    .Include(t => t.Coaches)
                    .Where(t => t.TeamID == teamID)
                    .Select(t => new TeamModel
                    {
                        teamName = t.TeamName,
                        coachPersonID = t.CoachID ?? 0,
                        coachName = t.Person.FirstName + " " + t.Person.LastName,
                        divisionID = t.DivisionID ?? 0,
                        divisionName = t.Division.Division1,
                        captainID = t.CaptainID ?? 0,
                        captainName = t.Person1.FirstName + " " + t.Person1.LastName
                    })
                    .FirstOrDefault();
            }
            return teamModel;
        }
    }
}
