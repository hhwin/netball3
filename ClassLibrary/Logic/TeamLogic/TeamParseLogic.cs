using ClassLibrary.Models;

namespace ClassLibrary.Logic.TeamLogic
{
    public class TeamParseLogic : ITeamParseLogic
    {
        public Database.Team ParseTeam(CoachModel coachModel)
        {
            Database.Team team = new Database.Team();

            team.TeamID = coachModel.teamID;
            team.TeamName = coachModel.teamName;
            team.DivisionID = coachModel.divisionID;
            team.CaptainID = coachModel.captainID;
            team.CoachID = coachModel.personID;
            team.TeamName = coachModel.teamName;
            return team;
        }
    }
}
