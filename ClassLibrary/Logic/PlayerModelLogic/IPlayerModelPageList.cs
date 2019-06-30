using ClassLibrary.Models;
using PagedList;

namespace ClassLibrary.Logic.PlayerModelLogic
{
    public interface IPlayerModelPageList
    {
        IPagedList<PlayerModel> GetPageList(int teamID, int? page, int? pageSize = 6);
    }
}