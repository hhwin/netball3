using ClassLibrary.Logic.GameModelListLogic;
using ClassLibrary.Models;
using PagedList;
using System.Collections.Generic;
using System;

namespace ClassLibrary.Logic.GameIndexModelLogic
{
    public class GameIndexModelParameterLogic : IGameIndexModelParameterLogic
    {
        private const int pageSize = 5;
        private IGameModelListParameterLogic _gameModelListParameterLogic;

        public GameIndexModelParameterLogic(IGameModelListParameterLogic gameModelListParameterLogic)
        {
            _gameModelListParameterLogic = gameModelListParameterLogic;
        }
        private IPagedList<GameModel> GetPagedListParameter(int teamID, int divisionID, int? page, DateTime? datePlayed)
        {
            IList<GameModel> gameModelList;
            gameModelList = _gameModelListParameterLogic.GetGameModelListParameter(teamID, divisionID, datePlayed);

            if (gameModelList != null && gameModelList.Count > 0)
            {
                int pageNumber = (page ?? 1);
                return gameModelList.ToPagedList(pageNumber, pageSize);
            }
            return null;
        }
        public GameIndexModel GetGameIndexModelParameter(int? teamID,
            int? divisionID,
            int? page,
            DateTime? datePlayed)
        {
            GameIndexModel gameIndexModel = new GameIndexModel();
            gameIndexModel.teamID = teamID??0;
            gameIndexModel.divisionID = divisionID??0;
            gameIndexModel.datePlayed = datePlayed;
            gameIndexModel.GamePagedList = GetPagedListParameter(teamID ?? 0, divisionID ?? 0, page, datePlayed);
            return gameIndexModel;
        }
    }
}

