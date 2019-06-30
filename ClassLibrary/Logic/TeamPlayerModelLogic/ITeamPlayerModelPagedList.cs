using ClassLibrary.Models;
using PagedList;

namespace ClassLibrary.Logic.TeamPlayerModelLogic
{
    public interface ITeamPlayerModelPagedList
    {
        IPagedList<TeamPlayerModel> GetTeamPlayerModelPagedList(int teamID, int? pageNumber, int? pageSize);
    }
}