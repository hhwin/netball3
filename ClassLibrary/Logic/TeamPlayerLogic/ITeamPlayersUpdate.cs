using ClassLibrary.Database;

namespace ClassLibrary.Logic.TeamPlayerLogic
{
    public interface ITeamPlayersUpdate
    {
        int? TeamPlayersUpdateTransaction(TeamPlayer TeamPlayer);
    }
}