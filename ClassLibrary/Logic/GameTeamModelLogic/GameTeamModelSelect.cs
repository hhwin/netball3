using ClassLibrary.Database;
using ClassLibrary.Models;
using System.Linq;
using System.Data.Entity;

namespace ClassLibrary.Logic.GameTeamModelLogic
{
    public class GameTeamModelSelect : IGameTeamModelSelect
    {
        public GameTeamModel GetGameTeamModel(int gameTeamID)
        {
            GameTeamModel gameTeamModel = new GameTeamModel();

            using (NetballEntities context = new NetballEntities())
            {
                gameTeamModel = context.GameTeams
                    .Include(g => g.Game)
                    .Include(g => g.Game.Court)
                    .Include(g => g.Game.Tournament)
                    .Include(g => g.Game.Person)
                    .Include(g => g.Game.Person1)
                    .Include(g => g.Game.Person2)
                    .Include(g => g.Game.Person3)
                    .Include(g => g.Game.Person4)
                    .Include(g => g.Game.Person5)
                    .Include(g => g.Game.Person6)
                    .Include(g => g.Team)
                    .Where(g => g.GameTeamID == gameTeamID)
                    .Select(g => new GameTeamModel
                    {
                        gameTeamID = g.GameTeamID,
                        gameID = g.GameID,
                        courtID = g.Game.CourtID,
                        courtName = g.Game.Court.Court1,
                        tournamentID = g.Game.Tournament.TournamentID,
                        tournamentName = g.Game.Tournament.Tournament1,
                        matchNo = g.Game.MatchNo,
                        venue = g.Game.Venue,
                        datePlayed = g.Game.DatePlayed,
                        primaryUmpireID = g.Game.Person.PersonID,
                        primaryUmpire = g.Game.Person.FirstName + " " + g.Game.Person.LastName,
                        secondaryUmpireID = g.Game.Person1.PersonID,
                        secondaryUmpire = g.Game.Person1.FirstName + " " + g.Game.Person1.LastName,
                        reserveUmpireID = g.Game.Person2.PersonID,
                        reserveUmpire = g.Game.Person2.FirstName + " " + g.Game.Person2.LastName,
                        teamID = g.TeamID,
                        teamName = g.Team.TeamName,
                        finalScore = g.FinalScore??0
                    })
                    .FirstOrDefault();
            }
            return gameTeamModel;
        }
    }
}