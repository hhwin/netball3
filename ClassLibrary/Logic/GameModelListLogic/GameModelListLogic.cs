using ClassLibrary.Database;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ClassLibrary.Logic.GameModelLogic;
using ClassLibrary.Logic.GameTeamLogic;

namespace ClassLibrary.Logic.GameModelListLogic
{
    public class GameModelListLogic : IGameModelListLogic
    {
        private IGameModelDetailLogic _gameModelDetailLogic;
        private IGameTeamSelect _gameTeamSelect;

        public GameModelListLogic(IGameModelDetailLogic gameModelDetaiLogic,
            IGameTeamSelect gameTeamSelect)
        {
            _gameModelDetailLogic = gameModelDetaiLogic;
            _gameTeamSelect = gameTeamSelect;
        }

        public IList<GameModel> GetGameModelList()
        {
            IList<GameModel> gameModelList = new List<GameModel>();
            IList<GameModel> gameModelList2 = new List<GameModel>();
            IList<GameTeam> gameTeamList;

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    gameModelList = context.Games
                        .AsNoTracking()
                        .Include(g => g.Court)
                        .Include(g => g.Division)
                        .Include(g => g.GameTeams)
                        .Include(g => g.Tournament)
                        .Select(g => new GameModel
                        {
                            gameID = g.GameID,
                            courtID = g.CourtID,
                            courtName = g.Court.Court1,
                            tournamentID = g.TournamentID,
                            tournamentName = g.Tournament.Tournament1,
                            matchNo = g.MatchNo,
                            venue = g.Venue,
                            datePlayed = g.DatePlayed,
                            primaryUmpireID = g.PrimaryUmpireID,
                            secondaryUmpireID = g.SecondaryUmpireID,
                            reserveUmpireID = g.ReserveUmpireID,
                            startTime = g.StartTime,
                            fullTime = g.FullTime,
                            extraTimeEnd = g.ExtraTimeEnd,
                            scorer1ID = g.Scorer1ID,
                            scorer2ID = g.Scorer2ID,
                            timeKeeper1ID = g.TimeKeeper1ID,
                            timeKeeper2ID = g.TimeKeeper2ID,
                            divisionID = g.DivisionID,
                            division = g.Division.Division1
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return gameModelList2;
        }
    }
}