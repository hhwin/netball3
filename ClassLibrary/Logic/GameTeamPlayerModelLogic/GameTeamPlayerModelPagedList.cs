using ClassLibrary.Models;
using PagedList;
using System.Collections.Generic;

namespace ClassLibrary.Logic.GameTeamPlayerModelLogic
{
    public class GameTeamPlayerModelPagedList : IGameTeamPlayerModelPagedList
    {
        private IGameTeamPlayerModelSelectList _gameTeamPlayerModelSelectList;

        public GameTeamPlayerModelPagedList(IGameTeamPlayerModelSelectList gameTeamPlayerModelSelectList)
        {
            _gameTeamPlayerModelSelectList = gameTeamPlayerModelSelectList;
        }

        public IPagedList<GameTeamPlayerModel>GetPagedList(int gameTeamID,
            int? page, 
            int pageSize = 6)
        {
            IList<GameTeamPlayerModel> gameTeamPlayerModelList;
            int pageNumber = page ?? 1;

            gameTeamPlayerModelList = _gameTeamPlayerModelSelectList.GetGameTeamPlayerModelList(gameTeamID);

            if (gameTeamPlayerModelList != null && gameTeamPlayerModelList.Count > 0)
            {
                return gameTeamPlayerModelList.ToPagedList(pageNumber, pageSize);
            }
            return null;
        }
    }
}
