using ClassLibrary.Database;
using ClassLibrary.Logic.GamePlayerLogic;
using ClassLibrary.Models;

namespace ClassLibrary.Logic.GameTeamPlayerModelLogic
{
    public class GameTeamPlayerModelInsert : IGameTeamPlayerModelInsert
    {
        IGamePlayerParse _gamePlayerParse;
        IGamePlayerInsert _gamePlayerInsert;

        public GameTeamPlayerModelInsert(IGamePlayerParse gamePlayerParse,
            IGamePlayerInsert gamePlayerInsert)
        {
            _gamePlayerParse = gamePlayerParse;
            _gamePlayerInsert = gamePlayerInsert;
        }

        public void GameTeamPlayerInsertLogic(GameTeamPlayerModel gameTeamPlayerModel)
        {
            GamePlayer gamePlayer;

            gamePlayer = _gamePlayerParse.GamePlayerParseLogic(gameTeamPlayerModel);
            _gamePlayerInsert.GamePlayerAdd(gamePlayer);
        }
    }
}