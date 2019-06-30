using ClassLibrary.Database;

namespace ClassLibrary.Logic.TeamPlayerLogic
{
    public interface ITeamPlayersDelete
    {
        void TeamPlayersRemove(TeamPlayer teamPlayer);
        void TeamPlayersRemove(int playerID, int teamID);
    }
}