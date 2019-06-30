using ClassLibrary.Database;
using ClassLibrary.Models;
using System;
using System.Linq;
using System.Data.Entity;

namespace ClassLibrary.Logic.GameModelLogic
{
    public class GameModelSelectLogic : IGameModelSelectLogic
    {
        private IGameModelDetailLogic _gameModelDetailLogic;
        public GameModelSelectLogic(IGameModelDetailLogic gameModelDetaiLogic)
        {
            _gameModelDetailLogic = gameModelDetaiLogic;
        }
        public GameModel GetGameModel(int gameID)
        {
            GameModel gameModel = new GameModel();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    gameModel = context.Games
                        .Include(g => g.Court)
                        .Include(g => g.Division)
                        .Include(g => g.Tournament)
                        .Where(g => g.GameID == gameID)
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
                            division = g.Division.Division1,
                        })
                        .FirstOrDefault();
                }
                gameModel = _gameModelDetailLogic.GetGameModelDetail(gameModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return gameModel;
        }
        public GameModel GetGameModel(int courtID,
            DateTime datePlayed,
            TimeSpan startTime)
        {
            GameModel gameModel = new GameModel();

            try
            {
                using (NetballEntities context = new NetballEntities())
                {
                    gameModel = context.Games
                        .Include(g => g.Court)
                        .Include(g => g.Division)
                        .Include(g => g.Tournament)
                        .Where(g => g.CourtID == courtID &&
                        g.DatePlayed == datePlayed &&
                        g.StartTime == startTime)                         
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
                            division = g.Division.Division1,
                        })
                        .FirstOrDefault();
                }
                if (gameModel != null)
                {
                    gameModel = _gameModelDetailLogic.GetGameModelDetail(gameModel);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return gameModel;

        }
    }
}