using ClassLibrary.Database;
using ClassLibrary.Logic.GamePlayerLogic;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.GameTeamPlayerModelLogic
{
    public class GameTeamPlayerModelUpdate : IGameTeamPlayerModelUpdate
    {
        IGamePlayerParse _gamePlayerParse;
        IGamePlayerUpdate _gamePlayerUpdate;

        public GameTeamPlayerModelUpdate(IGamePlayerParse gamePlayerParse,
            IGamePlayerUpdate gamePlayerUpdate)
        {
            _gamePlayerParse = gamePlayerParse;
            _gamePlayerUpdate = gamePlayerUpdate;
        }

        public void GameTeamPlayerUpdateLogic(GameTeamPlayerModel gameTeamPlayerModel)
        {
            GamePlayer gamePlayer;

            gamePlayer = _gamePlayerParse.GamePlayerParseLogic(gameTeamPlayerModel);
            _gamePlayerUpdate.GamePlayerUpdateTransaction(gamePlayer);
        }

    }
}