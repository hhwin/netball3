using System.Collections.Generic;

namespace ClassLibrary.Logic.GameTeamLogic
{
    public interface IGameTeamSelect
    {
        Database.GameTeam GetGameTeam(int gameteamID);
        IList<Database.GameTeam> GetGameTeamList();
        IList<Database.GameTeam> GetGameTeamList(int gameID);
    }
}