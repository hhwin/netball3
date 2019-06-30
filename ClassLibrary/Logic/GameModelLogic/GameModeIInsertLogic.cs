using ClassLibrary.Database;
using ClassLibrary.Logic.Game;
using ClassLibrary.Logic.GameTeamLogic;
using ClassLibrary.Models;
using System.Collections.Generic;

namespace ClassLibrary.Logic.GameModelLogic
{
    public class GameModeIInsertLogic : IGameModelInsertLogic
    {
        private IGameInsert _gameInsert;
        private IGameParse _gameParse;
        private IGameTeamParse _gameTeamParse;
        private IGameTeamInsert _gameTeamInsert;

        public GameModeIInsertLogic(IGameInsert gameInsert,
            IGameParse gameParse,
            IGameTeamParse gameTeamParse,
            IGameTeamInsert gameTeamInsert)
        {
            _gameInsert = gameInsert;
            _gameParse = gameParse;
            _gameTeamParse = gameTeamParse;
            _gameTeamInsert = gameTeamInsert;
        }
        public void GameModelInsert(GameModel gameModel)
        {
            Database.Game game;
            IList<GameTeam> gameTeamList; 

            game = _gameParse.ParseGame(gameModel);
            game.GameID = _gameInsert.GameAdd(game)??0;
            gameModel.gameID = game.GameID;
            gameTeamList = _gameTeamParse.ParseGameTeam(gameModel);
            foreach(GameTeam gameTeam in gameTeamList)
            {
                _gameTeamInsert.GameTeamAdd(gameTeam);
            }
        }
    }
}