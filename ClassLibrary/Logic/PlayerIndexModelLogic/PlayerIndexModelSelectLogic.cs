using ClassLibrary.Database;
using ClassLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using PagedList;
using ClassLibrary.Logic.PlayerModelLogic;

namespace ClassLibrary.Logic.PlayerIndexModelLogic
{
    public class PlayerIndexModelSelectLogic : IPlayerIndexModelSelectLogic
    {
        private IPlayerModelListLogic _playerModelList;

        public PlayerIndexModelSelectLogic(IPlayerModelListLogic playerModelList)
        {
            _playerModelList = playerModelList;
        }
        private IPagedList<PlayerModel>GetPagedList(string playerName, int? page)
        {
            IList<PlayerModel> playerModelList;
            playerModelList = _playerModelList.GetPlayerModelList(playerName);

            if (playerModelList != null && playerModelList.Count > 0)
            {
                int pageSize = 8;
                int pageNumber = (page ?? 1);
                return playerModelList.ToPagedList(pageNumber, pageSize);
            }
            return null;
        }
        private IPagedList<PlayerModel> GetPagedList(int teamID, int? page)
        {
            IList<PlayerModel> playerModelList;
            playerModelList = _playerModelList.GetPlayerModelList(teamID);

            if (playerModelList != null && playerModelList.Count > 0)
            {
                int pageSize = 8;
                int pageNumber = (page ?? 1);
                return playerModelList.ToPagedList(pageNumber, pageSize);
            }
            return null;
        }
        public PlayerIndexModel GetPlayerIndexModel(int? teamID, int? page)
        {
            PlayerIndexModel playerIndexModel = new PlayerIndexModel();
            using (NetballEntities context = new NetballEntities())
            {
                playerIndexModel = context.TeamPlayers
                    .Include(t => t.Team)
                    .Where(t => t.TeamID == teamID)
                    .Select(t => new PlayerIndexModel
                    {
                        teamID = t.TeamID,
                        teamName = t.Team.TeamName
                    })
                    .FirstOrDefault();
            }
            if (playerIndexModel != null)
            {
                playerIndexModel.PlayerPagedList = GetPagedList(playerIndexModel.teamID, page);
            }
            return playerIndexModel;
        }
        public PlayerIndexModel GetPlayerIndexModel(string playerName, int? page)
        {
            PlayerIndexModel playerIndexModel = new PlayerIndexModel();
            using (NetballEntities context = new NetballEntities())
            {
                playerIndexModel = context.TeamPlayers
                    .Include(t => t.Person)
                    .Include(t => t.Team)
                    .Select(t => new PlayerIndexModel
                    {
                        teamID = t.TeamID,
                        teamName = t.Team.TeamName
                    })
                    .FirstOrDefault();
            }
            if (playerIndexModel != null)
            {
                    playerIndexModel.PlayerPagedList = GetPagedList(playerName, page);
            }
            return playerIndexModel;
        }
    }
}
