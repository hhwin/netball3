using ClassLibrary.Database;
using ClassLibrary.Logic.GameTeamLogic;
using ClassLibrary.Models;
using System.Collections.Generic;

namespace ClassLibrary.Logic.GameTeamModelLogic
{
    public class GameTeamModelSelectList : IGameTeamModelSelectList
    {
        private GameTeamSelect _gameTeamSelect;
        private GameTeamModelSelect _gameTeamModelSelect;

        public GameTeamModelSelectList(GameTeamSelect gameTeamSelect,
            GameTeamModelSelect gameTeamModelSelect)
        {
            _gameTeamSelect = gameTeamSelect;
            _gameTeamModelSelect = gameTeamModelSelect;
        }
        public IList<GameTeamModel> GetGameTeamModelSelectList(int teamID)
        {
            IList<GameTeam> gameTeamList = _gameTeamSelect.GetGameTeamByTeamID(teamID);
            IList<GameTeamModel> gameTeamModelList = new List<GameTeamModel>();
            GameTeamModel gameTeamModel;

            foreach(GameTeam gameTeam in gameTeamList)
            {
                gameTeamModel = new GameTeamModel();
                gameTeamModel = _gameTeamModelSelect.GetGameTeamModel(gameTeam.GameTeamID);
                gameTeamModelList.Add(gameTeamModel);
            }
            return gameTeamModelList;
        }
    }
}
