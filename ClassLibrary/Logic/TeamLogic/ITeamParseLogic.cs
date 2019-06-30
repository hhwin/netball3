using ClassLibrary.Models;

namespace ClassLibrary.Logic.TeamLogic
{
    public interface ITeamParseLogic
    {
        Database.Team ParseTeam(CoachModel coachModel);
    }
}