using PagedList;
using System;

namespace ClassLibrary.Logic.GameModelListLogic
{
    public class GameModelPagedListLogic : IGameModelPagedListLogic
    {
        private IGameModelListParameterLogic _gameModelListParameterLogic;

        public GameModelPagedListLogic(IGameModelListParameterLogic gameModelListParameterLogic)
        {
            _gameModelListParameterLogic = gameModelListParameterLogic;
        }
        public IPagedList GetGameModelPagedList(int teamID, 
            int divisionID,
            DateTime? datePlayed,
            int? page)
        {
            IPagedList gameModelPagedList;
            int pageNumber = page ?? 1;
            const int pageSize = 5;

            gameModelPagedList = _gameModelListParameterLogic.GetGameModelListParameter(teamID, divisionID, null).ToPagedList(pageNumber, pageSize);
            return gameModelPagedList;
        }
    }
}
