using System.Collections.Generic;

namespace ClassLibrary.Logic.Team
{
    public interface ITeamSelectLogic
    {
        Database.Team GetTeam(int teamID);
        Database.Team GetTeam(string teamName);
        IList<Database.Team> GetTeamList();
    }
}