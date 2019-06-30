using ClassLibrary.Database;
using ClassLibrary.Logic.GamePlayerLogic;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.GameTeamPlayerModelLogic
{
    public class GameTeamPlayerModelDelete : IGameTeamPlayerModelDelete
    {
        IGamePlayerParse _gamePlayerParse;
        IGamePlayerDelete _gamePlayerDelete;

        public GameTeamPlayerModelDelete(IGamePlayerParse gamePlayerParse,
            IGamePlayerDelete gamePlayerDelete)
        {
            _gamePlayerParse = gamePlayerParse;
            _gamePlayerDelete = gamePlayerDelete;
        }

        public void GameTeamPlayerDeleteLogic(GameTeamPlayerModel gameTeamPlayerModel)
        {
            GamePlayer gamePlayer;

            gamePlayer = _gamePlayerParse.GamePlayerParseLogic(gameTeamPlayerModel);
            _gamePlayerDelete.GamePlayerRemove(gamePlayer);
        }

        public void GameTeamPlayerDeleteLogic(int gamePlayerID)
        {
            _gamePlayerDelete.GamePlayerRemove(gamePlayerID);
        }
    }
}