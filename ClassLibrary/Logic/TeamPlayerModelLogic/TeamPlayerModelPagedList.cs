using ClassLibrary.Models;
using PagedList;

namespace ClassLibrary.Logic.TeamPlayerModelLogic
{
    public class TeamPlayerModelPagedList : ITeamPlayerModelPagedList
    {
        private TeamPlayerModelPagedList _teamPlayerModelPagedList;

        public TeamPlayerModelPagedList(TeamPlayerModelPagedList teamPlayerModelPagedList)
        {
            _teamPlayerModelPagedList = teamPlayerModelPagedList;
        }
        public IPagedList<TeamPlayerModel> GetTeamPlayerModelPagedList(int teamID,
            int? pageNumber,
            int? pageSize)
        {
            IPagedList<TeamPlayerModel> teamPlayerModelList;
            teamPlayerModelList = _teamPlayerModelPagedList.GetTeamPlayerModelPagedList(teamID, pageNumber, pageSize);
            return teamPlayerModelList.ToPagedList(pageNumber??1, pageSize??10);
        }
    }
}
