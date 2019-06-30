using ClassLibrary.Database;
using ClassLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ClassLibrary.Logic.GameTeamLogic;

namespace ClassLibrary.Logic.GameModelListLogic
{
    public class GameModelListByTeamLogic : IGameModelListByTeamLogic
    {
        /// <summary>
        /// Get game model list by team ID.
        /// </summary>
        /// <param name="teamID"></param>
        /// <returns></returns>
        private IGameTeamSelect _gameTeamSelect;

        public GameModelListByTeamLogic(IGameTeamSelect gameTeamSelect)
        {
            _gameTeamSelect = gameTeamSelect;
        }
        public IList<GameModel> GetGameModelListByTeam(int teamID)
        {
            IList<GameModel> gameModelList = new List<GameModel>();
            IList<GameModel> gameModelList2 = new List<GameModel>();
            IList<GameTeam> gameTeamList = new List<GameTeam>();
            using (NetballEntities context = new NetballEntities())
            {
                gameModelList = context.GameTeams
                    .AsNoTracking()
                    .Include(g => g.Team)
                    .Include(g => g.Game)
                    .Include(g => g.Game.Court)
                    .Include(g => g.Game.Division)
                    .Include(g => g.Game.Person)
                    .Include(g => g.Game.Person1)
                    .Include(g => g.Game.Person2)
                    .Include(g => g.Game.Person3)
                    .Include(g => g.Game.Person4)
                    .Include(g => g.Game.Person5)
                    .Include(g => g.Game.Person6)
                    .Include(g => g.Game.Division)
                    .Where(g => g.TeamID == teamID)
                    .Select(g => new GameModel
                    {
                        gameID = g.GameID,
                        courtID = g.Game.CourtID,
                        courtName = g.Game.Court.Court1,
                        tournamentID = g.Game.TournamentID,
                        tournamentName = g.Game.Tournament.Tournament1,
                        matchNo = g.Game.MatchNo,
                        venue = g.Game.Venue,
                        datePlayed = g.Game.DatePlayed,
                        primaryUmpireID = g.Game.PrimaryUmpireID,
                        primaryUmpire = g.Game.Person.FirstName + " " + g.Game.Person.LastName,
                        secondaryUmpireID = g.Game.SecondaryUmpireID,
                        secondaryUmpire = g.Game.Person1.FirstName + " " + g.Game.Person1.LastName,
                        reserveUmpireID = g.Game.ReserveUmpireID,
                        reserveUmpire = g.Game.Person2.FirstName + " " + g.Game.Person2.LastName,
                        startTime = g.Game.StartTime,
                        fullTime = g.Game.FullTime,
                        extraTimeEnd = g.Game.ExtraTimeEnd,
                        scorer1ID = g.Game.Scorer1ID,
                        scorer1 = g.Game.Person3.FirstName + " " + g.Game.Person3.LastName,
                        scorer2ID = g.Game.Scorer2ID,
                        scorer2 = g.Game.Person4.FirstName + " " + g.Game.Person4.LastName,
                        timeKeeper1ID = g.Game.TimeKeeper1ID,
                        timeKeeper1 = g.Game.Person5.FirstName + " " + g.Game.Person5.LastName,
                        timeKeeper2ID = g.Game.TimeKeeper2ID,
                        timeKeeper2 = g.Game.Person6.FirstName + " " + g.Game.Person6.LastName,
                        divisionID = g.Game.DivisionID,
                        division = g.Game.Division.Division1
                    })
                    .ToList();
            }
            if (gameModelList != null && gameModelList.Count > 0)
            {
                foreach (GameModel gameModel in gameModelList)
                {
                    int gameID = gameModel.gameID;
                    gameTeamList = new List<GameTeam>();
                    gameTeamList = _gameTeamSelect.GetGameTeamList(gameID);

                    if (gameTeamList.Count == 2)
                    {
                        gameModel.gameTeam1ID = gameTeamList[0].TeamID;
                        gameModel.team1Name = gameTeamList[0].Team.TeamName;
                        gameModel.gameTeam2ID = gameTeamList[1].TeamID;
                        gameModel.team2Name = gameTeamList[1].Team.TeamName;
                    }
                    gameModelList2.Add(gameModel);
                }
            }
            return gameModelList2;
        }
    }
}