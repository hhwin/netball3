using ClassLibrary.Models;

namespace ClassLibrary.Logic.GameTeamPlayerModelLogic
{
    public interface IGameTeamPlayerModelDelete
    {
        void GameTeamPlayerDeleteLogic(GameTeamPlayerModel gameTeamPlayerModel);
        void GameTeamPlayerDeleteLogic(int gamePlayerID);
    }
}