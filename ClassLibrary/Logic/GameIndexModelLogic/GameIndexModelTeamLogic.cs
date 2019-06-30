using ClassLibrary.Database;
using ClassLibrary.Models;
using System.Linq;
using System.Data.Entity;
using PagedList;
using ClassLibrary.Logic.GameModelListLogic;
using System.Collections.Generic;

namespace ClassLibrary.Logic.GameIndexModelLogic
{
    public class GameIndexModelTeamLogic : IGameIndexModelTeamLogic
    {
        private const int pageSize = 7;
        private IGameModelListByTeamLogic _gameModelListByTeamLogic;

        public GameIndexModelTeamLogic(IGameModelListByTeamLogic gameModelListByTeamLogic)
        {
            _gameModelListByTeamLogic = gameModelListByTeamLogic;
        }
        private IPagedList<GameModel>GetPagedListByTeamID(int? teamID, int? page)
        {
            IList<GameModel> gameModelList;

            if (teamID != null)
            {
                gameModelList = _gameModelListByTeamLogic.GetGameModelListByTeam((int)teamID);

                if (gameModelList != null && gameModelList.Count > 0)
                {
                    int pageNumber = (page ?? 1);
                    return gameModelList.ToPagedList(pageNumber, pageSize);
                }
            }
            return null;
        }
        public GameIndexModel GetGameIndexModelByTeam(int? teamID, int? page)
        {
            GameIndexModel gameIndexModel = new GameIndexModel();

            using (NetballEntities context = new NetballEntities())
            {
                gameIndexModel = context.GameTeams
                    .Include(g => g.Team)
                    .Where(g => g.TeamID == teamID)
                        .Select(g => new GameIndexModel
                        {
                            teamID = g.TeamID,
                            teamName = g.Team.TeamName
                        })
                        .FirstOrDefault();
            }
            if (gameIndexModel != null)
            {
                gameIndexModel.GamePagedList = GetPagedListByTeamID(teamID, page);
            }
            return gameIndexModel;
        }
    }
}