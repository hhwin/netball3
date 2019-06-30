using ClassLibrary.Database;
using ClassLibrary.Logic.Game;
using ClassLibrary.Logic.GameTeamLogic;
using ClassLibrary.Models;
using System.Collections.Generic;

namespace ClassLibrary.Logic.GameModelLogic
{
    public class GameModelUpdateLogic : IGameModelUpdateLogic
    {
        private IGameUpdate _gameUpdate;
        private IGameParse _gameParse;
        private IGameTeamParse _gameTeamParse;
        private IGameTeamUpdate _gameTeamUpdate;

        public GameModelUpdateLogic(IGameUpdate gameUpdate,
            IGameParse gameParse,
            IGameTeamParse gameTeamParse,
            IGameTeamUpdate gameTeamUpdate)
        {
            _gameUpdate = gameUpdate;
            _gameParse = gameParse;
            _gameTeamParse = gameTeamParse;
            _gameTeamUpdate = gameTeamUpdate;
        }
        public void GameModelUpdate(GameModel gameModel)
        {
            Database.Game game;
            IList<GameTeam> gameTeamList;

            game = _gameParse.ParseGame(gameModel);
            _gameUpdate.GameUpdateTransaction(game);
            gameTeamList = _gameTeamParse.ParseGameTeam(gameModel);
            foreach (GameTeam gameTeam in gameTeamList)
            {
                _gameTeamUpdate.GameTeamUpdateTransaction(gameTeam);
            }
        }
    }
}