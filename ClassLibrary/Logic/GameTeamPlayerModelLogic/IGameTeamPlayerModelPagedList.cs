using ClassLibrary.Models;
using PagedList;

namespace ClassLibrary.Logic.GameTeamPlayerModelLogic
{
    public interface IGameTeamPlayerModelPagedList
    {
        IPagedList<GameTeamPlayerModel> GetPagedList(int gameTeamID, int? page, int pageSize = 6);
    }
}