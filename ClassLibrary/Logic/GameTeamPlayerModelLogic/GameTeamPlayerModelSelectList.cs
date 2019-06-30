using ClassLibrary.Database;
using ClassLibrary.Models;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace ClassLibrary.Logic.GameTeamPlayerModelLogic
{
    public class GameTeamPlayerModelSelectList : IGameTeamPlayerModelSelectList
    {
        /// <summary>
        /// Get game team player data for a game team ID.
        /// </summary>
        /// <param name="gameTeamID"></param>
        /// <param name="playerID"></param>
        /// <returns></returns>
        public IList<GameTeamPlayerModel> GetGameTeamPlayerModelList(int gameTeamID)
        {
            IList<GameTeamPlayerModel> gameTeamPlayerList = new List<GameTeamPlayerModel>();

            using (NetballEntities context = new NetballEntities())
            {
                gameTeamPlayerList = context.GamePlayers
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
                    .Where(g => g.GameTeamID == gameTeamID)
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
                    .OrderBy(g => g.playerName)
                    .ToList();
            }
            return gameTeamPlayerList;
        }
    }
}