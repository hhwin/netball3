using ClassLibrary.Models;
using PagedList;
using System.Collections.Generic;

namespace ClassLibrary.Logic.PlayerModelLogic
{
    public class PlayerModelPageList : IPlayerModelPageList
    {
        private IPlayerModelListLogic _playerModelListLogic;

        public PlayerModelPageList(IPlayerModelListLogic playerModelListLogic)
        {
            _playerModelListLogic = playerModelListLogic;
        }

        public IPagedList<PlayerModel> GetPageList(int teamID, int? page, int? pageSize = 6)
        {
            int pageNumber = page ?? 1;
            IList<PlayerModel> playerModelList = _playerModelListLogic.GetPlayerModelList(teamID);

            if (playerModelList != null)
            {
                return playerModelList.ToPagedList(pageNumber, (int)pageSize);
            }
            return null;
        }
    }
}
