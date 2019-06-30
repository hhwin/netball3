using ClassLibrary.Database;
using ClassLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using LinqKit;
using ClassLibrary.Logic.GameModelLogic;
using System.Data.Entity;

namespace ClassLibrary.Logic.GameModelListLogic
{
    public class GameModelListParameterLogic : IGameModelListParameterLogic
    {
        /// <summary>
        /// Get game model list by team ID and/or divisionID
        /// </summary>
        /// <param name="teamID"></param>
        /// <returns></returns>
        private IGameModelSelectLogic _gameModelSelectLogic;

        public GameModelListParameterLogic(IGameModelSelectLogic gameModelSelectLogic)
        {
            _gameModelSelectLogic = gameModelSelectLogic;
        }

        public IList<GameModel> GetGameModelListParameter(int teamID, int divisionID, DateTime? datePlayed)
        {
            IList<GameTeam> gameTeamList;
            GameModel gameModel;
            IList<GameModel> gameModelList = new List<GameModel>();
            var predicate = PredicateBuilder.New<GameTeam>(true);

            if (teamID > 0)
            {
                predicate = predicate.And(g => g.TeamID == teamID);
            }
            if (datePlayed != null)
            {
                predicate = predicate.And(g => g.Game.DatePlayed >= datePlayed);
            }

            using (NetballEntities context = new NetballEntities())
            {
                gameTeamList = context.GameTeams
                    .Include(g => g.Game)
                    .Where(predicate)
                    .OrderBy(g => g.Game.DatePlayed)
                    .Take(100)
                    .ToList();
            }

            foreach(GameTeam gameTeam in gameTeamList)
            {
                gameModel = _gameModelSelectLogic.GetGameModel(gameTeam.GameID);

                if (gameModel != null)
                {
                    gameModelList.Add(gameModel);
                }
            }           
            return gameModelList;
        }
    }
}
