using ClassLibrary.Models;
using System;

namespace ClassLibrary.Logic.GameIndexModelLogic
{
    public class GameIndexModelInitialiseLogic : IGameIndexModelInitialiseLogic
    {
        private IGameIndexModelParameterLogic _gameIndexModelParameterLogic;

        public GameIndexModelInitialiseLogic(IGameIndexModelParameterLogic gameIndexModelParameterLogic)
        {
            _gameIndexModelParameterLogic = gameIndexModelParameterLogic;
        }
        public GameIndexModel InitialiseGameIndexModel(int? teamID, 
            int? divisionID, 
            DateTime? datePlayed,
            int? page)
        {
            GameIndexModel gameIndexModel = new GameIndexModel();

            try
            {
                gameIndexModel.teamID = teamID ?? 0;
                gameIndexModel.divisionID = divisionID ?? 0;
                gameIndexModel.datePlayed = datePlayed;
                gameIndexModel = _gameIndexModelParameterLogic.GetGameIndexModelParameter(teamID, divisionID, page, datePlayed);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return gameIndexModel;
        }
    }
}
