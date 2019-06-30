using ClassLibrary.Database;
using System.Collections.Generic;

namespace ClassLibrary.Logic.TeamPlayerLogic
{
    public interface ITeamPlayersSelect
    {
        TeamPlayer GetTeamPlayer(int TeamPlayerID);
        IList<TeamPlayer> GetTeamPlayerList();
        IList<TeamPlayer> GetTeamPlayerList(int teamID);
        TeamPlayer GetTeamPlayer(int teamID, int playerID);
        TeamPlayer GetTeamPlayerByPlayerID(int playerID);
    }
}