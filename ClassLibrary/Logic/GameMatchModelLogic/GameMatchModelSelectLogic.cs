using ClassLibrary.Database;
using ClassLibrary.Logic.GameTeamLogic;
using ClassLibrary.Logic.PersonLogic;
using ClassLibrary.Logic.TeamPlayerLogic;
using ClassLibrary.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ClassLibrary.Logic.GameMatchModelLogic
{
    public class GameMatchModelSelectLogic : IGameMatchModelSelectLogic
    {
        private IGameTeamSelect _gameTeamSelect;
        private IPersonSelect _personSelect;
        private ITeamPlayersSelect _teamPlayersSelect;

        public GameMatchModelSelectLogic(IGameTeamSelect gameTeamSelect,
            IPersonSelect personSelect,
            ITeamPlayersSelect teamPlayersSelect)
        {
            _gameTeamSelect = gameTeamSelect;
            _personSelect = personSelect;
            _teamPlayersSelect = teamPlayersSelect;
        }
        private IList<GameMatchModel>PopulateMatchDetails(IList<GameMatchModel> gameMatchModelList,
            int playerID)
        {
            IList<GameMatchModel> list = new List<GameMatchModel>();

            foreach (GameMatchModel gameMatchModel in gameMatchModelList)
            {
                GameMatchModel row = new GameMatchModel();
                row = GetUmpireDetail(gameMatchModel);
                row = GetTeamDetails(gameMatchModel, playerID);
                list.Add(row);
            }
            return list;
        }
        private GameMatchModel GetTeamDetails(GameMatchModel gameMatchModel,
            int playerID)
        {
            GameMatchModel model = gameMatchModel;
            IList<GameTeam> gameTeamList = new List<GameTeam>();
            TeamPlayer teamPlayer = null;
            int row = 1;
            int gameTeamID;
            string teamName;
            int teamScore;

            gameTeamList = _gameTeamSelect.GetGameTeamList(gameMatchModel.gameID);

            foreach (GameTeam gameTeam in gameTeamList)
            {
                if (row == 1)
                {
                    model.gameTeamID1 = gameTeam.TeamID;
                    model.teamName1 = gameTeam.Team.TeamName;
                    model.teamScore1 = gameTeam.FinalScore ?? 0;
                }
                else if (row == 2)
                {
                    model.gameTeamID2 = gameTeam.TeamID;
                    model.teamName2 = gameTeam.Team.TeamName;
                    model.teamScore2 = gameTeam.FinalScore ?? 0;
                }
                row++;
            }
            row = 1;
            foreach (GameTeam gameTeam in gameTeamList)
            {
                // Only perform for even number rows because gameTeamList contains both teams (with the same GameID).
                // So only do the swap on the second row if required.
                if (row % 2 == 0)
                {
                    teamPlayer = _teamPlayersSelect.GetTeamPlayer(gameTeam.TeamID, playerID);

                    // swap team 1 with team 2 so home team is always the current player ID
                    if (teamPlayer != null)
                    {
                        gameTeamID = model.gameTeamID1;
                        teamName = model.teamName1;
                        teamScore = model.teamScore1;

                        model.gameTeamID1 = model.gameTeamID2;
                        model.teamName1 = model.teamName2;
                        model.teamScore1 = model.teamScore2;
                        model.gameTeamID2 = gameTeamID;
                        model.teamName2 = teamName;
                        model.teamScore2 = teamScore;
                    }
                }
                row++;
            }
            return model;
        }
        private GameMatchModel GetUmpireDetail(GameMatchModel gameMatchModel)
        {
            GameMatchModel model = new GameMatchModel();
            Person primaryUmpire;
            Person secondaryUmpire;
            Person reserveUmpire;

            if (gameMatchModel != null)
            {
                primaryUmpire = _personSelect.GetPerson(gameMatchModel.primaryUmpireID ?? 0);
                secondaryUmpire = _personSelect.GetPerson(gameMatchModel.secondaryUmpireID ?? 0);
                reserveUmpire = _personSelect.GetPerson(gameMatchModel.reserveUmpireID ?? 0);
                model = gameMatchModel;

                if (primaryUmpire != null)
                {
                    model.primaryUmpire = (primaryUmpire.FirstName + " " + primaryUmpire.LastName).Trim();
                }
                if (secondaryUmpire != null)
                {
                    model.secondaryUmpire = (secondaryUmpire.FirstName + " " + secondaryUmpire.LastName).Trim();
                }
                if (reserveUmpire != null)
                {
                    model.secondaryUmpire = (reserveUmpire.FirstName + " " + reserveUmpire.LastName).Trim();
                }
            }
            return model;
        }
        public IList<GameMatchModel>GetGameMatchModelList(int playerID)
        {
            IList<GameMatchModel> gameMatchModelList = new List<GameMatchModel>();

            using (NetballEntities context = new NetballEntities())
            {
                gameMatchModelList = context.GamePlayers
                    .Include(g => g.GameTeam)
                    .Include(g => g.GameTeam.Game)
                    .Where(g => g.PlayerID == playerID)
                    .Select(g => new GameMatchModel
                    {
                        gameID = g.GameTeam.GameID,
                        courtID = g.GameTeam.Game.CourtID,
                        courtName = "",
                        tournamentID = g.GameTeam.Game.TournamentID,
                        tournamentName = "",
                        matchNo = g.GameTeam.Game.MatchNo,
                        venue = g.GameTeam.Game.Venue,
                        datePlayed = g.GameTeam.Game.DatePlayed,
                        primaryUmpireID = g.GameTeam.Game.PrimaryUmpireID,
                        secondaryUmpireID = g.GameTeam.Game.SecondaryUmpireID,
                        reserveUmpireID = g.GameTeam.Game.ReserveUmpireID
                    })
                    .ToList();
            }
            return PopulateMatchDetails(gameMatchModelList, playerID);
        }
    }
}
