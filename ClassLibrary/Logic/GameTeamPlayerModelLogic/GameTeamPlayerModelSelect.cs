using ClassLibrary.Database;
using ClassLibrary.Models;
using System.Linq;
using System.Data.Entity;
using ClassLibrary.Logic.GameTeamModelLogic;
using System;

namespace ClassLibrary.Logic.GameTeamPlayerModelLogic
{
    public class GameTeamPlayerModelSelect : IGameTeamPlayerModelSelect
    {
        /// <summary>
        /// Get game team player data for a game team ID and player ID.
        /// </summary>
        /// <param name="gameTeamID"></param>
        /// <param name="playerID"></param>
        /// <returns></returns>
        private IGameTeamModelSelect _gameTeamModelSelect;

        public GameTeamPlayerModelSelect(IGameTeamModelSelect gameTeamModelSelect)
        {
            _gameTeamModelSelect = gameTeamModelSelect;
        }

        public GameTeamPlayerModel GetGameTeamPlayerModel(int gameTeamID,int playerID)
        {
            GameTeamPlayerModel gameTeamPlayerModel = new GameTeamPlayerModel();

            using (NetballEntities context = new NetballEntities())
            {
                gameTeamPlayerModel = context.GamePlayers
                    .Include(g => g.GameTeam)
                    .Include(g => g.GameTeam.Game)
                    .Include(g => g.GameTeam.Game.Person)
                    .Include(g => g.GameTeam.Game.Person1)
                    .Include(g => g.GameTeam.Game.Person2)
                    .Include(g => g.GameTeam.Game.Person3)
                    //.Include(g => g.GameTeam.Game.Person4)
                    //.Include(g => g.GameTeam.Game.Person5)
                    //.Include(g => g.GameTeam.Game.Person6)
                    .Include(g => g.GameTeam.Team)
                    .Include(g => g.GameTeam.Game.Court)
                    .Include(g => g.GameTeam.Game.Tournament)
                    .Include(g => g.Person)
                    .Where(g => g.GameTeamID == gameTeamID && g.PlayerID == playerID)
                    .Select(g => new GameTeamPlayerModel
                    {
                        gamePlayerID = g.GamePlayerID,
                        teamID = g.GameTeam.TeamID,
                        gameTeamID = g.GameTeamID,
                        teamName = g.GameTeam.Team.TeamName,
                        gameID = g.GameTeam.GameID,
                        courtID = g.GameTeam.Game.CourtID,
                        courtName = g.GameTeam.Game.Court.Court1,
                        tournamentID = g.GameTeam.Game.TournamentID,
                        tournamentName = g.GameTeam.Game.Tournament.Tournament1,
                        matchNo = g.GameTeam.Game.MatchNo,
                        venue = g.GameTeam.Game.Venue,
                        datePlayed = g.GameTeam.Game.DatePlayed,
                        primaryUmpireID = g.GameTeam.Game.PrimaryUmpireID,
                        primaryUmpire = g.GameTeam.Game.Person1 != null ? g.GameTeam.Game.Person1.FirstName + " " + g.GameTeam.Game.Person1.LastName : string.Empty,
                        secondaryUmpireID = g.GameTeam.Game.SecondaryUmpireID,
                        secondaryUmpire = g.GameTeam.Game.Person2 != null ? g.GameTeam.Game.Person2.FirstName + " " + g.GameTeam.Game.Person2.LastName : string.Empty,
                        reserveUmpireID = g.GameTeam.Game.ReserveUmpireID,
                        reserveUmpire = g.GameTeam.Game.Person3 != null ? g.GameTeam.Game.Person3.FirstName + " " + g.GameTeam.Game.Person3.LastName : string.Empty,
                        playerID = g.PlayerID,
                        playerName = g.Person.FirstName + " " + g.Person.LastName,
                        firstQuarterInd = g.FirstQuarterInd,
                        secondQuarterInd = g.SecondQuarterInd,
                        thirdQuarterInd = g.ThirdQuarterInd,
                        fourthQuarterInd = g.FourthQuarterInd
                    })
                    .FirstOrDefault();
            }
            return gameTeamPlayerModel;
        }

        public GameTeamPlayerModel GetGameTeamPlayerModel(int gamePlayerID)
        {
            GameTeamPlayerModel gameTeamPlayerModel = new GameTeamPlayerModel();

            using (NetballEntities context = new NetballEntities())
            {
                gameTeamPlayerModel = context.GamePlayers
                    .Include(g => g.GameTeam)
                    .Include(g => g.GameTeam.Game)
                    .Include(g => g.GameTeam.Game.Person)
                    .Include(g => g.GameTeam.Game.Person1)
                    .Include(g => g.GameTeam.Game.Person2)
                    .Include(g => g.GameTeam.Game.Person3)
                    .Include(g => g.GameTeam.Team)
                    .Include(g => g.GameTeam.Game.Court)
                    .Include(g => g.GameTeam.Game.Tournament)
                    .Include(g => g.Person)
                    .Where(g => g.GamePlayerID == gamePlayerID)
                    .Select(g => new GameTeamPlayerModel
                    {
                        gamePlayerID = g.GamePlayerID,
                        teamID = g.GameTeam.TeamID,
                        gameTeamID = g.GameTeamID,
                        teamName = g.GameTeam.Team.TeamName,
                        gameID = g.GameTeam.GameID,
                        courtID = g.GameTeam.Game.CourtID,
                        courtName = g.GameTeam.Game.Court.Court1,
                        tournamentID = g.GameTeam.Game.TournamentID,
                        tournamentName = g.GameTeam.Game.Tournament.Tournament1,
                        matchNo = g.GameTeam.Game.MatchNo,
                        venue = g.GameTeam.Game.Venue,
                        datePlayed = g.GameTeam.Game.DatePlayed,
                        primaryUmpireID = g.GameTeam.Game.PrimaryUmpireID,
                        primaryUmpire = g.GameTeam.Game.Person1 != null ? g.GameTeam.Game.Person1.FirstName + " " + g.GameTeam.Game.Person1.LastName : string.Empty,
                        secondaryUmpireID = g.GameTeam.Game.SecondaryUmpireID,
                        secondaryUmpire = g.GameTeam.Game.Person2 != null ? g.GameTeam.Game.Person2.FirstName + " " + g.GameTeam.Game.Person2.LastName : string.Empty,
                        reserveUmpireID = g.GameTeam.Game.ReserveUmpireID,
                        reserveUmpire = g.GameTeam.Game.Person3 != null ? g.GameTeam.Game.Person3.FirstName + " " + g.GameTeam.Game.Person3.LastName : string.Empty,
                        playerID = g.PlayerID,
                        playerName = g.Person.FirstName + " " + g.Person.LastName,
                        firstQuarterInd = g.FirstQuarterInd,
                        secondQuarterInd = g.SecondQuarterInd,
                        thirdQuarterInd = g.ThirdQuarterInd,
                        fourthQuarterInd = g.FourthQuarterInd
                    })
                    .FirstOrDefault();
            }
            return gameTeamPlayerModel;
        }
        public GameTeamPlayerModel GetNewGameTeamPlayerModel(int gameTeamID)
        {
            GameTeamPlayerModel gameTeamPlayerModel = new GameTeamPlayerModel();
            GameTeamModel gameTeamModel;

            try
            {
                gameTeamModel = _gameTeamModelSelect.GetGameTeamModel(gameTeamID);
                gameTeamPlayerModel.gameTeamID = gameTeamModel.gameTeamID;
                gameTeamPlayerModel.teamID = gameTeamModel.teamID;
                gameTeamPlayerModel.teamName = gameTeamModel.teamName;
                gameTeamPlayerModel.gameID = gameTeamModel.gameID;
                gameTeamPlayerModel.courtID = gameTeamModel.courtID;
                gameTeamPlayerModel.courtName = gameTeamModel.courtName;
                gameTeamPlayerModel.tournamentID = gameTeamModel.tournamentID;
                gameTeamPlayerModel.tournamentName = gameTeamModel.tournamentName;
                gameTeamPlayerModel.matchNo = gameTeamModel.matchNo;
                gameTeamPlayerModel.venue = gameTeamModel.venue;
                gameTeamPlayerModel.datePlayed = gameTeamModel.datePlayed;
                gameTeamPlayerModel.primaryUmpireID = gameTeamModel.primaryUmpireID;
                gameTeamPlayerModel.primaryUmpire = gameTeamModel.primaryUmpire;
                gameTeamPlayerModel.secondaryUmpireID = gameTeamModel.secondaryUmpireID;
                gameTeamPlayerModel.secondaryUmpire = gameTeamModel.secondaryUmpire;
                gameTeamPlayerModel.reserveUmpireID = gameTeamModel.reserveUmpireID;
                gameTeamPlayerModel.reserveUmpire = gameTeamModel.reserveUmpire;
                //gameTeamPlayerModel.playerID = 0;
                //gameTeamPlayerModel.playerName = null;
                //gameTeamPlayerModel.firstQuarterInd
                //gameTeamPlayerModel.secondQuarterInd
                //gameTeamPlayerModel.thirdQuarterInd
                //gameTeamPlayerModel.fourthQuarterInd
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return gameTeamPlayerModel;
        }
    }
}