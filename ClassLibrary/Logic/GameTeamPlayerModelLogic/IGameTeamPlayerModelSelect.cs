using ClassLibrary.Models;

namespace ClassLibrary.Logic.GameTeamPlayerModelLogic
{
    public interface IGameTeamPlayerModelSelect
    {
        GameTeamPlayerModel GetGameTeamPlayerModel(int gameTeamID, int playerID);
        GameTeamPlayerModel GetGameTeamPlayerModel(int gamePlayerID);
        GameTeamPlayerModel GetNewGameTeamPlayerModel(int gameTeamID);
    }
}