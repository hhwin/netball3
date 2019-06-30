using ClassLibrary.Database;

namespace ClassLibrary.Logic.TeamPlayerLogic
{
    public interface ITeamPlayersSaveLogic
    {
        void TeamPlayerSave(TeamPlayer teamPlayer, ref string message);
    }
}