using ClassLibrary.Models;

namespace ClassLibrary.Logic.GameIndexModelLogic
{
    public interface IGameIndexModelTeamLogic
    {
        GameIndexModel GetGameIndexModelByTeam(int? teamID, int? page);
    }
}